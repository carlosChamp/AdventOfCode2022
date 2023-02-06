namespace AdventOfCode2022.Commands.Day10
{
    internal class NoopOperation : IOperation
    {
        public string Parameters { get; set; }
        public int CyclesUntillComplete { get; set; } = 1;
        bool processed = false;

        void IOperation.Setup()
        {
        }

        void IOperation.Process(ICPUState currentState)
        {
            processed = true;
        }

        public bool IsCompleted()
        {
            return processed;
        }
    }
}