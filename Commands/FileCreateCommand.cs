using System.Text;
using System.Text.RegularExpressions;
using HSEPeergrade2.FileUtilities;

namespace HSEPeergrade2.Commands
{
    public class FileCreateCommand : Command
    {
        private static readonly Encoding defaultEncoding = Encoding.UTF8;
        private Encoding currentEncoding = defaultEncoding;

        private string filePath;
        private string someText;

        public FileCreateCommand(string name) : base(name)
        {
        }

        public override void Execute()
        {
            DirFileUtilities.CreateAndWriteFile(filePath, someText, currentEncoding);
        }

        public override void TakeParameters(string line)
        {
            string[] arguments = ParsingUtilities.GetQuoteArguments(line);
            filePath = PathTracker.CombineRelativePath(arguments[0]);
            someText = arguments[1];

            // Selecting user's encoding.
            currentEncoding = ParsingUtilities.HasThreeParam(name, line)
                ? EncodingUtilities.dictStrEncoding[arguments[2]]
                : defaultEncoding;
        }

        public override bool ValidateParams(string line)
        {
            // Print command can have 2 or 3 options.
            try
            {
                if (!(ParsingUtilities.HasTwoParam(name, line) ||
                      ParsingUtilities.HasThreeParam(name, line)))
                    return false;
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            string[] arguments = ParsingUtilities.GetQuoteArguments(line);
            string path = PathTracker.CombineRelativePath(arguments[0]);

            // Check if file already exists.
            if (PathTracker.IsFilePathValid(path))
            {
                throw new InvalidPathException("FILE_ALREADY_EXISTS");
            }

            // Check if chosen encoding is correct.
            try
            {
                if (ParsingUtilities.HasThreeParam(name, line))
                {
                    if (!EncodingUtilities.dictStrEncoding.ContainsKey(arguments[2]))
                    {
                        throw new InvalidEncodingException();
                    }
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            return true;
        }
    }
}