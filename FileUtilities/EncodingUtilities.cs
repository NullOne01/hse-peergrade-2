using System.Collections.Generic;
using System.Text;

namespace HSEPeergrade2.FileUtilities
{
    public class EncodingUtilities
    {
        public static Dictionary<string, Encoding> dictStrEncoding = new Dictionary<string, Encoding>()
        {
            {"UTF-8", Encoding.UTF8},
            {"UTF-7", Encoding.UTF7},
            {"UTF-32", Encoding.UTF32},
            {"ASCII", Encoding.ASCII}
        };
    }
}