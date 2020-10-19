using System.Text.RegularExpressions;
using HSEPeergrade2.Extensions;

namespace HSEPeergrade2.FileUtilities
{
    public class ParsingUtilities
    {
        //Example for regex: printFile
        private static string fullRegStr0 = "^{0}$";
        
        //Example for regex: printFile "example.txt"
        private static string fullRegStr1 = "^{0} \"[^\"]*\"$";

        //Example for regex: printFile "example.txt" "UTF-8"
        private static string fullRegStr2 = "^{0} \"[^\"]*\" \"[^\"]*\"$";
        
        //Example for regex: printFile "example.txt" "UTF-8" "EXAMPLE"
        private static string fullRegStr3 = "^{0} \"[^\"]*\" \"[^\"]*\" \"[^\"]*\"$";

        //Example for regex: ""
        private static string quotesRegStr = "\".*?\"";

        /// <summary>
        /// Command passes no parameters?
        /// </summary>
        /// <param name="commandName"> Command name. </param>
        /// <param name="line"> Command line. </param>
        /// <returns> True if command line passes no parameters. Otherwise false. </returns>
        public static bool HasNoParam(string commandName, string line)
        {
            string modifiedStr = fullRegStr0.BetterFormat(commandName);
            return Regex.IsMatch(line, modifiedStr);
        }
        
        /// <summary>
        /// Command passes only 1 parameter?
        /// </summary>
        /// <param name="commandName"> Command name. </param>
        /// <param name="line"> Command line. </param>
        /// <returns> True if command line passes only 1 parameter. Otherwise false. </returns>
        public static bool HasOneParam(string commandName, string line)
        {
            string modifiedStr = fullRegStr1.BetterFormat(commandName);
            return Regex.IsMatch(line, modifiedStr);
        }

        /// <summary>
        /// Command passes only 2 parameters?
        /// </summary>
        /// <param name="commandName"> Command name. </param>
        /// <param name="line"> Command line. </param>
        /// <returns> True if command line passes only 2 parameters. Otherwise false. </returns>
        public static bool HasTwoParam(string commandName, string line)
        {
            string modifiedStr = fullRegStr2.BetterFormat(commandName);
            return Regex.IsMatch(line, modifiedStr);
        }
        
        /// <summary>
        /// Command passes only 3 parameters?
        /// </summary>
        /// <param name="commandName"> Command name. </param>
        /// <param name="line"> Command line. </param>
        /// <returns> True if command line passes only 3 parameters. Otherwise false. </returns>
        public static bool HasThreeParam(string commandName, string line)
        {
            string modifiedStr = fullRegStr3.BetterFormat(commandName);
            return Regex.IsMatch(line, modifiedStr);
        }

        /// <summary>
        /// Get list of arguments passed in <paramref name="line"/> in quotes.
        /// </summary>
        /// <param name="line"> Command line. </param>
        /// <returns> List of arguments in quotes. </returns>
        public static string[] GetQuoteArguments(string line)
        {
            MatchCollection matchesQuotes = Regex.Matches(line, quotesRegStr);
            string[] res = new string[matchesQuotes.Count];
            for (int i = 0; i < matchesQuotes.Count; i++)
            {
                res[i] = matchesQuotes[i].Value.RemoveFirstLast();
            }

            return res;
        }
        
        /// <summary>
        /// Get 1 argument passed in <paramref name="line"/> in quotes.
        /// </summary>
        /// <param name="line"> Command line. </param>
        /// <returns> One argument in quotes. </returns>
        public static string GetQuoteOneArgument(string line)
        {
            return GetQuoteArguments(line)[0];
        }
    }
}