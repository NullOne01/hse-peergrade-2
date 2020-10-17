using System;
using System.Collections.Generic;

namespace HSEPeergrade2
{
    class Program
    {
        static void Main(string[] args)
        {
            FileManager fileManager = new FileManager();
            fileManager.Start();
        }
    }
}