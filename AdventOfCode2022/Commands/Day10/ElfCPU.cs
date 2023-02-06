using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Commands.Day10
{
    internal class ElfCPU : ICPUState
    {
        public string[] Instructions { get; internal set; } = new string[0];

        public ICPUState CurrentState
        {
            get => History.Last();
        }

        public List<ICPUState> History { get; internal set; } = new List<ICPUState>();

        int ICPUState.CurrentCycle
        {
            get => CurrentState.CurrentCycle;
            set => CurrentState.CurrentCycle = value;
        }

        int ICPUState.CurrentInstruction
        {
            get => CurrentState.CurrentInstruction;
            set => CurrentState.CurrentInstruction = value;
        }

        int ICPUState.CycleUntilEndOperation
        {
            get => CurrentState.CycleUntilEndOperation;
            set => CurrentState.CycleUntilEndOperation = value;
        }

        public IOperation Operation
        {
            get => CurrentState.Operation;
            set => CurrentState.Operation = value;
        }

        public int SignalStrength { get => CurrentState.SignalStrength; }

        int ICPUState.RegisterX
        {
            get
            {
                return CurrentState.RegisterX;
            }
            set
            {
                CurrentState.RegisterX = value;
            }

        }

        public ElfCPU()
        {
            History = new List<ICPUState>();
            History.Clear();
            History.Add(new CPUState());
        }

        internal void Run()
        {
            while (CurrentState.CurrentInstruction < Instructions.Length || CurrentState.CycleUntilEndOperation > 0)
            {
                if (Operation?.IsCompleted() ?? true)
                {
                    setNextOperation();
                    continue;
                }

                SaveState();
                this.Operation.Process(this.CurrentState);
                if (Operation.IsCompleted())
                    CurrentState.CurrentInstruction++;
                CurrentState.CycleUntilEndOperation--;
                CurrentState.CurrentCycle++;

            }
        }

        internal ICPUState GetState(int cycleId)
        {
            return History.ElementAt(cycleId - 1);
        }

        private void setNextOperation()
        {
            this.Operation = OperationFabric.Create(Instructions[CurrentState.CurrentInstruction]);
            CurrentState.CycleUntilEndOperation = Operation.CyclesUntillComplete;
            Operation.Setup();
        }

        private void SaveState()
        {
            History.Add((ICPUState)((CPUState)CurrentState).Clone());
        }

        public string CRTPrint()
        {
            StringBuilder sb = new();
            char litPixel = '#', darkPixel = '.';
            for (int i = 0; i < History.Count - 1; i++)
            {
                int pixelInLine = i % 40;
                bool drawPixel = History[i].RegisterX == pixelInLine || 
                    History[i].RegisterX - 1 == pixelInLine || 
                    History[i].RegisterX + 1 == pixelInLine;
                sb.Append(drawPixel ? litPixel : darkPixel);
                if ((i + 1) % 40 == 0)
                    sb.AppendLine();
            }

            return sb.ToString();
        }
    }

}
