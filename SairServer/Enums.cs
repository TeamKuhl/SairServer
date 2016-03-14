using System;

namespace SairServer
{
    public static class Enums
    {
        public enum type
        {
            mapchange = 1,
            objectchange = 2,
            objectdelete = 3,
            clientuuid = 4,
            setobject = 5,
            unknown = 0
        };
    }
}
