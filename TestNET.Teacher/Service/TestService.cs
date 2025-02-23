﻿using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;

using TestNET.Teacher.Service.DB;
using System.Printing;

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
        var testDB = new TestDB(path);
        var test = testDB.Load();

        var importedPath = Path.Combine(Directory.GetCurrentDirectory(), Path.GetFileName(test.Name));

        try
        {
            File.Copy(path, importedPath);
        }
        catch (IOException)
        {

        }

        var index = new IndexDB();
        index.Add(test);

        return test;
    }

    TcpListener? server = null;

    private static string EncodeCode(IPAddress ip_addr)
    {
        byte[] ip_bytes = ip_addr.GetAddressBytes();

        return Convert.ToBase64String(ip_bytes).TrimEnd('=');
    }

    private string GenerateReviewCode()
    {
        string[] bannedCodes =
        {
            "1234",
            "0000", "1111", "2222", "3333", "4444", "5555", "6666", "7777", "8888", "9999",
            "8520"
        };

        string code = "1234";

        do
        {
            var rng = new Random();
            code = rng.Next(0, 10_000).ToString("0000");
        } while (
            bannedCodes.Contains(code)
        );

        return code;
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

                        switch (request)
                        {
                            case TestRequest testRequest:
                                await Task.Run(() => handleTestRequest(testRequest, test, stream));
                                break;
                            case SubmissionRequest submissionRequest:
                                await Task.Run(() => handleSubmissionRequest(submissionRequest, test, stream));
                                break;
                            case TestReviewRequest testReviewRequest:
                                await Task.Run(() => handleTestReviewRequest(testReviewRequest, test, stream));
                                break;
                            default:
                                MessageBox.Show("Something terribly wrong has happened", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                                break;
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

    public void handleTestReviewRequest(TestReviewRequest request, TeacherTest test, NetworkStream stream)
    {
        //Task.Run(() => MessageBox.Show($"{request.StudentName} connected with code {request.Code}."));
        logService.TestLog += $"{request.StudentName} connected\n";

        TestReviewResponse response;
        Submission? submission = test.Submissions.Where(x => x.Name == request.StudentName).LastOrDefault();

        if (submission is null || (request.ReviewCode != submission.Code))
        {
            response = new()
            {
                Error = "Wrong credentials.",
                Subm = null
            };
        }
        else
        {
            response = new() 
            { 
                Error = "",
                Subm = submission
            };
        }

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
        temp.CorrectAnswers = test.NormalTest();                //must be reworked for the nac. krug :)
        temp.Code = GenerateReviewCode();

        SubmissionResponse response = new() { ReviewCode = temp.Code };

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
