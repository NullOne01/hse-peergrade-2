using System.Text.RegularExpressions;
using HSEPeergrade2.FileUtilities;

namespace HSEPeergrade2.Commands
{
    public class DirectoryChooseCommand : Command
    {
        private string newPath = "";

        public DirectoryChooseCommand(string name) : base(name)
        {
        }

        public override void Execute()
        {
            PathTracker.GetInstance().SetUpPath(newPath);
        }

        public override void TakeParameters(string line)
        {
            string path = ParsingUtilities.GetQuoteOneArgument(line);
            newPath = path;
        }

        public override bool ValidateParams(string line)
        {
            try
            {
                if (!ParsingUtilities.HasOneParam(name, line))
                {
                    return false;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            string path;
            try
            {
                path = ParsingUtilities.GetQuoteOneArgument(line);
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (!PathTracker.IsDirPathValid(path))
            {
                throw new InvalidPathException();
            }

            return true;
        }
    }
}