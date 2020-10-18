using System;
using System.IO;

namespace HSEPeergrade2
{
    /// <summary>
    /// Base class of all commands.
    /// </summary>
    public abstract class Command
    {
        protected string name;

        public Command(string name)
        {
            this.name = name;
        }
        
        /// <summary>
        /// Executing a command.
        /// </summary>
        public abstract void Execute();
        
        /// <summary>
        /// Command takes <paramref name="line"/> to parse.
        /// </summary>
        /// <param name="line"> String for parse to get parameters. </param>
        public abstract void TakeParameters(string line);
        
        /// <summary>
        /// Is command line written correct?
        /// </summary>
        /// <param name="line"> <inheritdoc cref="TakeParameters"/> </param>
        /// <returns> True if command line is correct. Otherwise false. </returns>
        public abstract bool ValidateParams(string line);
    }
}