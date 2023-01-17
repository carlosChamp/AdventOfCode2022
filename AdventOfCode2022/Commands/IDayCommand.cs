using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Commands
{
    internal interface IDayCommand
    {
        public int Day { get; }

        public string InputFileName { get; }
        public bool IsPartOneComplete { get; }

        internal string PrintHeader();

        internal void Execute();

        internal string PrintPart1();
        internal string PrintPart2();
    }
}
