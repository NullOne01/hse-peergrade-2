using System.Buffers.Text;
using System.Text.RegularExpressions;
using HSEPeergrade2.Extensions;
using HSEPeergrade2.FileUtilities;

namespace HSEPeergrade2.Commands
{
    public class DirectoryChooseCommand : Command
    {
        //Example for regex: cd "example.txt"
        private string fullRegStr = "^{0} \"[^\"]*\"$";

        //Example for regex: ""
        private string quotesRegStr = "\".*\"";

        private string newPath = "";

        public DirectoryChooseCommand(string name) : base(name)
        {
            fullRegStr = fullRegStr.BetterFormat(name);
        }

        public override void Execute()
        {
            PathTracker.GetInstance().SetUpPath(newPath);
        }

        public override void TakeParameters(string line)
        {
            string path = Regex.Match(line, quotesRegStr).Value;
            // Removing quotes.
            path = path.RemoveFirstLast();
            newPath = path;
        }

        public override bool ValidateParams(string line)
        {
            try
            {
                if (!Regex.IsMatch(line, fullRegStr))
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
                path = Regex.Match(line, quotesRegStr).Value;
                // Removing quotes.
                path = path.RemoveFirstLast();
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (!PathTracker.IsPathValid(path))
            {
                throw new InvalidPathException();
            }

            return true;
        }
    }
}