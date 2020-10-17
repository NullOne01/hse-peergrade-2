using System.IO;
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
            string[] dirNamesArr = DirectoryUtility.GetDirectoriesNames(PathTracker.GetInstance().ToString());
            string[] fileNamesArr = DirectoryUtility.GetFileNames(PathTracker.GetInstance().ToString());

            MethodsOutput.PrintLocalStringLine("DIRECTORIES");
            if (dirNamesArr.Length > 0)
            {
                MethodsOutput.PrintArray(dirNamesArr);
            }
            else
            {
                MethodsOutput.PrintLocalStringLine("NO_DIRECTORIES");
            }

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
            if (PathTracker.GetInstance().ToString() == "")
            {
                throw new InvalidPathException();
            }
            
            return true;
        }
    }
}