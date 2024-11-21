using System.Net.Sockets;

namespace TestNET.Student.Service;

public class TestService
{
    public (string,int) ParseCode(string code)
    {
        //string temp = Encoding.UTF8.GetString(Convert.FromBase64String(code));
        //string[] temp2 = temp.Split(":");
        string[] temp2 = code.Split(":");
        return (temp2[0], int.Parse(temp2[1]));
    }

    public async Task<Test> GetTest(string name, string code)
    {
        try
        {
            int port = 13000;

            {
                //using TcpClient client = new TcpClient("192.168.80.146", port);
                using TcpClient client = new TcpClient(ParseCode(code).Item1, ParseCode(code).Item2);
                using NetworkStream stream = client.GetStream();

                TestRequest request = new TestRequest { StudentName = name, Code = 13000 };
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
                TestResponse? response = JsonSerializer.Deserialize<TestResponse>(responseJson);

                if (response is null)
                {
                    throw new ArgumentNullException("Invalid response.");
                }

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
