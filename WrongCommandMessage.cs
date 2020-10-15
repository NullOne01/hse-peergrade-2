namespace HSEPeergrade2
{
    public class WrongCommandMessage
    {
        private MessageType currentMsgType = MessageType.Undefined;
        public string message = "";
        public enum MessageType
        {
            Undefined,
            UnknownCommand,
            NoArgumentsLength,
            WrongArguments,
            Success
        }

        public void SetMessage(MessageType msgType, string message = "")
        {
            // If we haven't got any error message yet.
            if ((int) msgType > (int) currentMsgType)
            {
                currentMsgType = msgType;
                this.message = message;
            }
        }
    }
}