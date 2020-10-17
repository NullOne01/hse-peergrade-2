using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.InteropServices.ComTypes;
using HSEPeergrade2.Extensions;

namespace HSEPeergrade2.FileUtilities
{
    public class PathTracker
    {
        private static PathTracker instance;
        private static string currenPath = "";

        public static PathTracker GetInstance()
        {
            if (instance == null)
                instance = new PathTracker();

            return instance;
        }

        public void SetUpProjectPath()
        {
            SetUpFullPath(Directory.GetCurrentDirectory());
        }

        public void SetUpPath(string path)
        {
            currenPath = Path.GetFullPath(Path.Combine(currenPath, path));
        }

        public void SetUpFullPath(string path)
        {
            currenPath = path;
        }

        public static bool IsFullPathValid(string path)
        {
            return Directory.Exists(path);
        }

        public static bool IsPathValid(string path)
        {
            string newPath = Path.GetFullPath(Path.Combine(currenPath, path));
            return Directory.Exists(newPath);
        }

        public override string ToString()
        {
            return currenPath;
        }
    }
}