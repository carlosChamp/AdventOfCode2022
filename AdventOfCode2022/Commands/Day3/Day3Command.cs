using AdventOfCode2022.Commands.Day3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Commands
{
    internal class Day3Command : IDayCommand
    {
        public static int Day => 3;
        public static string InputFileName => CommandUtils.GetInputFilePath(Day);
        public bool IsPartOneComplete => true;

        int total = 0;
        int totalInGroup = 0;
        IList<Rucksack> rucksacks = new List<Rucksack>();
        IList<ElfGroup> groups = new List<ElfGroup>();

        void IDayCommand.Execute()
        {
            string[] input = CommandUtils.GetInput(InputFileName);
            int rucksacksCounter = 0;
            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                var temp = new Rucksack(line);
                total += temp.EvaluateDuplicateItemValue();
                rucksacks.Add(temp);
                rucksacksCounter++;
                if (rucksacksCounter % 3 == 0)
                {
                    var tempGroup = new ElfGroup(rucksacks.TakeLast(3).ToList());
                    totalInGroup += tempGroup.BadgeValue;
                    groups.Add(tempGroup);

                }
            }
        }

        string IDayCommand.PrintHeader()
        {
            return "Day 3: Rucksack Reorganization";
        }

        string IDayCommand.PrintPart1()
        {
            return total.ToString();
        }

        string IDayCommand.PrintPart2()
        {
            return totalInGroup.ToString();
        }
    }
}
