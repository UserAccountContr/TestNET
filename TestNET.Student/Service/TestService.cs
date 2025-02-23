using System.Net;
using System.Net.Sockets;
using System.Xml.Linq;

namespace TestNET.Student.Service;

public class TestService
{
    private IPAddress? DecodeCode(string base64encoded)
    {
        string padded = base64encoded + new string('=', 4 - base64encoded.Length % 4);

        try
        {
            byte[] code = Convert.FromBase64String(padded);
            ip = new(code);
        } 
        catch
        {
            MessageBox.Show("Invalid Test Code\nНевалиден Код за Тест", "Error", MessageBoxButton.OK, MessageBoxImage.Warning);
        }

        return ip;
    }

    IPAddress? ip;
    string? name;

    public async Task<Test> GetTest(string name, string code)
    {
        try
        {
            {
                this.name = name;
                //using TcpClient client = new TcpClient("192.168.80.146", port);
                IPAddress endpoint = DecodeCode(code) ?? throw new ArgumentException("Invalid IP.");
                using var client = new TcpClient();

                if (!client.ConnectAsync(endpoint.ToString(), 61234).Wait(10_000))
                {
                    MessageBox.Show("Could not connect to the Test server\nНе беше осъществена връзка със сървъра", "Server error", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw new ArgumentNullException();
                }

                using NetworkStream stream = client.GetStream();

                TestRequest request = new() { StudentName = name };
                string requestJson = JsonSerializer.Serialize(request as Request);
                byte[] requestBytes = Encoding.UTF8.GetBytes(requestJson);

                stream.Write(requestBytes, 0, requestBytes.Length);
                stream.Write([0xff], 0, 1);

                byte[] responseBytes = new byte[1024];
                int responseLength = 0;

                for (int currentLenght = 0;
                    (currentLenght = await stream.ReadAsync(responseBytes, responseLength, 1024)) != 0;)
                {
                    responseLength += currentLenght;

                    if (responseBytes[responseLength - 1] == 0xff)
                    {
                        break;
                    }

                    Array.Resize(ref responseBytes, responseLength + 1024);
                }

                Array.Resize(ref responseBytes, responseLength - 1);

                stream.Write([0xff], 0, 1); // Acknowledge

                string responseJson = Encoding.UTF8.GetString(responseBytes);
                TestResponse? response = JsonSerializer.Deserialize<TestResponse>(responseJson) ?? throw new ArgumentNullException("Invalid response.");

                if (response.Test is null)
                {
                    throw new ArgumentNullException(response.Error);
                }

                return response.Test;
            }
        }
        catch
        {

        }

        return null;
    }

    public async Task<Submission> GetSubm(string name, string code, string revPass)
    {
        try
        {
            {
                IPAddress endpoint = DecodeCode(code) ?? throw new ArgumentException("Invalid IP.");
                using var client = new TcpClient();

                if (!client.ConnectAsync(endpoint.ToString(), 61234).Wait(10_000))
                {
                    MessageBox.Show("Could not connect to the Test server\nНе беше осъществена връзка със сървъра", "Server error", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw new ArgumentNullException();
                }

                using NetworkStream stream = client.GetStream();

                TestReviewRequest request = new() { StudentName = name, ReviewCode = revPass };
                string requestJson = JsonSerializer.Serialize(request as Request);
                byte[] requestBytes = Encoding.UTF8.GetBytes(requestJson);

                stream.Write(requestBytes, 0, requestBytes.Length);
                stream.Write([0xff], 0, 1);

                byte[] responseBytes = new byte[1024];
                int responseLength = 0;

                for (int currentLenght = 0;
                    (currentLenght = await stream.ReadAsync(responseBytes, responseLength, 1024)) != 0;)
                {
                    responseLength += currentLenght;

                    if (responseBytes[responseLength - 1] == 0xff)
                    {
                        break;
                    }

                    Array.Resize(ref responseBytes, responseLength + 1024);
                }

                Array.Resize(ref responseBytes, responseLength - 1);

                stream.Write([0xff], 0, 1); // Acknowledge

                string responseJson = Encoding.UTF8.GetString(responseBytes);
                SubmResponse? response = JsonSerializer.Deserialize<SubmResponse>(responseJson) ?? throw new ArgumentNullException("Invalid response.");

                if (response.Subm is null)
                {
                    MessageBox.Show("Couldn't get submission", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
                else return response.Subm;
            }
        }
        catch
        {

        }

        return null;
    }

    public async Task<bool> ReturnTest(Test test)
    {
        try
        {
            {
                using TcpClient client = new(ip.ToString(), 61234);
                using NetworkStream stream = client.GetStream();

                SubmissionRequest request = new() { Submission = new(name, test/*.Questions.ToDictionary(x => x.UniqueId, x => x.Answer)*/, DateTime.Now) };
                string requestJson = JsonSerializer.Serialize(request as Request);
                byte[] requestBytes = Encoding.UTF8.GetBytes(requestJson);

                stream.Write(requestBytes, 0, requestBytes.Length);
                stream.Write([0xff], 0, 1);

                byte[] responseBytes = new byte[1024];
                int responseLength = 0;

                for (int currentLenght = 0; (currentLenght = await stream.ReadAsync(responseBytes, responseLength, 1024)) != 0;)
                {
                    responseLength += currentLenght;

                    if (responseBytes[responseLength - 1] == 0xff)
                    {
                        break;
                    }

                    Array.Resize(ref responseBytes, responseLength + 1024);
                }

                Array.Resize(ref responseBytes, responseLength - 1);

                stream.Write([0xff], 0, 1); // Acknowledge

                string responseJson = Encoding.UTF8.GetString(responseBytes);

                if (responseJson == "OK") return true;
                else return false;
            }
        }
        catch (ArgumentNullException e)
        {
            //Console.WriteLine("ArgumentNullException: {0}", e);
        }
        catch (SocketException e)
        {
            //Console.WriteLine("SocketException: {0}", e);
        }

        //MessageBox.Show(string.Join('\n', test.Questions.Select(x => x.Answer.Text)));
        return false;
    }
}
