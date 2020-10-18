using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using HSEPeergrade2.Extensions;
using HSEPeergrade2.FileUtilities;

namespace HSEPeergrade2.Commands
{
    public class PrintFileCommand : Command
    {
        //Example for regex: printFile "example.txt" "UTF-8"
        private string fullRegStr1 = "^{0} \"[^\"]*\"$";

        //Example for regex: printFile "example.txt" "UTF-8"
        private string fullRegStr2 = "^{0} \"[^\"]*\" \"[^\"]*\"$";

        //Example for regex: ""
        private string quotesRegStr = "\".*?\"";

        private string filePath;
        private Encoding currentEncoding = Encoding.UTF8;

        public PrintFileCommand(string name) : base(name)
        {
            fullRegStr1 = string.Format(fullRegStr1, name);
            fullRegStr2 = string.Format(fullRegStr2, name);
        }

        public override void Execute()
        {
            MethodsOutput.PrintFileEncoding(PathTracker.CombineRelativePath(filePath), currentEncoding);
        }

        public override void TakeParameters(string line)
        {
            // First argument in quotes (path).
            filePath = Regex.Matches(line, quotesRegStr)[0].Value.RemoveFirstLast();

            if (Regex.IsMatch(line, fullRegStr2))
            {
                // Second argument in quotes (encoding).
                string encodingStr = Regex.Matches(line, quotesRegStr)[1].Value.RemoveFirstLast();
                currentEncoding = EncodingUtilities.dictStrEncoding[encodingStr];
            }
        }

        public override bool ValidateParams(string line)
        {
            try
            {
                if (!(Regex.IsMatch(line, fullRegStr1) ||
                      Regex.IsMatch(line, fullRegStr2)))
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
                MatchCollection matchesQuotes = Regex.Matches(line, quotesRegStr);
                // User has not specified encoding.
                if (Regex.IsMatch(line, fullRegStr1))
                {
                    if (matchesQuotes.Count != 1)
                        return false;
                }
                else
                {
                    if (matchesQuotes.Count != 2)
                        return false;

                    // Trying to find specified encoding.
                    var encodingStr = matchesQuotes[1].Value.RemoveFirstLast();
                    if (!EncodingUtilities.dictStrEncoding.ContainsKey(encodingStr))
                        throw new InvalidEncodingException();
                }

                path = matchesQuotes[0].Value.RemoveFirstLast();
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            if (!PathTracker.IsFilePathValid(path))
            {
                throw new InvalidPathException();
            }

            return true;
        }
    }
}