using AdventOfCode2022.Commands.Day9;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Commands
{
    internal class Day9Command : IDayCommand
    {
        public static int Day => 9;
        public static string InputFileName => CommandUtils.GetInputFilePath(Day);
        bool IDayCommand.IsPartOneComplete => false;

        KnotMap KnotMap = new KnotMap();

        void IDayCommand.Execute()
        {
            KnotMap.Reset();
            string[] input = CommandUtils.GetInput(InputFileName);
            foreach (var item in input)
            {
                KnotMap.InterpretEntry(item);
            }

        }

        string IDayCommand.PrintHeader()
        {
            return "Day 9: Rope Bridge";
        }

        string IDayCommand.PrintPart1()
        {
            return KnotMap.Print() + "\n" + KnotMap.CountFootprints().ToString();
        }

        string IDayCommand.PrintPart2()
        {
            throw new NotImplementedException();
        }
    }
}
