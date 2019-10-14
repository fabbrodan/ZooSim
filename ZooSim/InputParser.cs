using System;
using System.Collections.Generic;
using System.Text;

namespace ZooSim
{
    public static class InputParser
    {
        private static List<string> commands = new List<string>()
        {
            "Feed"
        };

        public static void ParseActionInput(string input)
        {
            if (commands.Contains(input))
            {

            }
        }
    }
}
