using System;
using System.Collections.Generic;

namespace SairServer
{
    public class Container
    {
        private int mType = 0;
        private List<engineObject> mObjects;

        public Container(Enums.sendType aType)
        {
            mObjects = new List<engineObject>();
            mType = (int)aType;
        }

        public void add(engineObject aObject)
        {
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

        public int t
        {
            get
            {
                return mType;
            }
        }

        public List<engineObject> o
        {
            get
            {
                return mObjects;
            }
        }
        #endregion
    }
}
