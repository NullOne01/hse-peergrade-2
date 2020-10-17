using System;
using System.IO;

namespace HSEPeergrade2
{
    public abstract class Command
    {
        protected string name;

        public Command(string name)
        {
            this.name = name;
        }
        
        public abstract void Execute();
        public abstract void TakeParameters(string line);
        public abstract bool ValidateParams(string line);
    }
}