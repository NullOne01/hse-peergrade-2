using System;
using System.Collections.Generic;

namespace HSEPeergrade2.Localization
{
    /// <summary>
    /// Class of default localization text. English text.
    /// </summary>
    public class DefaultLocalization
    {
        public Dictionary<string, string> formatDict = new Dictionary<string, string>()
        {
            {"CONSOLE_PATH_INPUT_PREFIX", "{0}> "}
        };
        
        public Dictionary<string, string> localDict = new Dictionary<string, string>()
        {
            {"TEST", "TEST. "},
            {"UNDEFINED", "Undefined. "},
            {"HELP", "help - print this menu." + Environment.NewLine +
                     "diskShow - show all disks. " + Environment.NewLine +
                     "cd \"PATH\" - choose current directory. " + Environment.NewLine +
                     "ls - show list of files and directories. " + Environment.NewLine + 
                     "printFile \"PATH\" - print file with encoding UTF-8" + Environment.NewLine +
                     "printFile \"PATH\" \"UTF-8/UTF-7/UTF-32/ASCII\" - " +
                     "print file with chosen encoding(UTF-8/UTF-7/UTF-32/ASCII)"
            },
            {"WRONG_ARGUMENTS", "Error: wrong arguments. "},
            {"WRONG_ARGUMENTS_IO", "Error: directory is invalid."},
            {"NO_COMMAND", "Error: unknown command. "},
            {"INVALID_PATH", "Error: invalid path. "},
            {"ESC_TO_EXIT", "Press ESC to exit. Otherwise type ENTER. "},
            {"DIRECTORIES", "Directories: "},
            {"FILES", "Files: "},
            {"NO_DIRECTORIES", "No directories here. "},
            {"NO_FILES", "No files here. "},
            {"INVALID_ENCODING", "Error: unknown encoding. "}
        };
    }
}