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

            mengineObjects = new Container(Enums.type.objectchange);

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
            //Add eventlistener
            awsClient.onOpen += new OpenHandler(openWS);
            awsClient.onReceivedMessage += new ReceiveHandler(receivedMessage);
            awsClient.onClose += new CloseHandler(closeWS);

            //Add new client to list
            wsClients.Add(awsClient);

            Console.WriteLine("New client has connected");
        }

        private static void openWS(wsClient awsClient)
        {
            Console.WriteLine("Client got ID: " + awsClient.ID);
            awsClient.send(mDatabase.getMap(11));

            //Send client UUID
            Container container = new Container(Enums.type.clientuuid);
            container.UUID = awsClient.ID;
            awsClient.send(container);

            //create vehicle
            engineObject obj = new engineObject(awsClient.ID, "fire", new position(1, 1, 1), new rotation());

            mengineObjects.add(obj);

            //Send new vehicle to all clients
            container = new Container(Enums.type.objectchange);
            container.add(obj);
            broadcastWS(container);

            //Send all vehicles to the new client
            awsClient.send(mengineObjects);
        }

        private static void closeWS(wsClient awsClient)
        {
            wsClients.Remove(awsClient);

            foreach (engineObject eObj in mengineObjects.objects)
            {
                if (eObj.uuid == awsClient.ID)
                {
                    Container container = new Container(Enums.type.objectdelete);
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
            Enums.type objType = JSON.getType(aMessage);
            if (objType == Enums.type.setobject)
            {
                object jsonObj = JSON.deserialize(aMessage);

                Container container = new Container(Enums.type.objectchange);
                engineObject obj = (engineObject)jsonObj;
                obj.uuid = awsClient.ID;
                container.add(optimizeJSON(obj));
                broadcastWS(container, awsClient);
            }
        }

        private static engineObject optimizeJSON(engineObject aObject)
        {
            string model = null;
            position position = new position();
            rotation rotation = new rotation();

            foreach (engineObject eObj in mengineObjects.objects)
            {
                if (eObj.uuid == aObject.uuid)
                {
                    if (eObj.model != aObject.model && aObject.model != string.Empty)
                    {
                        model = aObject.model;
                        eObj.model = model;
                    }

                    //Position
                    if (aObject.position != null)
                    {
                        if (eObj.position.x != aObject.position.x)
                        {
                            position.x = aObject.position.x;
                            eObj.position.x = position.x;
                        }
                        else
                        {
                            position.x = null;
                        }

                        if (eObj.position.y != aObject.position.y)
                        {
                            position.y = aObject.position.y;
                            eObj.position.y = position.y;
                        }
                        else
                        {
                            position.y = null;
                        }

                        if (eObj.position.z != aObject.position.z)
                        {
                            position.z = aObject.position.z;
                            eObj.position.z = position.z;
                        }
                        else
                        {
                            position.z = null;
                        }
                    }

                    //rotation
                    if (aObject.rotation != null)
                    {
                        if (eObj.rotation.x != aObject.rotation.x)
                        {
                            rotation.x = aObject.rotation.x;
                            eObj.rotation.x = rotation.x;
                        }
                        else
                        {
                            rotation.x = null;
                        }

                        if (eObj.rotation.y != aObject.rotation.y)
                        {
                            rotation.y = aObject.rotation.y;
                            eObj.rotation.y = rotation.y;
                        }
                        else
                        {
                            rotation.y = null;
                        }

                        if (eObj.rotation.z != aObject.rotation.z)
                        {
                            rotation.z = aObject.rotation.z;
                            eObj.rotation.z = rotation.z;
                        }
                        else
                        {
                            rotation.z = null;
                        }
                    }
                    break;
                }
            }

            if (position.x == null && position.y == null && position.z == null)
            {
                position = null;
            }

            if (rotation.x == null && rotation.y == null && rotation.z == null)
            {
                rotation = null;
            }

            return new engineObject(aObject.uuid, model, position, rotation);
        }
    }
}
