using System;
using HSEPeergrade2.FileUtilities;
using HSEPeergrade2.Localization;

namespace HSEPeergrade2
{
    public static class MethodsInput
    {
        /// <summary>
        ///     Default read line method.
        /// </summary>
        /// <returns> Read line. </returns>
        public static string ReadString()
        {
            return Console.ReadLine();
        }

        /// <summary>
        ///     Reading string line printing some <paramref name="prefix" /> before.
        /// </summary>
        /// <param name="prefix"> Some prefix to print. </param>
        /// <returns> Read line. </returns>
        public static string ReadStringPrefix(string prefix)
        {
            MethodsOutput.PrintString(prefix);

            return Console.ReadLine();
        }

        /// <summary>
        ///     <inheritdoc cref="ReadStringPrefix" />
        ///     Uses path as prefix.
        /// </summary>
        /// <returns> Read line. </returns>
        public static string ReadStringPrefixPath()
        {
            return ReadStringPrefix(LocalizationManager.getInstance()
                .GetLocalizedFormat("CONSOLE_PATH_INPUT_PREFIX", PathTracker.GetInstance()));
        }
    }
}