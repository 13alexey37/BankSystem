using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using TransferDataClassLibrary.Net;

namespace Server.Engine
{
    class ServerEngineCore
    {
        private TcpListener tcpListener;

        public ServerEngineCore()
        {
            tcpListener = new TcpListener(TcpConnection.IPEndPoint);
            tcpListener.Start(2);
        }

        public TcpClient AcceptClient()
        {
            return tcpListener.AcceptTcpClient();
        }

        public static RequestWrapper GetRequestFromClient(TcpClient client)
        {
            string jsonString = TcpConnection.RecieveText(client);

            return JsonConvert.DeserializeObject<RequestWrapper>(jsonString);
        }

        public static void SendResponseToClient(ResponseWrapper responseWrapper, TcpClient client)
        {
            string jsonString = JsonConvert.SerializeObject(responseWrapper);

            TcpConnection.SendText(client, jsonString);
        }

    }
}
