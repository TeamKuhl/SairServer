using System;
using System.Collections.Generic;
using System.Net;

namespace SairServer
{
    class Program
    {
        private static IPAddress mIpAdress;
        private static List<wsClient> wsClients;
        private static Database mDatabase;
        private static Container mengineObjects;

        static void Main(string[] args)
        {
            Console.Title = "SairServer";

            mIpAdress = Dns.GetHostByName(Dns.GetHostName()).AddressList[0];

            mDatabase = new Database(mIpAdress, "Sair", "root", "");

            mengineObjects = new Container(Enums.sendType.objectchange);

            wsServer wsServer = new wsServer(mIpAdress, 443);
            wsClients = new List<wsClient>();
            wsServer.start();

            Console.WriteLine("Started server on " + mIpAdress.ToString());
            string test = Console.ReadLine();
            while (test != "exit")
            {
                test = Console.ReadLine();
            }

            wsServer.stop();
        }


        public static void broadcastWS(object obj)
        {
            foreach (wsClient client in wsClients)
            {
                client.send(obj);
            }
        }

        public static void broadcastWS(object obj, wsClient aClient)
        {
            foreach (wsClient client in wsClients)
            {
                if (aClient.ID != client.ID)
                {
                    client.send(obj);
                }
            }
        }

        public static void addwsClient(wsClient awsClient)
        {
            awsClient.onOpen += new OpenHandler(openWS);
            awsClient.onReceivedMessage += new ReceiveHandler(receivedMessage);
            awsClient.onClose += new CloseHandler(closeWS);
            wsClients.Add(awsClient);

            Console.WriteLine("New client has connected");
        }

        private static void openWS(wsClient awsClient)
        {
            Console.WriteLine("Client got ID: " + awsClient.ID);
            awsClient.send(mDatabase.getMap(9));

            clientuuid cuuid = new clientuuid();
            cuuid.uuid = awsClient.ID;
            awsClient.send(cuuid);

            engineObject obj = new engineObject(awsClient.ID, "fire", new position(1, 1, 1), new rotation());

            mengineObjects.add(obj);

            Container container = new Container(Enums.sendType.objectchange);
            container.add(obj);
            broadcastWS(container);

            awsClient.send(mengineObjects);
        }

        private static void closeWS(wsClient awsClient)
        {
            wsClients.Remove(awsClient);

            foreach (engineObject eObj in mengineObjects.objects)
            {
                if (eObj.uuid == awsClient.ID)
                {
                    Container container = new Container(Enums.sendType.objectdelete);
                    container.add(eObj);
                    broadcastWS(container);

                    mengineObjects.delete(eObj);
                    break;
                }
            }

            Console.WriteLine(awsClient.ID + " has disconnected");
        }

        private static void receivedMessage(wsClient awsClient, string aMessage)
        {
            if (aMessage == "map")
            {
                awsClient.send(mDatabase.getMap(1));
            }
            else
            {
                Enums.type objType = JSON.getType(aMessage);
                if (objType == Enums.type.setobject)
                {
                    object jsonObj = JSON.deserialize(aMessage);
                    engineObject obj = (engineObject)jsonObj;
                    obj.uuid = awsClient.ID;

                    Container container = new Container(Enums.sendType.objectchange);
                    container.add(obj);
                    broadcastWS(container, awsClient);

                    foreach (engineObject eObj in mengineObjects.objects)
                    {
                        if (eObj.uuid == awsClient.ID)
                        {
                            mengineObjects.delete(eObj);
                            mengineObjects.add(obj);
                            break;
                        }
                    }
                }
            }
        }
    }
}
