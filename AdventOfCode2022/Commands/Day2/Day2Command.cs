using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Commands.Day2;

namespace AdventOfCode2022.Commands
{
    internal partial class Day2Command : IDayCommand
    {
        public static int Day => 2;

        public static string InputFileName => CommandUtils.GetInputFilePath(Day);

        public bool IsPartOneComplete => true;

        List<Jogo> jogos = new List<Jogo>();

        int totalPart1 = 0;
        int totalPart2 = 0;

        void IDayCommand.Execute()
        {
            string[] input = CommandUtils.GetInput(InputFileName);
            foreach (var line in input)
            {
                if (string.IsNullOrEmpty(line))
                    continue;

                Jogo temp = new Jogo(line);
                totalPart1 += temp.EvaluateWithMyChoice();
                totalPart2 += temp.EvaluateWithElvesChoice();
                jogos.Add(temp);
            }

        }

        string IDayCommand.PrintHeader()
        {
            return "Dia 2: Problema das calorias dos elfos.";
        }

        string IDayCommand.PrintPart1()
        {
            return totalPart1.ToString();
        }

        string IDayCommand.PrintPart2()
        {
            return totalPart2.ToString();
        }
    }
}
