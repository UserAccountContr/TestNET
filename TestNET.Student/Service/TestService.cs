using System.Net;
using System.Net.Sockets;

namespace TestNET.Student.Service;

public class TestService
{
    private static (IPAddress, int) DecodeCode(string base64encoded)
    {
        string padded = base64encoded + new string('=', base64encoded.Length % 4);
        byte[] code = Convert.FromBase64String(padded);

        byte[] ip_bytes = new byte[code[0]];
        code.AsSpan(1, code[0]).CopyTo(ip_bytes);

        byte[] port_bytes = new byte[code.Length - code[0]];
        code.AsSpan(code[0] + 1, code.Length - (code[0] + 1)).CopyTo(port_bytes);

        IPAddress ip = new(ip_bytes);
        int port = BitConverter.ToInt16(port_bytes);

        return (ip, port);
    }

    public async Task<Test> GetTest(string name, string code)
    {
        try
        {
            //int port = 13000;

            {
                //using TcpClient client = new TcpClient("192.168.80.146", port);
                var endpoint = DecodeCode(code);
                using TcpClient client = new(endpoint.Item1.ToString(), endpoint.Item2);
                using NetworkStream stream = client.GetStream();

                TestRequest request = new() { StudentName = name, Code = 13000 };
                string requestJson = JsonSerializer.Serialize(request);
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
}
