using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace SairServer
{
    public delegate void OpenHandler(wsClient awsClient);
    public delegate void CloseHandler(wsClient awsClient);
    public delegate void ReceiveHandler(wsClient awsClient, string aMessage);

    public class wsClient : WebSocketBehavior
    {
        public OpenHandler onOpen;
        public CloseHandler onClose;
        public ReceiveHandler onReceivedMessage;

        private string mUUID;

        public wsClient()
        {
            Program.addwsClient(this);
        }

        protected override void OnMessage(MessageEventArgs e)
        {
            if (onReceivedMessage != null) onReceivedMessage(this, e.Data);
        }

        protected override void OnClose(CloseEventArgs e)
        {
            if (onClose != null) onClose(this);
        }

        protected override void OnError(ErrorEventArgs e)
        {
            if (onClose != null) onClose(this);
        }

        protected override void OnOpen()
        {
            if (onOpen != null) onOpen(this);
        }

        public void send(string aMessage)
        {
            if (!String.IsNullOrWhiteSpace(aMessage))
            {
                Send(aMessage);
            }
        }

        public void send(object aObject)
        {
            string serializedObject = JSON.serialize(aObject);
            send(serializedObject);
        }

        public string UUID
        {
            get
            {
                return this.ID.Substring(0, 5);
            }
        }
    }
}