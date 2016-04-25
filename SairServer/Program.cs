using System;
using System.Collections.Generic;
using System.Net;

namespace SairServer
{
    class Program
    {
        private static IPAddress mIpAdress;
        private static wsClientFactory mWsClientFactory;

        static void Main(string[] args)
        {
            Console.Title = "SairServer";

            mIpAdress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0];

            wsServer wsServer = new wsServer(mIpAdress, 443);

            mWsClientFactory = new wsClientFactory();

            wsServer.start();

            Console.WriteLine("Started server on " + mIpAdress.ToString());

            string input = Console.ReadLine();
            while (input != "exit")
            {
                input = Console.ReadLine();
            }

            wsServer.stop();
        }

        public static void addwsClient(wsClient awsClient)
        {
            mWsClientFactory.addwsClient(awsClient);
        }
    }
}
