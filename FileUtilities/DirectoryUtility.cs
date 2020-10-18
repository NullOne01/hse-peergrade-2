using System.IO;

namespace HSEPeergrade2.FileUtilities
{
    public static class DirectoryUtility
    {
        /// <summary>
        /// Get all file names in <paramref name="path"/>
        /// </summary>
        /// <param name="path"> Path where we search for file names. </param>
        /// <returns> File names. </returns>
        public static string[] GetFileNames(string path)
        {
            string[] fileArr = Directory.GetFiles(path);
            for (int i = 0; i < fileArr.Length; i++)
            {
                fileArr[i] = Path.GetFileName(fileArr[i]);
            }

            return fileArr;
        }
        
        /// <summary>
        /// Get all directory names in <paramref name="path"/>
        /// </summary>
        /// <param name="path"> Path where we search for directory names. </param>
        /// <returns> Directory names. </returns>
        public static string[] GetDirectoriesNames(string path)
        {
            string[] fileArr = Directory.GetDirectories(path);
            for (int i = 0; i < fileArr.Length; i++)
            {
                fileArr[i] = Path.GetFileName(fileArr[i]);
            }

            return fileArr;
        }
    }
}