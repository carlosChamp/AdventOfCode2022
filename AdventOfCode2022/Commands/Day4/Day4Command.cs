using AdventOfCode2022.Commands.Day3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AdventOfCode2022.Commands
{
    internal class Day4Command : IDayCommand
    {
        public static int Day => 4;
        public static string InputFileName => CommandUtils.GetInputFilePath(Day);
        public bool IsPartOneComplete => true;

        int countFullyContained = 0;
        int countOverlapedPairs = 0;

        void IDayCommand.Execute()
        {
            string[] input = CommandUtils.GetInput(InputFileName);
            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                    continue;

                var temp = new PairOfElves(line);
                if (temp.HasFullyContainedIntervals())
                    countFullyContained++;

                if (temp.HasPairsOverlapeds())
                    countOverlapedPairs++;
            }
        }

        string IDayCommand.PrintHeader()
        {
            return "Day 4: Camp Cleanup";
        }

        string IDayCommand.PrintPart1()
        {
            return countFullyContained.ToString();
        }

        string IDayCommand.PrintPart2()
        {
            return countOverlapedPairs.ToString();
        }
    }
}
