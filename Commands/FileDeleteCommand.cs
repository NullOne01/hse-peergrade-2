using System.Text.RegularExpressions;
using HSEPeergrade2.FileUtilities;

namespace HSEPeergrade2.Commands
{
    public class FileDeleteCommand : Command
    {
        private string filePath;
        
        public FileDeleteCommand(string name) : base(name)
        {
        }

        public override void Execute()
        {
            DirFileUtilities.DeleteFile(filePath);
        }

        public override void TakeParameters(string line)
        {
            string filePathArg = ParsingUtilities.GetQuoteOneArgument(line);
            filePath = PathTracker.CombineRelativePath(filePathArg);
        }

        public override bool ValidateParams(string line)
        {
            // Checking if command line has only 1 param.
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

            string filePathArg = ParsingUtilities.GetQuoteOneArgument(line);

            // Check if file exists.
            if (!PathTracker.IsFilePathValid(PathTracker.CombineRelativePath(filePathArg)))
            {
                throw new InvalidPathException("FILE_NOT_FOUND");
            }

            return true;
        }
    }
}