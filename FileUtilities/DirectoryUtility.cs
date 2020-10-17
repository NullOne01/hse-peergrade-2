using System.IO;

namespace HSEPeergrade2.FileUtilities
{
    public class DirectoryUtility
    {
        public static string[] GetFileNames(string path)
        {
            string[] fileArr = Directory.GetFiles(path);
            for (int i = 0; i < fileArr.Length; i++)
            {
                fileArr[i] = Path.GetFileName(fileArr[i]);
            }

            return fileArr;
        }
        
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