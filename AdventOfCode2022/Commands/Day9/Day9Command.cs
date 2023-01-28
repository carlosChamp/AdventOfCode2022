using AdventOfCode2022.Commands.Day9;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Commands
{
    internal class Day9Command : IDayCommand
    {
        public static int Day => 9;
        public static string InputFileName => CommandUtils.GetInputFilePath(Day);
        bool IDayCommand.IsPartOneComplete => true;

        KnotMap KnotMap = new KnotMap();
        KnotMap KnotMap2 = new KnotMap(10);

        void IDayCommand.Execute()
        {
            KnotMap.Reset();
            KnotMap2.Reset();
            string[] input = CommandUtils.GetInput(InputFileName);
            foreach (var item in input)
            {
                KnotMap.InterpretEntry(item);
                KnotMap2.InterpretEntry(item);  
            }

        }

        string IDayCommand.PrintHeader()
        {
            return "Day 9: Rope Bridge";
        }

        string IDayCommand.PrintPart1()
        {
            return "\n" + KnotMap.Print(true) + "\n" + KnotMap.CountFootprints().ToString();
        }

        string IDayCommand.PrintPart2()
        {
            return "\n" + KnotMap2.Print(true) + "\n" + KnotMap2.CountFootprints().ToString();
        }
    }
}
