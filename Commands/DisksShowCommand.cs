using System.IO;

namespace HSEPeergrade2.Commands
{
    public class DisksShowCommand : Command
    {
        public override void Execute()
        {
            string[] drives = Directory.GetLogicalDrives();
            MethodsOutput.PrintArray(drives);
        }

        public override void TakeParameters(string line)
        {
        }

        public override bool ValidateParams(string line)
        {
            return true;
        }

        public DisksShowCommand(string name) : base(name)
        {
            this.name = name;
        }
    }
}