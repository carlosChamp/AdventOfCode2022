using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Commands.Day10
{
    internal class OperationFabric
    {
        internal static IOperation Create(string Command)
        {
            string[] commandSplit = Command.Split(' ');
            switch (commandSplit[0])
            {
                case "addx":
                    return new AddxOperation(commandSplit[1]);
                case "noop":
                default:
                    return new NoopOperation();
            }

        }
    }
}
