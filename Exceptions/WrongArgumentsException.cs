using System;
using HSEPeergrade2.Localization;

namespace HSEPeergrade2
{
    public class WrongArgumentsException : LocalizedException
    {
        public WrongArgumentsException() : base("WRONG_ARGUMENTS")
        {
        }
        
        public WrongArgumentsException(string line) : base(line)
        {
        }
    }
}