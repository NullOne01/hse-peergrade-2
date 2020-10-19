using System.IO;
using System.Text.RegularExpressions;
using HSEPeergrade2.FileUtilities;

namespace HSEPeergrade2.Commands
{
    public class DirectoryShowListCommand : Command
    {
        public DirectoryShowListCommand(string name) : base(name)
        {
        }

        public override void Execute()
        {
            string[] dirNamesArr = DirFileUtilities.GetDirectoriesNames(PathTracker.GetInstance().ToString());
            string[] fileNamesArr = DirFileUtilities.GetFileNames(PathTracker.GetInstance().ToString());

            MethodsOutput.PrintLocalStringLine("DIRECTORIES");
            if (dirNamesArr.Length > 0)
            {
                MethodsOutput.PrintArray(dirNamesArr);
            }
            else
            {
                MethodsOutput.PrintLocalStringLine("NO_DIRECTORIES");
            }

            MethodsOutput.SkipLine();
            
            MethodsOutput.PrintLocalStringLine("FILES");
            if (fileNamesArr.Length > 0)
            {
                MethodsOutput.PrintArray(fileNamesArr);
            }
            else
            {
                MethodsOutput.PrintLocalStringLine("NO_FILES");
            }
        }

        public override void TakeParameters(string line)
        {
        }

        public override bool ValidateParams(string line)
        {
            // Checking if command was written without params.
            try
            {
                if (!ParsingUtilities.HasNoParam(name, line))
                    return false;
            }
            catch (RegexMatchTimeoutException)
            {
                return false;
            }

            // Checking if getting directories and files is possible.
            DirFileUtilities.GetDirectoriesNames(PathTracker.GetInstance().ToString());
            DirFileUtilities.GetFileNames(PathTracker.GetInstance().ToString());

            return true;
        }
    }
}