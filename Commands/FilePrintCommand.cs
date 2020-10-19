using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using HSEPeergrade2.Extensions;
using HSEPeergrade2.FileUtilities;

namespace HSEPeergrade2.Commands
{
    public class FilePrintCommand : Command
    {
        private static readonly Encoding defaultEncoding = Encoding.UTF8;
        
        private string filePath;
        private Encoding currentEncoding = defaultEncoding;

        public FilePrintCommand(string name) : base(name)
        {
        }

        public override void Execute()
        {
            MethodsOutput.PrintFileEncoding(PathTracker.CombineRelativePath(filePath), currentEncoding);
        }

        public override void TakeParameters(string line)
        {
            string[] arguments = ParsingUtilities.GetQuoteArguments(line);
            // First argument in quotes (path).
            filePath = arguments[0];

            // Read user's typed encoding. Otherwise use default encoding.
            if (ParsingUtilities.HasTwoParam(name, line))
            {
                // Second argument in quotes (encoding).
                currentEncoding = EncodingUtilities.dictStrEncoding[arguments[1]];
            }
            else
            {
                currentEncoding = defaultEncoding;
            }
        }

        public override bool ValidateParams(string line)
        {
            // Print command can have 1 option or 2 options.
            try
            {
                if (!(ParsingUtilities.HasOneParam(name, line) ||
                      ParsingUtilities.HasTwoParam(name, line)))
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
                string[] arguments = ParsingUtilities.GetQuoteArguments(line);
                // User has not specified encoding.
                if (!ParsingUtilities.HasOneParam(name, line))
                {
                    // Trying to find specified encoding.
                    var encodingStr = arguments[1];
                    if (!EncodingUtilities.dictStrEncoding.ContainsKey(encodingStr))
                        throw new InvalidEncodingException();
                }

                path = arguments[0];
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            // Check if file exists.
            if (!PathTracker.IsFilePathValid(path))
            {
                throw new InvalidPathException("FILE_NOT_FOUND");
            }

            return true;
        }
    }
}