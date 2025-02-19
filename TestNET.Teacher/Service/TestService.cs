using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;

using TestNET.Teacher.Service.DB;

namespace TestNET.Teacher.Service;
public class TestService(LogService logService)
{
    LogService logService = logService;

    private bool cleaned = false;

    public async Task<List<TeacherTest>> GetTests()
    {
        var tests = new List<TeacherTest>();

        var testDBs = new IndexDB(cleaned).LoadAll();
        cleaned = true;

        foreach (var testDB in testDBs)
        {
            tests.Add(testDB.Load());
        }

        return tests;
    }

    public void SaveTests(List<TeacherTest> tests)
    {
        var index = new IndexDB();

        index.Wipe();

        foreach (var test in tests)
        {
            index.Add(test);
        }
    }

    public void DeleteTest(TeacherTest test)
    {
        var index = new IndexDB();
        index.Remove(test);
    }

    public TeacherTest? ImportTest(string path)
    {
        var importedPath = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileName(path));

        if (File.Exists(importedPath))
        {
            var testDB = new TestDB(importedPath);
            var test = testDB.Load();

            return test;
        }

        try
        {
            File.Copy(path, importedPath);

            var testDB = new TestDB(Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileName(path)));
            var test = testDB.Load();

            var index = new IndexDB();
            index.Add(test);

            return test;
        }
        catch
        {

        }

        return null;
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

    public void ShareTest(TeacherTest test)
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

                //Task.Run(() =>
                //{
                //    MessageBox.Show($"{EncodeCode(localAddr)}", "Code", MessageBoxButton.OK);
                //});

                logService.TestLog += $"{EncodeCode(localAddr)}\n";

                while (true)
                {
                    logService.TestLog += $"Waiting for a connection... \n";

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
                            await Task.Run(() => handleSubmissionRequest(submissionRequest, test, stream));
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
        //Task.Run(() => MessageBox.Show($"{request.StudentName} connected with code {request.Code}."));
        logService.TestLog += $"{request.StudentName} connected\n";

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

    public void handleSubmissionRequest(SubmissionRequest request, TeacherTest test, NetworkStream stream)
    {
        Submission temp = request.Submission;
        temp.Points = test.Grade(request.Submission);


        byte[] responseBytes = Encoding.UTF8.GetBytes("OK");

        stream.Write(responseBytes, 0, responseBytes.Length);
        stream.Write([0xff], 0, 1);

        App.Current.Dispatcher.Invoke((Action)delegate
        {
            (test.Submissions ??= new()).Add(temp);
        });
    }

    public void StopSharingTest()
    {
        server?.Stop();
    }
}
