using System.Collections.Generic;

namespace AdventOfCode2022.Commands
{
    internal class Day1Command : IDayCommand
    {
        public static int Day { get => 1; }
        public static string InputFileName { get => CommandUtils.GetInputFilePath(Day); }
        public bool IsPartOneComplete { get => true; }

        IList<int> elfos = new List<int>();
        void IDayCommand.Execute()
        {
            string[] input = CommandUtils.GetInput(InputFileName);
            int elfoAtual = 0;
            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    elfos.Add(elfoAtual);
                    elfoAtual = 0;
                }
                else
                {
                    elfoAtual += Convert.ToInt32(line);
                }
            }

            ((List<int>)elfos).Sort();
        }

        string IDayCommand.PrintHeader()
        {
            return "Dia 1: Problema das calorias dos elfos.";
        }

        string IDayCommand.PrintPart1()
        {
            return elfos.Last().ToString();
        }

        string IDayCommand.PrintPart2()
        {
            int maioresTresElfos = elfos.TakeLast(3).Sum();
            return maioresTresElfos.ToString();
        }
    }
}
