using System;

namespace SairServer
{
    public class Model
    {
        private string mName = "";
        private int mX = 0;
        private int mY = 0;
        private int mZ = 0;
        private double mRotation = 0.0;

        public Model(string aName, int aX, int aY, int aZ, double aRotation)
        {
            name = aName;
            mX = aX;
            mY = aY;
            mZ = aZ;
            mRotation = aRotation;
        }

        #region properties
        public string name
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

        public int x
        {
            get
            {
                return mX;
            }
            set
            {
                mX = value;
            }
        }

        public int y
        {
            get
            {
                return mY;
            }
            set
            {
                mY = value;
            }
        }

        public int z
        {
            get
            {
                return mZ;
            }
            set
            {
                mZ = value;
            }
        }

        public double rotation
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
        #endregion
    }
}
