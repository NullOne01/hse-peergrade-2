using System;
using HSEPeergrade2.Localization;

namespace HSEPeergrade2
{
    /// <summary>
    ///     Exception that takes localized key as a message.
    /// </summary>
    public class LocalizedException : Exception
    {
        public LocalizedException(string msg) : base(LocalizedMessage(msg))
        {
        }

        protected static string LocalizedMessage(string key)
        {
            return LocalizationManager.getInstance().GetLocalizedValue(key);
        }
    }
}