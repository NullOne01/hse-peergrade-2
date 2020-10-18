namespace HSEPeergrade2
{
    public class InvalidEncodingException : LocalizedException
    {
        public InvalidEncodingException() : base("INVALID_ENCODING")
        {
            
        }

        public InvalidEncodingException(string msg) : base(msg)
        {
        }
    }
}