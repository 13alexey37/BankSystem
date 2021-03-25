using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TransferDataClassLibrary.Net
{
    public class TcpConnection
    {
        public static IPEndPoint IPEndPoint
        {
            get
            {
                return new IPEndPoint(IPAddress.Parse("127.0.0.1"), 23456);
            }
        }

        public static void SendText(TcpClient tcpClient, string text)
        {
            NetworkStream stream = tcpClient.GetStream();
            byte[] data = Encoding.UTF8.GetBytes(text);

            stream.Write(data,0, data.Length);
        }

        public static string RecieveText(TcpClient tcpClient)
        {
            StringBuilder responseBuilder = new StringBuilder();

            NetworkStream stream = tcpClient.GetStream();

            byte[] data = new byte[1024];

            do
            {
                int countBytes = stream.Read(data, 0, data.Length);
                responseBuilder.Append(Encoding.UTF8.GetString(data, 0, countBytes));
            } while (stream.DataAvailable);

            return responseBuilder.ToString();
        }
    }
}
