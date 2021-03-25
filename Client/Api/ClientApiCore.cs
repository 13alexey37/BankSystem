using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using TransferDataClassLibrary.Net;
using  Newtonsoft.Json;

namespace Client.Api
{
    class ClientApiCore
    {
        private TcpClient tcpClient;
        
        public ClientApiCore()
        {
            tcpClient = new TcpClient();
            tcpClient.Connect(TcpConnection.IPEndPoint);
        }

        public void SendRequestToServer(RequestWrapper requestWrapper)
        {
            string jsonString = JsonConvert.SerializeObject(requestWrapper);

            TcpConnection.SendText(tcpClient, jsonString);
        }

        public ResponseWrapper GetResponseFromServer()
        {
            string jsonString = TcpConnection.RecieveText(tcpClient);
            return JsonConvert.DeserializeObject<ResponseWrapper>(jsonString);
        }
    }
}
