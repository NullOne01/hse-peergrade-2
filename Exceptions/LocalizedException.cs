using System;
using HSEPeergrade2.Localization;

namespace HSEPeergrade2
{
    /// <summary>
    /// Exception that takes localized key as a message.
    /// </summary>
    public class LocalizedException : Exception
    {
        protected static string LocalizedMessage(string key) =>
            LocalizationManager.getInstance().GetLocalizedValue(key);

        public LocalizedException(string msg) : base(LocalizedMessage(msg))
        {
            
        }
    }
}