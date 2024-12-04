using System.Net;
using System.Net.Sockets;

namespace TestNET.Student.Service;

public class TestService
{
    private static IPAddress DecodeCode(string base64encoded)
    {
        string padded = base64encoded + new string('=', 4 - base64encoded.Length % 4);
        byte[] code = Convert.FromBase64String(padded);

        IPAddress ip = new(code);

        return ip;
    }

    public async Task<Test> GetTest(string name, string code)
    {
        try
        {
            //int port = 13000;

            {
                //using TcpClient client = new TcpClient("192.168.80.146", port);
                IPAddress endpoint = DecodeCode(code) ?? throw new ArgumentException("Invalid IP.");
                using TcpClient client = new(endpoint.ToString(), 61234);
                using NetworkStream stream = client.GetStream();

                TestRequest request = new() { StudentName = name, Code = 13000 };
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
        catch (ArgumentNullException e)
        {
            //Console.WriteLine("ArgumentNullException: {0}", e);
        }
        catch (SocketException e)
        {
            //Console.WriteLine("SocketException: {0}", e);
        }
        return null;
    }

    public async void ReturnTest(Test test)
    {
        MessageBox.Show(string.Join('\n', test.Questions.Select(x => x.Answer.Text)));
    }
}
