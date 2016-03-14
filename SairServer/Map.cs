using System;
using System.Collections.Generic;

namespace SairServer
{
    public class Map
    {
        private string mType = "mapchange";
        private List<Model> mMap;

        public Map()
        {
            mMap = new List<Model>();
        }

        public void add(Model aModel)
        {
            map.Add(aModel);
        }

        #region properties
        public string type
        {
            get
            {
                return mType;
            }
        }

        public List<Model> map
        {
            get
            {
                return mMap;
            }
        }
        #endregion
    }
}
