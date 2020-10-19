using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Security;
using System.Text;

namespace HSEPeergrade2.FileUtilities
{
    public static class DirFileUtilities
    {
        /// <summary>
        /// Get all file names in directory (<paramref name="path"/>).
        /// </summary>
        /// <param name="path"> Path where we search for file names. </param>
        /// <returns> File names. </returns>
        /// <exception cref="InvalidPathException"> Localized invalid path exception. </exception>
        /// <exception cref="AccessException"> Localized no access exception. </exception>
        public static string[] GetFileNames(string path)
        {
            try
            {
                string[] fileArr = Directory.GetFiles(path);
                for (int i = 0; i < fileArr.Length; i++)
                {
                    fileArr[i] = Path.GetFileName(fileArr[i]);
                }

                return fileArr;
            }
            catch (ArgumentException)
            {
                throw new InvalidPathException();
            }
            catch (DirectoryNotFoundException)
            {
                throw new InvalidPathException("DIR_NOT_FOUND");
            }
            catch (IOException)
            {
                throw new InvalidPathException();
            }
            catch (SecurityException)
            {
                throw new AccessException();
            }
            catch (UnauthorizedAccessException)
            {
                throw new AccessException();
            }
        }

        /// <summary>
        /// Get all directory names in directory (<paramref name="path"/>).
        /// </summary>
        /// <param name="path"> Path where we search for directory names. </param>
        /// <returns> Directory names. </returns>
        /// <exception cref="InvalidPathException"> Localized invalid path exception. </exception>
        /// <exception cref="AccessException"> Localized no access exception. </exception>
        public static string[] GetDirectoriesNames(string path)
        {
            try
            {
                string[] fileArr = Directory.GetDirectories(path);
                for (int i = 0; i < fileArr.Length; i++)
                {
                    fileArr[i] = Path.GetFileName(fileArr[i]);
                }

                return fileArr;
            }
            catch (ArgumentException)
            {
                throw new InvalidPathException();
            }
            catch (DirectoryNotFoundException)
            {
                throw new InvalidPathException("DIR_NOT_FOUND");
            }
            catch (IOException)
            {
                throw new InvalidPathException();
            }
            catch (SecurityException)
            {
                throw new AccessException();
            }
            catch (UnauthorizedAccessException)
            {
                throw new AccessException();
            }
        }

        /// <summary>
        /// Reads file (<paramref name="path"/>) by lines using <paramref name="encoding"/>.
        /// </summary>
        /// <param name="path"> Path to file. </param>
        /// <param name="encoding"> Chosen encoding to read. </param>
        /// <returns> Lines of file. </returns>
        /// <exception cref="InvalidPathException"> Localized invalid path exception. </exception>
        /// <exception cref="AccessException"> Localized no access exception. </exception>
        public static string[] FileReadLines(string path, Encoding encoding)
        {
            try
            {
                return File.ReadAllLines(path, encoding);
            }
            catch (ArgumentException)
            {
                throw new InvalidPathException();
            }
            catch (FileNotFoundException)
            {
                throw new InvalidPathException("FILE_NOT_FOUND");
            }
            catch (DirectoryNotFoundException)
            {
                throw new InvalidPathException("DIR_NOT_FOUND");
            }
            catch (IOException)
            {
                throw new InvalidPathException();
            }
            catch (SecurityException)
            {
                throw new AccessException();
            }
            catch (UnauthorizedAccessException)
            {
                throw new AccessException();
            }
        }

        /// <summary>
        /// Moves file (<paramref name="pathFromFile"/>) to directory (<paramref name="pathToDir"/>).
        /// </summary>
        /// <param name="pathFromFile"> File that will be moved. </param>
        /// <param name="pathToDir"> Destination folder to move file. </param>
        /// <exception cref="InvalidPathException"> Localized invalid path exception. </exception>
        /// <exception cref="AccessException"> Localized no access exception. </exception>
        public static void MoveFileToDir(string pathFromFile, string pathToDir)
        {
            try
            {
                string fileName = Path.GetFileName(pathFromFile);
                string pathToFile = Path.Combine(pathToDir, fileName);
                File.Move(pathFromFile, pathToFile);
            }
            catch (UnauthorizedAccessException)
            {
                throw new AccessException();
            }
            catch (ArgumentException)
            {
                throw new InvalidPathException();
            }
            catch (PathTooLongException)
            {
                throw new InvalidPathException();
            }
            catch (DirectoryNotFoundException)
            {
                throw new InvalidPathException("DIR_NOT_FOUND");
            }
            catch (FileNotFoundException)
            {
                throw new InvalidPathException("MOVE_FILE_DOESNT_EXIST");
            }
            catch (IOException)
            {
                throw new InvalidPathException("MOVE_FILE_ALREADY_EXISTS");
            }
            catch (NotSupportedException)
            {
                throw new InvalidPathException();
            }
        }

        /// <summary>
        /// Deletes file (<paramref name="path"/>.
        /// </summary>
        /// <param name="path"> Path of deleted file. </param>
        /// <exception cref="InvalidPathException"> Localized invalid path exception. </exception>
        /// <exception cref="AccessException"> Localized no access exception. </exception>
        public static void DeleteFile(string path)
        {
            try
            {
                File.Delete(path);
            }
            catch (ArgumentException)
            {
                throw new InvalidPathException();
            }
            catch (DirectoryNotFoundException)
            {
                throw new InvalidPathException("DIR_NOT_FOUND");
            }
            catch (FileNotFoundException)
            {
                throw new InvalidPathException("FILE_NOT_FOUND");
            }
            catch (IOException)
            {
                throw new InvalidPathException();
            }
            catch (NotSupportedException)
            {
                throw new InvalidPathException();
            }
            catch (UnauthorizedAccessException)
            {
                throw new AccessException();
            }
        }

        /// <summary>
        /// Creates file (<paramref name="path"/>) and writes <paramref name="text"/>
        /// into it using <paramref name="encoding"/> 
        /// </summary>
        /// <param name="path"> Path where file should be created. </param>
        /// <param name="text"> Some text to write into the file. </param>
        /// <param name="encoding"> Encoding that we use to write into the file. </param>
        /// <exception cref="InvalidPathException"> Localized invalid path exception. </exception>
        /// <exception cref="AccessException"> Localized no access exception. </exception>
        public static void CreateAndWriteFile(string path, string text, Encoding encoding)
        {
            try
            {
                File.WriteAllText(path, text, encoding);
            }
            catch (ArgumentException)
            {
                throw new InvalidPathException();
            }
            catch (DirectoryNotFoundException)
            {
                throw new InvalidPathException("DIR_NOT_FOUND");
            }
            catch (FileNotFoundException)
            {
                throw new InvalidPathException("FILE_NOT_FOUND");
            }
            catch (IOException)
            {
                throw new InvalidPathException();
            }
            catch (NotSupportedException)
            {
                throw new InvalidPathException();
            }
            catch (UnauthorizedAccessException)
            {
                throw new AccessException();
            }
        }

        /// <summary>
        /// Concatenate files (<paramref name="paths"/>) and print them.
        /// </summary>
        /// <param name="paths"> Files' paths. </param>
        public static void PrintConcatFiles(params string[] paths)
        {
            List<string> fileResList = new List<string>();
            foreach (var path in paths)
            {
                fileResList.AddRange(FileReadLines(path, Encoding.UTF8));
            }
            
            MethodsOutput.PrintArray(fileResList.ToArray());
        }
    }
}