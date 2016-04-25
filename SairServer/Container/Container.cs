using System;
using System.Collections.Generic;

namespace SairServer
{
    public class Container
    {
        private string mType = null;
        private Enums.message_class? mMessage_class = null;
        private string mMessage = null;
        private string mName = null;

        internal Container(Enums.Namespace aNamespace, Enums.System aSystem)
        {
            mType = (int)aNamespace + "_" + (int)aSystem;
        }

        internal void addMessage(Enums.message_class? aMessage_class, string aMessage)
        {
            mMessage_class = aMessage_class;
            mMessage = aMessage;
        }

        #region internal properties
        internal string Name
        {
            get
            {
                return mName;
            }
        }
        #endregion

        #region JSON properties
        public string t
        {
            get
            {
                return mType;
            }
            set
            {
                mType = value;
            }
        }

        public string c
        {
            get
            {
                return ((int)mMessage_class).ToString();
            }
        }

        public string m
        {
            get
            {
                return mMessage;
            }
        }

        public string n
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
