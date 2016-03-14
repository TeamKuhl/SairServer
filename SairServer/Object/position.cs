using System;

namespace SairServer
{
    public class position
    {
        private double mX = 0;
        private double mY = 0;
        private double mZ = 0;

        public position()
        {
            mX = 0;
            mY = 0;
            mZ = 0;
        }

        public position(double aX, double aY, double aZ)
        {
            mX = aX;
            mY = aY;
            mZ = aZ;
        }

        #region properties
        public double x
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

        public double y
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

        public double z
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
        #endregion
    }
}
