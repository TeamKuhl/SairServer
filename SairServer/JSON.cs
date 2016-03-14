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
                string typeString = Convert.ToString(dynamic.type);
                Enums.type typeEnum = (Enums.type)Enum.Parse(typeof(Enums.type), typeString, true);

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
