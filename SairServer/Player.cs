using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SairServer
{
    public class Player
    {
        private wsClient mWsClient;
        private string mName;

        public Player(wsClient aWsClient)
        {
            mWsClient = aWsClient;
        }

        # region properties
        public wsClient wsClient
        {
            get
            {
                return mWsClient;
            }
        }

        public string Name
        {
            get
            {
                return mName;
            }
            set
            {
                mName = value;
            }
        }
        #endregion
    }
}
