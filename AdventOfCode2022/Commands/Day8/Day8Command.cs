using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Commands.Day8
{
    internal class Day8Command : IDayCommand
    {
        bool IDayCommand.IsPartOneComplete => false;

        TreeGrid grid = new TreeGrid();

        void IDayCommand.Execute()
        {
            //TreeGrid.set
        }

        string IDayCommand.PrintHeader()
        {
            return "Day 8: Treetop Tree House";
        }

        string IDayCommand.PrintPart1()
        {
            throw new NotImplementedException();
        }

        string IDayCommand.PrintPart2()
        {
            throw new NotImplementedException();
        }
    }
}
