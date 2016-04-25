using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SairServer
{
    public class GameHandler
    {
        private wsClientFactory mWsClientFactory;
        private List<Player> mPlayers;
        private List<Lobby> mLobbies;

        public GameHandler(wsClientFactory aWsClientFactory)
        {
            mPlayers = new List<Player>();
            mLobbies = new List<Lobby>();
            mWsClientFactory = aWsClientFactory;
        }

        public void addPlayer(wsClient aWsClient)
        {
            Player player = new Player(aWsClient);
            mPlayers.Add(player);
        }

        public void setName(Container aContainer, wsClient aWsClient)
        {
            Player player = getPlayer(aWsClient);

            player.Name = aContainer.Name;
        }

        private Player getPlayer(wsClient aWsClient)
        {
            foreach (Player player in mPlayers)
            {
                if (player.wsClient.UUID == aWsClient.UUID)
                {
                    return player;
                }
            }

            return null;
        }

        public void getLobbies(wsClient aWsClient)
        {
            Container container = new Container(Enums.Namespace.Lobby, Enums.Lobby.Lobbies);
            container.Lobbies = mLobbies;
            aWsClient.send(JSON.serialize(container));
        }
    }
}
