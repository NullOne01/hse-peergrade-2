using System;
using HSEPeergrade2.FileUtilities;
using HSEPeergrade2.Localization;

namespace HSEPeergrade2
{
    public static class MethodsInput
    {
        public static string ReadString()
        {
            return Console.ReadLine();
        }

        public static string ReadStringPrefix(string prefix)
        {
            MethodsOutput.PrintString(prefix);
            
            return Console.ReadLine();
        }

        public static string ReadStringPrefixPath()
        {
            return ReadStringPrefix(LocalizationManager.getInstance().
                GetLocalizedFormat("CONSOLE_PATH_INPUT_PREFIX",PathTracker.GetInstance()));
        }
    }
}