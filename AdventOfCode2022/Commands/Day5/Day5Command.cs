using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Commands
{
    internal class Day5Command : IDayCommand
    {
        public static int Day => 5;
        public static string InputFileName => CommandUtils.GetInputFilePath(Day);
        public bool IsPartOneComplete => true;

        Pilhas<string> MoveCrater9000 = new Pilhas<string>();
        Pilhas<string> MoveCrater9001 = new Pilhas<string>(new CrateMover9001<string>());

        void IDayCommand.Execute()
        {
            List<string> pilhas = new List<string>();
            string[] input = CommandUtils.GetInput(InputFileName);
            foreach (var line in input)
            {
                if (string.IsNullOrWhiteSpace(line))
                    break;
                
                pilhas.Add(line);
            }

            SetDefaultStacks(MoveCrater9000, pilhas);
            SetDefaultStacks(MoveCrater9001, pilhas);
            for (int i = pilhas.Count; i < input.Length; i++)
            {                       
                var line = input[i];
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }

                MoveCrater9000.MoveByCommand(line);
                MoveCrater9001.MoveByCommand(line);

            }
        }

        string IDayCommand.PrintHeader()
        {
            return "Day 5: Supply Stacks";
        }

        string IDayCommand.PrintPart1()
        {
            return MoveCrater9000.Print();
        }

        string IDayCommand.PrintPart2()
        {
            return MoveCrater9001.Print();
        }

        private void SetDefaultStacks(Pilhas<string> pilhas, List<string> inputFromFile)
        {
            List<string> pilhasDeCaixas = inputFromFile.Select(x => x).ToList();
            pilhasDeCaixas.Reverse();
            int quantidadeDePilhas = (pilhasDeCaixas[0].Length + 1) / 4;
            for (int i = 1; i < pilhasDeCaixas.Count; i++)
            {
                for (int j = 0; j < quantidadeDePilhas; j++)
                {
                    int coluna = (j * 4) + 1;
                    string letra = pilhasDeCaixas[i].Substring(coluna, 1);
                    if (!string.IsNullOrWhiteSpace(letra))
                        pilhas.Push(j + 1, letra);
                }
            }
        }
    }
}
