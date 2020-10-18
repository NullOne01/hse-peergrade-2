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

        /// <summary>
        /// Realization of Singleton pattern.
        /// </summary>
        /// <returns> Static object. </returns>
        public static PathTracker GetInstance()
        {
            if (instance == null)
                instance = new PathTracker();

            return instance;
        }

        /// <summary>
        /// Setting up default project location.
        /// </summary>
        public void SetUpProjectPath()
        {
            SetUpFullPath(Directory.GetCurrentDirectory());
        }

        /// <summary>
        /// Setting up relative or absolute path.
        /// </summary>
        /// <param name="path"> Relative or absolute path. </param>
        public void SetUpPath(string path)
        {
            currenPath = CombineRelativePath(path);
        }

        /// <summary>
        /// Setting up absolute path.
        /// </summary>
        /// <param name="path"> Absolute path. </param>
        public void SetUpFullPath(string path)
        {
            currenPath = path;
        }

        /// <summary>
        /// Check if directory exists by it's absolute path.
        /// </summary>
        /// <param name="path"> Absolute path. </param>
        /// <returns> True if exists. False if it doesn't. </returns>
        public static bool IsDirFullPathValid(string path)
        {
            return Directory.Exists(path);
        }

        /// <summary>
        /// Check if directory exists by it's relative or absolute path.
        /// </summary>
        /// <param name="path"> Relative or absolute path. </param>
        /// <returns> True if exists. False if it doesn't. </returns>
        public static bool IsDirPathValid(string path)
        {
            string newPath = CombineRelativePath(path);
            return Directory.Exists(newPath);
        }
        
        /// <summary>
        /// Check if file exists by it's relative or absolute path.
        /// </summary>
        /// <param name="path"> Relative or absolute path. </param>
        /// <returns> True if exists. False if it doesn't. </returns>
        public static bool IsFilePathValid(string path)
        {
            string newPath = CombineRelativePath(path);
            return File.Exists(newPath);
        }

        /// <summary>
        /// Method to use relative paths.
        /// </summary>
        /// <param name="relativePath"> Relative path. </param>
        /// <returns> Combined current path with the relative one. </returns>
        public static string CombineRelativePath(string relativePath)
        {
            return Path.GetFullPath(Path.Combine(currenPath, relativePath));
        }
        
        /// <summary>
        /// Returns current path.
        /// </summary>
        /// <returns> Current path. </returns>
        public override string ToString()
        {
            return currenPath;
        }
    }
}