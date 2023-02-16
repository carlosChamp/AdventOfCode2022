using AdventOfCode2022.Commands.Day10;
using AdventOfCode2022.Commands.Day11;
using AdventOfCode2022.Commands.Day8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Commands
{
    internal class Day11Command : IDayCommand
    {
        public static int Day => 11;

        public static string InputFileName => CommandUtils.GetInputFilePath(Day);
        bool IDayCommand.IsPartOneComplete => true;

        MonkeyList monkeys = new MonkeyList();
        MonkeyList monkeysPart2 = new MonkeyList();

        void IDayCommand.Execute()
        {
            string[] input = CommandUtils.GetInput(InputFileName);
            monkeys.Interpret(input);
            monkeysPart2.Interpret(input);
            long reductionWorryValue = monkeysPart2.Select(x => x.Test.TestValue).Aggregate((total, next) => total * next);
            monkeysPart2.WorryLevelReductionFunction = x => x % reductionWorryValue;

            for (int i = 0; i < 20; i++)
                monkeys.ExecuteAndTransfer();

            for (int i = 0; i < 10000; i++)
                monkeysPart2.ExecuteAndTransfer();

        }

        string IDayCommand.PrintHeader()
        {
            return "Day 11: Monkey in the Middle";
        }

        string IDayCommand.PrintPart1()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in monkeys)
            {
                stringBuilder.AppendLine($"Monkey {item.Id}: {item.TestCount}");
            }
            long monkeyBusiness = monkeys.CalculateMonkeyBusiness();
            stringBuilder.AppendLine(monkeyBusiness.ToString());
            return stringBuilder.ToString();
        }

        string IDayCommand.PrintPart2()
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var item in monkeysPart2)
            {
                stringBuilder.AppendLine($"Monkey {item.Id}: {item.TestCount}");
            }
            long monkeyBusiness = monkeysPart2.CalculateMonkeyBusiness();
            stringBuilder.AppendLine(monkeyBusiness.ToString());
            return stringBuilder.ToString();
        }
    }
}
