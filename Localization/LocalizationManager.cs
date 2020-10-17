using System;
using HSEPeergrade2;
using HSEPeergrade2.Extensions;

namespace HSEPeergrade2.Localization
{
    public class LocalizationManager
    {
        private static LocalizationManager instance;
        private DefaultLocalization[] localizations = new[] {new DefaultLocalization()};
        private int currentLocalNum = 0;

        public static LocalizationManager getInstance()
        {
            if (instance == null)
                instance = new LocalizationManager();
            
            return instance;
        }

        public void SetLocalization(int localNum)
        {
            currentLocalNum = localNum;
        }

        public string GetLocalizedValue(string key, params object[] argsFormat)
        {
            return localizations[currentLocalNum].localDict[key].BetterFormat(argsFormat);
        }
        
        public string GetLocalizedFormat(string key, params object[] argsFormat)
        {
            return localizations[currentLocalNum].formatDict[key].BetterFormat(argsFormat);
        }
    }
}