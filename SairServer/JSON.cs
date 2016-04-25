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

        public static Container deserialize(string aSerializedObject)
        {
            if (!string.IsNullOrWhiteSpace(aSerializedObject))
            {
                Container obj = JsonConvert.DeserializeObject<Container>(aSerializedObject);

                return obj;
            }

            return null;
        }

        public static Enums.Namespace? getNamespace(string aSerializedObject)
        {
            if (!string.IsNullOrWhiteSpace(aSerializedObject))
            {
                dynamic dynamic = JsonConvert.DeserializeObject(aSerializedObject);
                string type = Convert.ToString(dynamic.t);

                string[] splitType = type.Split('_');
                int Namespace = Convert.ToInt16(splitType[0]);

                return (Enums.Namespace)Namespace;
            }

            return null;
        }

        public static Enums.System? getSystem(string aSerializedObject)
        {
            if (!string.IsNullOrWhiteSpace(aSerializedObject))
            {
                dynamic dynamic = JsonConvert.DeserializeObject(aSerializedObject);
                string type = Convert.ToString(dynamic.t);

                string[] splitType = type.Split('_');
                int system = Convert.ToInt16(splitType[1]);

                return (Enums.System)system;
            }

            return null;
        }

        public static Enums.User? getUser(string aSerializedObject)
        {
            if (!string.IsNullOrWhiteSpace(aSerializedObject))
            {
                dynamic dynamic = JsonConvert.DeserializeObject(aSerializedObject);
                string type = Convert.ToString(dynamic.t);

                string[] splitType = type.Split('_');
                int user = Convert.ToInt16(splitType[1]);

                return (Enums.User)user;
            }

            return null;
        }

        public static Enums.Lobby? getLobby(string aSerializedObject)
        {
            if (!string.IsNullOrWhiteSpace(aSerializedObject))
            {
                dynamic dynamic = JsonConvert.DeserializeObject(aSerializedObject);
                string type = Convert.ToString(dynamic.t);

                string[] splitType = type.Split('_');
                int lobby = Convert.ToInt16(splitType[1]);

                return (Enums.Lobby)lobby;
            }

            return null;
        }

        public static Enums.Game? getGame(string aSerializedObject)
        {
            if (!string.IsNullOrWhiteSpace(aSerializedObject))
            {
                dynamic dynamic = JsonConvert.DeserializeObject(aSerializedObject);
                string type = Convert.ToString(dynamic.t);

                string[] splitType = type.Split('_');
                int game = Convert.ToInt16(splitType[1]);

                return (Enums.Game)game;
            }

            return null;
        }
    }
}
