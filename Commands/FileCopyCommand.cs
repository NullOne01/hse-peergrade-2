using System;
using System.IO;
using System.Text.RegularExpressions;
using HSEPeergrade2.FileUtilities;

namespace HSEPeergrade2.Commands
{
    public class FileCopyCommand : Command
    {
        private string copyFromPath;
        private string copyToPath;

        public FileCopyCommand(string name) : base(name)
        {
        }

        public override void Execute()
        {
            try
            {
                File.Copy(copyFromPath, copyToPath);
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
                throw new InvalidPathException();
            }
            catch (FileNotFoundException)
            {
                throw new InvalidPathException();
            }
            catch (IOException)
            {
                throw new InvalidPathException();
            }
            catch (NotSupportedException)
            {
                throw new InvalidPathException();
            }
        }

        public override void TakeParameters(string line)
        {
            string[] arguments = ParsingUtilities.GetQuoteArguments(line);
            copyFromPath = PathTracker.CombineRelativePath(arguments[0]);
            copyToPath = PathTracker.CombineRelativePath(arguments[1]);
        }

        public override bool ValidateParams(string line)
        {
            try
            {
                if (!ParsingUtilities.HasTwoParam(name, line))
                {
                    return false;
                }
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            string[] arguments = ParsingUtilities.GetQuoteArguments(line);
            string copyFromArg = PathTracker.CombineRelativePath(arguments[0]);
            string copyToArg = PathTracker.CombineRelativePath(arguments[1]);

            // Check if copyFrom file exists.
            if (!PathTracker.IsFilePathValid(copyFromArg))
            {
                throw new InvalidPathException("COPY_FILE_DOESNT_EXIST");
            }
            
            // Check if copyTo file doesn't exist.
            if (PathTracker.IsFilePathValid(copyToArg))
            {
                throw new InvalidPathException("COPY_FILE_ALREADY_EXISTS");
            }
            
            return true;
        }
    }
}