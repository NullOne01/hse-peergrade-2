using System.Collections.Generic;

namespace HSEPeergrade2.Extensions
{
    public static class ListExtension
    {
        public static void Pop<T>(this List<T> list)
        {
            if (list.Count >= 1)
                list.RemoveAt(list.Count - 1);
        }
    }
}