namespace AdventOfCode2022.Commands.Day10
{
    internal interface IOperation
    {
        public string Parameters { get; set; }

        public int CyclesUntillComplete { get; set; }

        public void Setup();

        public void Process(ICPUState currentState);

        bool IsCompleted();
    }
}