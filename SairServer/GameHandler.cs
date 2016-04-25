using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SairServer
{
    public class GameHandler
    {
        private List<Player> mPlayers;

        public GameHandler()
        {
            mPlayers = new List<Player>();
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
    }
}
