using AdventOfCode2022.Commands.Day10;
using AdventOfCode2022.Commands.Day8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Commands
{
    internal class Day10Command : IDayCommand
    {
        public static int Day => 10;

        public static string InputFileName => CommandUtils.GetInputFilePath(Day);
        bool IDayCommand.IsPartOneComplete => true;

        ElfCPU elfCPU = new();

        void IDayCommand.Execute()
        {
            string[] input = CommandUtils.GetInput(InputFileName);
            elfCPU.Instructions = input;
            elfCPU.Run();
        }

        string IDayCommand.PrintHeader()
        {
            return "Day 10: Cathode-Ray Tube";
        }

        string IDayCommand.PrintPart1()
        {
            int totalSignal = 0;
            for (int i = 20; i <= 220; i+=40)
            {
                totalSignal += elfCPU.GetState(i).SignalStrength;
            }
            return totalSignal.ToString();
        }

        string IDayCommand.PrintPart2()
        {
            return  "\n" + elfCPU.CRTPrint();
        }
    }
}
