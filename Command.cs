using System;
using System.IO;

namespace HSEPeergrade2
{
    public abstract class Command
    {
        private string name;
        public Type[][] argumentTypes;
        
        public Command(string name, params Type[][] argumentTypes)
        {
            this.name = name;
            this.argumentTypes = argumentTypes;
        }

        public abstract void Execute();

        public bool Validate(string line, WrongCommandMessage errorMsg)
        {
            string[] words = line.Split();

            if (words[0] != name)
            {
                errorMsg.SetMessage(WrongCommandMessage.MessageType.UnknownCommand, "Unknown command");
                return false;
            }
            
            foreach (Type[] argsOption in argumentTypes)
            {
                if (words.Length != 1 + argsOption.Length)
                {
                    errorMsg.SetMessage(WrongCommandMessage.MessageType.NoArgumentsLength, 
                        "No so much arguments");
                    continue;
                }

                bool hasFound = true;
                for (int i = 1; i < words.Length; i++)
                {
                    if (!CastUtilities.CheckIsCorrectType(words[i], argsOption[i - 1]))
                    {
                        errorMsg.SetMessage(WrongCommandMessage.MessageType.WrongArguments, 
                            "Arguments have wrong types");
                        hasFound = false;
                    }
                    else
                    {
                        //TODO We need to check all types. Break makes this task unreal.
                        break;
                    }
                }

                if (hasFound)
                {
                    errorMsg.SetMessage(WrongCommandMessage.MessageType.Success);
                    return true;
                }
            }

            errorMsg.SetMessage(WrongCommandMessage.MessageType.Undefined);
            return false;
        }
    }
}