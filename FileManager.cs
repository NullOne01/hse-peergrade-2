using System;
using System.Collections.Generic;
using System.IO;
using HSEPeergrade2.Commands;
using HSEPeergrade2.Exceptions;
using HSEPeergrade2.FileUtilities;
using HSEPeergrade2.Localization;

namespace HSEPeergrade2
{
    public class FileManager
    {
        private Dictionary<string, Command> commandsDict = new Dictionary<string, Command>();

        public FileManager()
        {
            SetUpCommands();
            PathTracker.GetInstance().SetUpProjectPath();
        }

        /// <summary>
        /// The start of the program.
        /// </summary>
        public void Start()
        {
            // Show help screen first.
            CommandByArguments("help");
            
            // Program loop.
            ManagerLoop();
        }

        /// <summary>
        /// Initializing a list of commands to use.
        /// </summary>
        private void SetUpCommands()
        {
            commandsDict.Add("help", new HelpCommand("help"));
            commandsDict.Add("diskShow", new DisksShowCommand("diskShow"));
            commandsDict.Add("cd", new DirectoryChooseCommand("cd"));
            commandsDict.Add("ls", new DirectoryShowListCommand("ls"));
            commandsDict.Add("print", new FilePrintCommand("print"));
            commandsDict.Add("copy", new FileCopyCommand("copy"));
            commandsDict.Add("move", new FileMoveCommand("move"));
            commandsDict.Add("delete", new FileDeleteCommand("delete"));
            commandsDict.Add("create", new FileCreateCommand("create"));
            commandsDict.Add("switchLang", new LocalizationChangeCommand("switchLang"));
        }

        /// <summary>
        /// Reading commands until user wants to quit.
        /// </summary>
        private void ManagerLoop()
        {
            do
            {
                ReadCommandLine();
                MethodsOutput.SkipLine();
                MethodsOutput.PrintLocalStringLine("COMMAND_SUCCESS");
                MethodsOutput.PrintLocalStringLine("ESC_TO_EXIT");
                MethodsOutput.SkipLine();
            } while (Console.ReadKey(true).Key != ConsoleKey.Escape);
        }
        
        /// <summary>
        /// Loop for reading command line until recognize. 
        /// </summary>
        private void ReadCommandLine()
        {
            bool isInLoop = true;
            while (isInLoop)
            {
                try
                {
                    CommandByArguments(MethodsInput.ReadStringPrefixPath());
                    isInLoop = false;
                }
                catch (Exception e)
                {
                    MethodsOutput.PrintStringLine(e.Message);
                    isInLoop = true;
                }
            }
        }

        /// <summary>
        /// Detect command type. Pass params and execute command.
        /// </summary>
        /// <param name="line">Command line.</param>
        /// <exception cref="NoCommandException">No command named like that.</exception>
        /// <exception cref="WrongArgumentsException">Wrong arguments for the command.</exception>
        private void CommandByArguments(string line)
        {
            string[] arguments = line.Split();
            if (!commandsDict.ContainsKey(arguments[0]))
            {
                throw new NoCommandException();
            }

            if (!commandsDict[arguments[0]].ValidateParams(line))
            {
                throw new WrongArgumentsException();
            }

            commandsDict[arguments[0]].TakeParameters(line);
            commandsDict[arguments[0]].Execute();
        }
    }
}