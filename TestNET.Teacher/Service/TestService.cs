using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using System.Linq;
using System.IO;
using TestNET.Shared.Model;

namespace TestNET.Teacher.Service;

public class TestService
{
    public async Task<List<Test>> GetTests()
    {
        List<Test> testList = new();

        try
        {
            string filename = Path.Combine(AppContext.BaseDirectory, "tests.json");
            if (File.Exists(filename))
            {
                using Stream stream = File.OpenRead(filename);
                testList = JsonSerializer.Deserialize<List<Test>>(stream) ?? throw new ArgumentNullException();
            }
        }
        catch
        {
            MessageBox.Show("Unable to load tests", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }

        return testList;
    }

    public void SaveTests(List<Test> tests)
    {
        string filePath = Path.Combine(AppContext.BaseDirectory, "tests.json");

        var options = new JsonSerializerOptions { WriteIndented = true, Converters = { new JsonStringEnumConverter() } };

        string jsonString = JsonSerializer.Serialize(tests, options);

        File.WriteAllText(filePath, jsonString);
    }

    TcpListener? server = null;

    private static string EncodeCode(IPAddress ip_addr)
    {
        byte[] ip_bytes = ip_addr.GetAddressBytes();

        return Convert.ToBase64String(ip_bytes).TrimEnd('=');
    }

    private IPAddress? GetIP()
    {
        var ints = NetworkInterface
        .GetAllNetworkInterfaces()
        .Where(n => n.OperationalStatus == OperationalStatus.Up && n.NetworkInterfaceType != NetworkInterfaceType.Loopback)
        .Where(n => n.NetworkInterfaceType == NetworkInterfaceType.Wireless80211 || n.NetworkInterfaceType == NetworkInterfaceType.Ethernet);
        //.SelectMany(n => n.GetIPProperties()?.UnicastAddresses)
        //.Where(n => n.Address.AddressFamily == AddressFamily.InterNetwork)
        //.Select(g => g?.Address)
        //.Where(a => a != null);

        foreach (var i in ints)
        {
            IPAddress? ip = i.GetIPProperties().UnicastAddresses.Where(n => n.Address.AddressFamily == AddressFamily.InterNetwork)
                .Select(n => n.Address).Where(a => a != null).FirstOrDefault() ?? throw new Exception();
            string msg = $"{i.Name}\n{ip}";
            var result = MessageBox.Show(msg, "IP", MessageBoxButton.YesNo);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    return ip;
            }
        }
        return null;
    }

    public void ShareTest(Test test)
    {
        _ = Task.Run(async () =>
        {
            try
            {
                IPAddress? localAddr = GetIP() ?? throw new Exception("No internet");

                if (localAddr == null) return;

                //localAddr = IPAddress.Parse("192.168.80.146");

                server = new TcpListener(localAddr, 61234);
                server.Start();

                Task.Run(() =>
                {
                    MessageBox.Show($"{EncodeCode(localAddr)}", "Code", MessageBoxButton.OK);
                });

                while (true)
                {
                    Task.Run(() => MessageBox.Show("Waiting for a connection... "));

                    {
                        using TcpClient client = server.AcceptTcpClient();
                        using NetworkStream stream = client.GetStream();

                        byte[] requestBytes = new byte[1024];
                        int requestLength = 0;

                        // Exhaust the entire stream
                        for (int currentLength = 0; (currentLength = stream.Read(requestBytes, requestLength, 1024)) != 0;)
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
                        Request? request = JsonSerializer.Deserialize<Request>(requestJson) ?? throw new ArgumentNullException(nameof(request));

                        if (request is TestRequest testRequest)
                        {
                            await Task.Run(() => handleTestRequest(testRequest, test, stream));
                        } 
                        else if (request is SubmissionRequest submissionRequest)
                        {
                            await Task.Run(() => handleSubmissionRequest(submissionRequest, stream));
                        } 
                        else
                        {
                            MessageBox.Show("Something terribly wrong has happened");
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
                server?.Stop();
            }
        });
    }
    public void handleTestRequest(TestRequest request, Test test, NetworkStream stream)
    {
        Task.Run(() => MessageBox.Show($"{request.StudentName} connected with code {request.Code}."));

        TestResponse response = new() { Error = "", Test = test.WithoutAnswers() };

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

    public void handleSubmissionRequest(SubmissionRequest request, NetworkStream stream)
    {

        byte[] responseBytes = Encoding.UTF8.GetBytes("OK");

        stream.Write(responseBytes, 0, responseBytes.Length);
        stream.Write([0xff], 0, 1);

        Task.Run(() => MessageBox.Show(string.Join('\n', request.Submission.Values)));
    }

    public void StopSharingTest()
    {
        server?.Stop();
    }
}
