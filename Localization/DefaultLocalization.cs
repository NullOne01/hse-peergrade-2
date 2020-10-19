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
                     "cd \"PATH_DIR\" - choose current directory. " + Environment.NewLine +
                     "ls - show list of files and directories. " + Environment.NewLine + 
                     "print \"PATH_FILE\" - print file with encoding UTF-8" + Environment.NewLine +
                     "print \"PATH_FILE\" \"UTF-8/UTF-7/UTF-32/ASCII\" - " +
                        "print file with chosen encoding (UTF-8/UTF-7/UTF-32/ASCII). " + Environment.NewLine +
                     "copy \"PATH_FILE\" \"PATH_FILE\" - copy first file into second file. " + Environment.NewLine +
                     "move \"PATH_FILE\" \"PATH_DIR\" - move file into directory. " + Environment.NewLine +
                     "delete \"PATH_FILE\" - delete file. " + Environment.NewLine +
                     "create \"PATH_FILE\" \"SOME_TEXT\" - create file with text in it in UTF-8 encoding. " + Environment.NewLine +
                     "create \"PATH_FILE\" \"SOME_TEXT\" \"UTF-8/UTF-7/UTF-32/ASCII\" - " +
                        "create file with text in it in chosen encoding. " + Environment.NewLine +
                     "switchLang - switch localization between Russian and English (Additional functional)."
            },
            {"WRONG_ARGUMENTS", "Error: wrong arguments. "},
            {"WRONG_ARGUMENTS_IO", "Error: directory is invalid."},
            {"FILE_NOT_FOUND", "Error: file is not found."},
            {"DIR_NOT_FOUND", "Error: directory is not found."},
            {"NO_COMMAND", "Error: unknown command. "},
            {"INVALID_PATH", "Error: invalid path. "},
            {"COPY_FILE_DOESNT_EXIST", "Error: copy file doesn't exist. "},
            {"COPY_FILE_ALREADY_EXISTS", "Error: copy to file already exists. "},
            {"MOVE_FILE_DOESNT_EXIST", "Error: move file doesn't exist. "},
            {"MOVE_FILE_ALREADY_EXISTS", "Error: move to file already exists. "},
            {"FILE_ALREADY_EXISTS", "Error: file already exists. "},
            {"ACCESS_PROBLEM", "Error: no permission. "},
            {"ESC_TO_EXIT", "Press ESC to exit. Otherwise type anything... "},
            {"DIRECTORIES", "Directories: "},
            {"FILES", "Files: "},
            {"NO_DIRECTORIES", "No directories here. "},
            {"NO_FILES", "No files here. "},
            {"INVALID_ENCODING", "Error: unknown encoding. "},
            {"COMMAND_SUCCESS", "The command completed successfully. "}
        };
    }
}