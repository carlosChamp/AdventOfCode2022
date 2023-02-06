namespace AdventOfCode2022.Commands.Day10
{
    public class CPUState : ICPUState, ICloneable
    {
        public int RegisterX { get; set; } = 1;
        public int CurrentCycle { get; set; }
        public int CurrentInstruction { get; set; }
        public int CycleUntilEndOperation { get; set; }
        IOperation? ICPUState.Operation { get; set; }

        int ICPUState.SignalStrength
        {
            get
            {
                return RegisterX * (CurrentCycle + 1);
            }
        }

        public object Clone()
        {
            return this.MemberwiseClone();
        }


    }
}