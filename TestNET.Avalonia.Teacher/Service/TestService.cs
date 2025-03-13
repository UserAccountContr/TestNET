using System.Net.Sockets;
using System.Net;
using System.Net.NetworkInformation;
using TestNET.Avalonia.Teacher.Service.DB;

namespace TestNET.Avalonia.Teacher.Service;

public class TestService(LogService logService)
{
    LogService logService = logService;

    private bool cleaned = false;

    public async Task<List<TeacherTest>> GetTests()
    {
        Directory.CreateDirectory(Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TestNET"));
        Directory.SetCurrentDirectory(Path.Join(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "TestNET"));
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

    int codeSize = 10_000;

    private string GenerateReviewCode(List<string> usedCodes)
    {
        string code = "0000";

        if (usedCodes.Count > codeSize / 2)
        {
            codeSize *= 10;
        }

        do
        {
            var rng = new Random();
            code = rng.Next(0, codeSize).ToString(new string('0', (int)Math.Log10(codeSize)));
        } while (
            code.Distinct().Count() == 1 || usedCodes.Contains(code)
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
            return ip;
            ////var result = MessageBox.Show(msg, "IP", MessageBoxButton.YesNo);
            ////switch (result)
            ////{
            ////    case MessageBoxResult.Yes:
            ////        return ip;
            ////}
        }
        return null;
    }

    public void StartSharingTest(TeacherTest test)
    {
        try
        {
            IPAddress? localAddr = GetIP() ?? throw new Exception("No internet");

            if (localAddr == null) return;

            logService.TestLog += $"Started test server with code {EncodeCode(localAddr)}\n";
            logService.IPCode = EncodeCode(localAddr);
            logService.TestStarted = true;

            ShareTest(test, localAddr);
        }
        catch (Exception e)
        {
            ////MessageBox.Show(e.Message, "Error", MessageBoxButton.OK, MessageBoxImage.Error);
        }
    }

    public void ShareTest(TeacherTest test, IPAddress localAddr)
    {
        _ = Task.Run(async () =>
        {
            try
            {
                server = new TcpListener(localAddr, 61234);
                server.Start();

                while (true)
                {
                    logService.TestLog += $"Waiting for a connection... \n";

                    {
                        /*
                         * The server and client communicate with JSON
                         * messages which are defined in TestNET.Shared/Networking.cs
                         */
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
                                ////MessageBox.Show("Something terribly wrong has happened", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
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
                logService.TestStarted = false;
            }
        });
    }

    public void handleTestRequest(TestRequest request, TeacherTest test, NetworkStream stream)
    {
        //Task.Run(() => MessageBox.Show($"{request.StudentName} connected with code {request.Code}."));
        logService.TestLog += $"{request.StudentName} connected\n";

        TestResponse response;

        if (false /*test.Submissions.Select(x => x.Name).Contains(request.StudentName)*/)
        {
            response = new() { Error = "Already submitted", Test = null };
        }
        else
        {
            Test studentTest = test.NormalTest().WithoutAnswers();

            if (test.Shuffled)
            {
                var rnd = new Random();
                studentTest.Questions = new ObservableCollection<Question>(studentTest.Questions.OrderBy(item => rnd.Next()));
            } 

            response = new() { Error = "", Test = studentTest };
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

    public void handleTestReviewRequest(TestReviewRequest request, TeacherTest test, NetworkStream stream)
    {
        //Task.Run(() => MessageBox.Show($"{request.StudentName} connected with code {request.Code}."));
        logService.TestLog += $"{request.StudentName} connected\n";

        TestReviewResponse response;
        Submission? submission = test.Submissions
            .Where(x => x.Name == request.StudentName)
            .Where(x => x.Code == request.ReviewCode)
            .LastOrDefault();

        /*
         * In order to see your results:
         * - The teachers needs to have enabled it
         * - You need to have submitted smth
         * - The codes need to match
         */

        if (!logService.SubmissionsViewable)
        {
            response = new()
            {
                Error = "Teacher has not allowed viewing tests yet",
                Subm = null
            };
        }
        else if (submission is null || (request.ReviewCode != submission.Code))
        {
            response = new()
            {
                Error = "Invalid credentials",
                Subm = null
            };
        }
        else if (submission.RequiresAttention)
        {
            response = new()
            {
                Error = "Test has not been graded yet",
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
        //if (temp.Answers.Name != test.Name)
        //{
        //
        //}
        test.Grade(ref temp);
        temp.CorrectAnswers = test.NormalTest();                //must be reworked for the nac. krug :)

        var usedCodes = test.Submissions.Select(x => x.Code).ToList();
        
        temp.Code = GenerateReviewCode(usedCodes);

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

        ////App.Current.Dispatcher.Invoke((Action)delegate
        ////{
        ////    (test.Submissions ??= new()).Add(temp);
        ////});
    }

    public void StopSharingTest()
    {
        server?.Stop();
        logService.TestStarted = false;
    }
}
