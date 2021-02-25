using System;
using System.IO;
using System.Text.RegularExpressions;
using HSEPeergrade2.FileUtilities;

namespace HSEPeergrade2.Commands
{
    public class DisksShowCommand : Command
    {
        public DisksShowCommand(string name) : base(name)
        {
            this.name = name;
        }

        public override void Execute()
        {
            string[] drives = Directory.GetLogicalDrives();
            MethodsOutput.PrintArray(drives);
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

            // Checking if getting logical drives if possible.
            try
            {
                Directory.GetLogicalDrives();
                return true;
            }
            catch (IOException)
            {
                throw new InvalidPathException();
            }
            catch (UnauthorizedAccessException)
            {
                throw new AccessException();
            }
        }
    }
}