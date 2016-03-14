using System;

namespace SairServer
{
    public class engineObject
    {
        private string mModel;
        private position mPosition;
        private rotation mRotation;
        private string mUUID;

        public engineObject(string aUUID, string aModel, position aPosition, rotation aRotation)
        {
            mUUID = aUUID;
            mModel = aModel;
            mPosition = aPosition;
            mRotation = aRotation;
        }

        #region properties
        internal string model
        {
            get
            {
                return mModel;
            }
            set
            {
                mModel = value;
            }
        }

        internal string uuid
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

        internal position position
        {
            get
            {
                return mPosition;
            }
            set
            {
                mPosition = value;
            }
        }

        internal rotation rotation
        {
            get
            {
                return mRotation;
            }
            set
            {
                mRotation = value;
            }
        }

        public string m
        {
            get
            {
                return mModel;
            }
            set
            {
                mModel = value;
            }
        }

        public position p
        {
            get
            {
                return mPosition;
            }
            set
            {
                mPosition = value;
            }
        }

        public rotation r
        {
            get
            {
                return mRotation;
            }
            set
            {
                mRotation = value;
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
