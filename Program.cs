using System;
using System.Collections.Generic;

namespace HSEPeergrade2
{
    class Program
    {
        static void Main(string[] args)
        {
            var commands = new List<Command>();
            commands.Add(new Command("kek",
                new Type[] { },
                new Type[] {typeof(string)},
                new Type[] {typeof(string), typeof(double)}));

            while (true)
            {
                string line = Console.ReadLine();
                WrongCommandMessage wrongCommandMessage = new WrongCommandMessage();
                foreach (var command in commands)
                {
                    command.Validate(line, wrongCommandMessage);
                }

                Console.WriteLine(wrongCommandMessage.message);
            }
        }
    }
}