using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SairServer
{
    public class wsClientFactory
    {
        private List<wsClient> mWsClients;
        private GameHandler mGameHandler;

        public wsClientFactory()
        {
            mWsClients = new List<wsClient>();
            mGameHandler = new GameHandler();
        }

        public void broadcast(object obj)
        {
            foreach (wsClient client in mWsClients)
            {
                client.send(obj);
            }
        }

        public void broadcastWS(object obj, wsClient aClient)
        {
            foreach (wsClient client in mWsClients)
            {
                if (aClient.ID != client.ID)
                {
                    client.send(obj);
                }
            }
        }

        public void addwsClient(wsClient awsClient)
        {
            //Add eventlistener
            awsClient.onOpen += new OpenHandler(openWS);
            awsClient.onReceivedMessage += new ReceiveHandler(receivedMessage);
            awsClient.onClose += new CloseHandler(closeWS);

            //Add new client to list
            mWsClients.Add(awsClient);

            Console.WriteLine("New client has connected");
        }

        private static void openWS(wsClient awsClient)
        {
            Console.WriteLine("Client got ID: " + awsClient.UUID);
        }

        private void closeWS(wsClient awsClient)
        {
            Console.WriteLine(awsClient.UUID + " has disconnected");

            foreach (wsClient client in mWsClients)
            {
                if (client.UUID == awsClient.UUID)
                {
                    mWsClients.Remove(client);
                    break;
                }
            }
        }

        private void receivedMessage(wsClient awsClient, string aMessage)
        {
            Enums.Namespace? objNamespace = JSON.getNamespace(aMessage);
            if (objNamespace != null)
            {
                switch (objNamespace)
                {
                    case Enums.Namespace.System:
                        Enums.System? objSystem = JSON.getSystem(aMessage);
                        switch (objSystem)
                        {
                            case Enums.System.GetUUID:

                                break;
                        }
                        break;
                    case Enums.Namespace.User:
                        Enums.User? objUser = JSON.getUser(aMessage);
                        switch (objUser)
                        {
                            case Enums.User.SetName:
                                mGameHandler.SetName(JSON.deserialize(aMessage));
                                break;
                        }
                        break;
                    case Enums.Namespace.Lobby:
                        Enums.Lobby? objLobby = JSON.getLobby(aMessage);
                        switch (objLobby)
                        {
                            case Enums.Lobby.GetLobby:

                                break;
                            case Enums.Lobby.GetLobbies:

                                break;
                            case Enums.Lobby.CreateLobby:

                                break;
                            case Enums.Lobby.JoinLobby:

                                break;
                            case Enums.Lobby.LeaveLobby:

                                break;
                            case Enums.Lobby.CloseLobby:

                                break;
                        }
                        break;
                    case Enums.Namespace.Game:
                        Enums.Game? objGame = JSON.getGame(aMessage);
                        switch (objGame)
                        {
                            case Enums.Game.StartGame:

                                break;
                        }
                        break;
                }
            }
        }
    }
}
