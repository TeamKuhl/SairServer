using System;
using Newtonsoft.Json;

namespace SairServer
{
    public static class JSON
    {
        public static string serialize(object aObject)
        {
            if (aObject != null)
            {
                string serializedObject = JsonConvert.SerializeObject(aObject, Newtonsoft.Json.Formatting.None, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });
                return serializedObject;
            }

            return string.Empty;
        }

        public static Enums.type getType(string aSerializedObject)
        {
            if (!string.IsNullOrWhiteSpace(aSerializedObject))
            {
                dynamic dynamic = JsonConvert.DeserializeObject(aSerializedObject);
                int typeInt = Convert.ToInt16(dynamic.t);

                Enums.type typeEnum = (Enums.type)typeInt;

                return typeEnum;
            }

            return Enums.type.unknown;
        }

        public static object deserialize(string aSerializedObject)
        {
            if (!string.IsNullOrWhiteSpace(aSerializedObject))
            {
                engineObject obj = JsonConvert.DeserializeObject<engineObject>(aSerializedObject);

                return obj;
            }

            return null;
        }
    }
}
