using System.Text.RegularExpressions;
using HSEPeergrade2.FileUtilities;

namespace HSEPeergrade2.Commands
{
    public class FileConcatCommand : Command
    {
        private string[] filePaths;

        public FileConcatCommand(string name) : base(name)
        {
        }

        public override void Execute()
        {
            DirFileUtilities.PrintConcatFiles(filePaths);
        }

        public override void TakeParameters(string line)
        {
            string[] paths = ParsingUtilities.GetQuoteArguments(line);
            for (int i = 0; i < paths.Length; i++)
            {
                paths[i] = PathTracker.CombineRelativePath(paths[i]);
            }

            filePaths = paths;
        }

        public override bool ValidateParams(string line)
        {
            // Concat command can have 1 and more options.
            try
            {
                if (!ParsingUtilities.HasAtLeastOneParam(name, line))
                {
                    return false;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            string[] paths = ParsingUtilities.GetQuoteArguments(line);
            foreach (var path in paths)
            {
                // Check if all files exist.
                if (!PathTracker.IsFilePathValid(path))
                {
                    throw new InvalidPathException("FILE_NOT_FOUND");
                }
            }
            
            return true;
        }
    }
}