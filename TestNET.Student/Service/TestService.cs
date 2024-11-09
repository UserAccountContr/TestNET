﻿using System.Net.Sockets;

namespace TestNET.Student.Service;

public class TestService
{
    public async Task<Test> GetTest(string name)
    {
        try
        {
            // Create a TcpClient.
            // Note, for this client to work you need to have a TcpServer
            // connected to the same address as specified by the server, port
            // combination.
            Int32 port = 13000;

            // Prefer a using declaration to ensure the instance is Disposed later.
            using TcpClient client = new TcpClient("127.0.0.1", port);

            // Translate the passed message into ASCII and store it as a Byte array.
            Byte[] data = System.Text.Encoding.ASCII.GetBytes(name);

            // Get a client stream for reading and writing.
            NetworkStream stream = client.GetStream();

            // Send the message to the connected TcpServer.
            stream.Write(data, 0, data.Length);

            //MessageBox.Show("Sent: {0}", "A");

            // Receive the server response.

            // Buffer to store the response bytes.
            data = new Byte[1024];

            // String to store the response ASCII representation.
            String responseData = String.Empty;

            // Read the first batch of the TcpServer response bytes.
            Int32 bytes = stream.Read(data, 0, data.Length);
            responseData = System.Text.Encoding.ASCII.GetString(data, 0, bytes);
            //Console.WriteLine("Received: {0}", responseData);

            // Explicit close is not necessary since TcpClient.Dispose() will be
            // called automatically.
            // stream.Close();
            // client.Close();
            return (Test)JsonSerializer.Deserialize(responseData, typeof(Test));
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
