using System.Net.Sockets;
using System.Net;

namespace TestNET.Teacher.Service;

public class TestService
{
    public async Task<List<Test>> GetTests()
    {
        List<Test> testList = new();

        string filename = Path.Combine(AppContext.BaseDirectory, "tests.json");
        if (File.Exists(filename))
        {
            using Stream stream = File.OpenRead(filename);
            testList = (List<Test>)JsonSerializer.Deserialize(stream, typeof(List<Test>));
        }

        if (testList == null)
            throw new Exception();
        return testList;
    }

    public void SaveTests(List<Test> tests)
    {
        string filePath = Path.Combine(AppContext.BaseDirectory, "tests.json");

        var options = new JsonSerializerOptions { WriteIndented = true, Converters = { new JsonStringEnumConverter() } };

        string jsonString = JsonSerializer.Serialize(tests, options);

        File.WriteAllText(filePath, jsonString);
    }

    TcpListener server = null;

    public void ShareTest(Test test)
    {
        _ = Task.Run(() =>
        {
            try
            {
                int port = 13000;

                IPAddress localAddr;
                localAddr = IPAddress.Parse("127.0.0.1");

                server = new TcpListener(localAddr, port);
                server.Start();

                while (true)
                {
                    Task.Run(() => MessageBox.Show("Waiting for a connection... "));

                    {
                        using TcpClient client = server.AcceptTcpClient();
                        using NetworkStream stream = client.GetStream();

                        byte[] requestBytes = new byte[1024];
                        int requestLength = 0;

                        // Exhaust the entire stream
                        for (int currentLength = 0;
                            (currentLength = stream.Read(requestBytes, requestLength, 1024)) != 0;)
                        {
                            requestLength += currentLength;

                            if (requestBytes[requestLength - 1] == 0xff)
                            { 
                                break;
                            }

                            Array.Resize(ref requestBytes, requestLength + 1024);
                        }

                        Array.Resize(ref requestBytes, requestLength - 1);

                        string requestJson = Encoding.UTF8.GetString(requestBytes);
                        TestRequest? request = JsonSerializer.Deserialize<TestRequest>(requestJson);

                        if (request is null)
                        {
                            throw new ArgumentNullException(nameof(request));
                        }

                        Task.Run(() => MessageBox.Show($"{request.StudentName} connected with code {request.Code}."));

                        TestResponse response = new TestResponse { Error = "", Test = test };

                        string responseJson = JsonSerializer.Serialize(response);
                        byte[] responseBytes = Encoding.UTF8.GetBytes(responseJson);

                        stream.Write(responseBytes, 0, responseBytes.Length);
                        stream.Write([0xff], 0, 1);

                        byte[] acknowledge = new byte[1];
                        stream.Read(acknowledge, 0, 1);
                        
                        if (acknowledge[0] != 0xff)
                        {
                            throw new ArgumentException($"Acknowledge was not 0: {acknowledge[0]}");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            finally
            {
                server.Stop();
            }
        });
    }

    public void StopSharingTest()
    {
        server.Stop();
    }
}
