using System;

namespace HSEPeergrade2.Extensions
{
    public static class StringExtension
    {
        /// <summary>
        /// Default format methods but with no FormatException if no arguments.
        /// </summary>
        /// <param name="str"> String to format. </param>
        /// <param name="args"> Arguments for formatting. </param>
        /// <returns></returns>
        public static string BetterFormat(this string str, params object[] args)
        {
            if (args.Length == 0)
                return str;
            return string.Format(str, args);
        }
        
        /// <summary>
        /// Can string <paramref name="word"/> be parsed as int?
        /// </summary>
        /// <param name="word"> Some string. </param>
        /// <returns> True - if can be parsed as int. Otherwise - False. </returns>
        public static bool CanBeInt(this string word)
        {
            return int.TryParse(word, out int temp);
        }
        
        /// <summary>
        /// Can string <paramref name="word"/> be parsed as double?
        /// </summary>
        /// <param name="word"> <inheritdoc cref="CanBeInt"/> </param>
        /// <returns> True - if can be parsed as double. Otherwise - False. </returns>
        public static bool CanBeDouble(this string word)
        {
            return double.TryParse(word, out double temp);
        }

        /// <summary>
        /// Removing first and last letters of <paramref name="word"/>.
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