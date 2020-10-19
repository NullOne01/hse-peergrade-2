using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using HSEPeergrade2.Extensions;
using HSEPeergrade2.FileUtilities;

namespace HSEPeergrade2.Commands
{
    public class FilePrintCommand : Command
    {
        private string filePath;
        private static readonly Encoding defaultEncoding = Encoding.UTF8;
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
            // First argument in quotes (path).
            filePath = ParsingUtilities.GetQuoteArguments(line)[0];

            // Read user's typed encoding. Otherwise use default encoding.
            if (ParsingUtilities.HasTwoParam(name, line))
            {
                // Second argument in quotes (encoding).
                string encodingStr = ParsingUtilities.GetQuoteArguments(line)[1];
                currentEncoding = EncodingUtilities.dictStrEncoding[encodingStr];
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
                if (ParsingUtilities.HasOneParam(name, line))
                {
                    if (arguments.Length != 1)
                        return false;
                }
                else
                {
                    if (arguments.Length != 2)
                        return false;

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
                throw new InvalidPathException();
            }

            return true;
        }
    }
}