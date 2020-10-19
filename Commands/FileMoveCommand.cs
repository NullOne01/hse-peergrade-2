using System.Text.RegularExpressions;
using HSEPeergrade2.FileUtilities;

namespace HSEPeergrade2.Commands
{
    public class FileMoveCommand : Command
    {
        private string moveFromPath;
        private string moveToDirPath;
        
        public FileMoveCommand(string name) : base(name)
        {
        }

        public override void Execute()
        {
            DirFileUtilities.MoveFileToDir(moveFromPath, moveToDirPath);
        }

        public override void TakeParameters(string line)
        {
            string[] arguments = ParsingUtilities.GetQuoteArguments(line);
            moveFromPath = PathTracker.CombineRelativePath(arguments[0]);
            moveToDirPath = PathTracker.CombineRelativePath(arguments[1]);
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
            string moveFromArg = PathTracker.CombineRelativePath(arguments[0]);
            string moveToArg = PathTracker.CombineRelativePath(arguments[1]);

            // Check if moveFrom file exists.
            if (!PathTracker.IsFilePathValid(moveFromArg))
            {
                throw new InvalidPathException("MOVE_FILE_DOESNT_EXIST");
            }
            
            // Check if moveTo dir exists.
            if (!PathTracker.IsDirPathValid(moveToArg))
            {
                throw new InvalidPathException("WRONG_ARGUMENTS_IO");
            }
            
            // Check if moveTo file doesn't exist.
            if (PathTracker.IsFilePathValid(moveToArg))
            {
                throw new InvalidPathException("MOVE_FILE_ALREADY_EXISTS");
            }
            
            return true;
        }
    }
}