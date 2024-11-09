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
        Task.Run(() =>
        {
            try
            {
                // Set the TcpListener on port 13000.
                Int32 port = 13000;
                IPAddress localAddr = IPAddress.Parse("127.0.0.1");

                // TcpListener server = new TcpListener(port);
                server = new TcpListener(localAddr, port);

                // Start listening for client requests.
                server.Start();

                // Buffer for reading data
                Byte[] bytes = new Byte[1024];
                String data = null;

                // Enter the listening loop.
                while (true)
                {
                    MessageBox.Show("Waiting for a connection... ");

                    // Perform a blocking call to accept requests.
                    // You could also use server.AcceptSocket() here.
                    using TcpClient client = server.AcceptTcpClient();

                    data = null;

                    // Get a stream object for reading and writing
                    NetworkStream stream = client.GetStream();

                    int i;

                    // Loop to receive all the data sent by the client.
                    while ((i = stream.Read(bytes, 0, bytes.Length)) != 0)
                    {
                        // Translate data bytes to a ASCII string.
                        data = System.Text.Encoding.ASCII.GetString(bytes, 0, i);
                        //MessageBox.Show("Received: {0}", data);
                        MessageBox.Show(data + "Connected!");

                        // Process the data sent by the client.
                        data = JsonSerializer.Serialize(test);

                        byte[] msg = System.Text.Encoding.ASCII.GetBytes(data);

                        // Send back a response.
                        stream.Write(msg, 0, msg.Length);
                        //MessageBox.Show("Sent: {0}", data);
                    }
                }
            }
            catch (SocketException e)
            {
                //MessageBox.Show("SocketException: {0}", e);
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
