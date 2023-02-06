using System.Diagnostics;

namespace AdventOfCode2022.Commands.Day10
{
    internal class AddxOperation : IOperation
    {
        public AddxOperation(string parameters)
        {
            Parameters = parameters.Trim();
        }

        public string Parameters { get; set; }

        public int CyclesUntillComplete { get; set; } = 2;

        public void Setup()
        {
        }
        private int ciclo = 1;
        bool processed = false;
        public void Process(ICPUState currentState)
        {
            if (ciclo == 2)
            {
                currentState.RegisterX += int.Parse(Parameters);
                processed = true;
            }
            ciclo++;
        }

        public bool IsCompleted()
        {
            return processed;
        }
    }
}