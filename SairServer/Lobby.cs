using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SairServer
{
    public class Lobby
    {
        private string mID = null;
        private string mName = null;
        private int mPlayer = 0;
        private int mMaxPlayer = 0;

        public Lobby(string aID, string aName, int aMaxPlayer)
        {
            mID = aID;
            mName = aName;
            mMaxPlayer = aMaxPlayer;
        }

        public void incPlayer()
        {
            mPlayer++;
        }

        public void decPlayer()
        {
            mPlayer--;
        }
        #region JSON properties
        public string i
        {
            get
            {
                return mID;
            }
        }

        public string n
        {
            get
            {
                return mName;
            }
        }

        public string p
        {
            get
            {
                return mPlayer.ToString();
            }
        }

        public string m
        {
            get
            {
                return mMaxPlayer.ToString();
            }
        }
        #endregion
    }
}
