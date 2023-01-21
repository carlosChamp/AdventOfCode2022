using AdventOfCode2022.Commands.Day8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Commands
{
    internal class Day8Command : IDayCommand
    {

        public static int Day => 8;

        public static string InputFileName => CommandUtils.GetInputFilePath(Day);
        bool IDayCommand.IsPartOneComplete => false;

        TreeGrid grid = new TreeGrid();

        void IDayCommand.Execute()
        {
            string[] input = CommandUtils.GetInput(InputFileName);
            grid.SetGrid(input);
        }

        string IDayCommand.PrintHeader()
        {
            return "Day 8: Treetop Tree House";
        }

        string IDayCommand.PrintPart1()
        {
            return grid.PrintVisible() + "\nVisiveis: " + grid.CountVisible();
        }

        string IDayCommand.PrintPart2()
        {
            throw new NotImplementedException();
        }
    }
}
