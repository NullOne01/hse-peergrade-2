namespace HSEPeergrade2
{
    public class InvalidPathException : LocalizedException
    {
        public InvalidPathException() : base("INVALID_PATH")
        {
        }

        public InvalidPathException(string msg) : base(msg)
        {
        }
    }
}