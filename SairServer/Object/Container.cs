using System;
using System.Collections.Generic;

namespace SairServer
{
    public class Container
    {
        private int mType = 0;
        private List<engineObject> mObjects;
        private string mUUID;

        public Container(Enums.type aType)
        {
            mType = (int)aType;
        }

        public void add(engineObject aObject)
        {
            if (mObjects == null)
            {
                mObjects = new List<engineObject>();
            }

            mObjects.Add(aObject);
        }

        public void delete(engineObject aEngineObject)
        {
            mObjects.Remove(aEngineObject);
        }

        public void delete(string aUUID)
        {
            foreach (engineObject obj in mObjects)
            {
                if (obj.uuid == aUUID)
                {
                    delete(obj);
                }
            }
        }

        #region properties
        internal int type
        {
            get
            {
                return mType;
            }
        }

        internal List<engineObject> objects
        {
            get
            {
                return mObjects;
            }
        }

        internal string UUID
        {
            get
            {
                return mUUID;
            }
            set
            {
                mUUID = value;
            }
        }

        public int t
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

        public List<engineObject> o
        {
            get
            {
                return mObjects;
            }
            set
            {
                mObjects = value;
            }
        }

        public string u
        {
            get
            {
                return mUUID;
            }
            set
            {
                mUUID = value;
            }
        }
        #endregion
    }
}
