namespace AdventOfCode2022.Commands.Day10
{
    internal interface ICPUState
    {

        internal int RegisterX { get; set; }

        internal int CurrentCycle { get; set; }

        internal int CurrentInstruction { get; set; }

        internal int CycleUntilEndOperation { get; set; }

        internal int SignalStrength { get; }

        internal IOperation Operation { get; set; }

    }

}
