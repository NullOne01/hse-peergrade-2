using System.Text.RegularExpressions;
using HSEPeergrade2.FileUtilities;
using HSEPeergrade2.Localization;

namespace HSEPeergrade2.Commands
{
    public class LocalizationChangeCommand : Command
    {
        public LocalizationChangeCommand(string name) : base(name)
        {
        }

        public override void Execute()
        {
            LocalizationManager.getInstance().SwitchLocalization();
            MethodsOutput.ClearConsole();
            new HelpCommand("help").Execute();
        }

        public override void TakeParameters(string line)
        {
        }

        public override bool ValidateParams(string line)
        {
            // Checking if command was written without params.
            try
            {
                if (!ParsingUtilities.HasNoParam(name, line))
                    return false;
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            return true;
        }
    }
}