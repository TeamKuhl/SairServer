using System;
using System.Threading.Tasks;
using System.Net;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace SairServer
{
    public class wsServer
    {
        private WebSocketServer mServer;

        public wsServer(IPAddress aIpAdress, int aPort)
        {
            mServer = new WebSocketServer(aIpAdress, aPort, false);
            mServer.AddWebSocketService<wsClient>("/wsService");
        }

        public void start()
        {
            mServer.Start();
        }

        public void stop()
        {
            mServer.Stop();
        }
    }
}
