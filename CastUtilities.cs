using System;

namespace HSEPeergrade2
{
    public class CastUtilities
    {
        public static bool CanBeInt(string word)
        {
            return int.TryParse(word, out int temp);
        }
        
        public static bool CanBeDouble(string word)
        {
            return double.TryParse(word, out double temp);
        }

        public static bool CheckIsCorrectType(string word, Type type)
        {
            if (type == typeof(int))
                return CanBeInt(word);
            if (type == typeof(double))
                return CanBeDouble(word);

            return type == typeof(string);
        }
    }
}