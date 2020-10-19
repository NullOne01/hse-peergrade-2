namespace HSEPeergrade2.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        ///     Default format methods but with no FormatException if no arguments.
        /// </summary>
        /// <param name="str"> String to format. </param>
        /// <param name="args"> Arguments for formatting. </param>
        /// <returns> Formatted string. </returns>
        public static string BetterFormat(this string str, params object[] args)
        {
            if (args.Length == 0)
                return str;
            return string.Format(str, args);
        }

        /// <summary>
        ///     Removing first and last letters of <paramref name="word" />.
        /// </summary>
        /// <param name="word"> String that will be edited. </param>
        /// <returns> Edited string. </returns>
        public static string RemoveFirstLast(this string word)
        {
            word = word.Remove(0, 1);
            word = word.Remove(word.Length - 1, 1);
            return word;
        }
    }
}