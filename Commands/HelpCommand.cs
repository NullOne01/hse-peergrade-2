using HSEPeergrade2.Localization;

namespace HSEPeergrade2
{
    public class HelpCommand : Command
    {
        public HelpCommand(string name) : base(name)
        {
            
        }

        public override void Execute()
        {
            MethodsOutput.PrintLocalStringLine("HELP");
        }

        public override void TakeParameters(string line)
        {
            
        }

        public override bool ValidateParams(string line)
        {
            return true;
            //throw new System.NotImplementedException();
        }
    }
}