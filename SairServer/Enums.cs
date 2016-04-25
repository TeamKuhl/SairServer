using System;

namespace SairServer
{
    public static class Enums
    {
        public enum Null { };

        public enum Namespace
        {
            System = 0,
            User = 1,
            Lobby = 2,
            Game = 3
        };

        public enum System
        {
            unknown = 0,
            Message = 1,
            GetUUID = 2,
            UUID = 3
        };

        public enum User
        {
            SetName = 0
        };

        public enum Lobby
        {
            GetLobby = 0,
            Lobby = 1,
            GetLobbies = 2,
            Lobbies = 3,
            CreateLobby = 4,
            LobbyCreated = 5,
            JoinLobby = 6,
            LobbyJoined = 7,
            LeaveLobby = 8,
            LobbyLeft = 9,
            CloseLobby = 10
        };

        public enum Game
        {
            StartGame = 0
        };

        public enum message_class
        {
            Info = 0,
            Success = 1,
            Warning = 2,
            Error = 3
        };
    }
}
