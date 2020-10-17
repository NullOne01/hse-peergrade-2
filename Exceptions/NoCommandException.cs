using System;
using HSEPeergrade2.Localization;

namespace HSEPeergrade2.Exceptions
{
    public class NoCommandException : LocalizedException
    {
        public NoCommandException() : base("NO_COMMAND")
        {
        }
    }
}