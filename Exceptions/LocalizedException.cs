using System;
using HSEPeergrade2.Localization;

namespace HSEPeergrade2
{
    public class LocalizedException : Exception
    {
        protected static string LocalizedMessage(string key) =>
            LocalizationManager.getInstance().GetLocalizedValue(key);

        public LocalizedException(string msg) : base(LocalizedMessage(msg))
        {
            
        }
    }
}