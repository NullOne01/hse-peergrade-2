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

        /// <summary>
        /// Single instance of localization manager.
        /// </summary>
        /// <returns> Static single instance. </returns>
        public static LocalizationManager getInstance()
        {
            if (instance == null)
                instance = new LocalizationManager();
            
            return instance;
        }

        /// <summary>
        /// Setting localization by it's <paramref name="localNum"/>
        /// </summary>
        /// <param name="localNum"> Number of a written localization. </param>
        public void SetLocalization(int localNum)
        {
            currentLocalNum = localNum;
        }

        /// <summary>
        /// Get a localized value by it's <paramref name="key"/>
        /// </summary>
        /// <param name="key"> Key of localized value. </param>
        /// <param name="argsFormat"> Some arguments. </param>
        /// <returns> Localized value. </returns>
        public string GetLocalizedValue(string key, params object[] argsFormat)
        {
            return localizations[currentLocalNum].localDict[key].BetterFormat(argsFormat);
        }
        
        /// <summary>
        /// Get a localized format by it's <paramref name="key"/>
        /// </summary>
        /// <param name="key"> Key of localized format. </param>
        /// <param name="argsFormat"> Some arguments. </param>
        /// <returns> Localized format. </returns>
        public string GetLocalizedFormat(string key, params object[] argsFormat)
        {
            return localizations[currentLocalNum].formatDict[key].BetterFormat(argsFormat);
        }
    }
}