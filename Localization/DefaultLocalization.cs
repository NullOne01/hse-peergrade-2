using System.Collections.Generic;

namespace HSEPeergrade2.Localization
{
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
            {"HELP", "POMOGITE BLYAT. "},
            {"WRONG_ARGUMENTS", "Error: wrong arguments. "},
            {"WRONG_ARGUMENTS_IO", "Error: directory is invalid."},
            {"NO_COMMAND", "Error: unknown command. "},
            {"INVALID_PATH", "Error: invalid path. "},
            {"ESC_TO_EXIT", "Press ESC to exit. Otherwise type ENTER. "},
            {"DIRECTORIES", "Directories: "},
            {"FILES", "Files: "},
            {"NO_DIRECTORIES", "No directories here. "},
            {"NO_FILES", "No files here. "}
        };
    }
}