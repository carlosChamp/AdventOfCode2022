using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Commands
{
    internal static class CommandUtils
    {
        public static string[] GetInput(string path)
        {
            string[] result = File.ReadAllLines($"{path}");

            return result;
        }

        public static string GetInputFilePath(int day)
        {
            return @$"inputs\day{day}.txt";
        }
    }
}
