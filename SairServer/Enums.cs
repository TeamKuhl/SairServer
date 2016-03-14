using System;

namespace SairServer
{
    public static class Enums
    {
        public enum type
        {
            setobject,
            unknown
        };

        public enum sendType
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
