using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Commands.Day11
{
    internal interface IMonkeyOperation
    {
        internal static IMonkeyOperation Create(string operationText)
        {
            operationText = operationText[(operationText.IndexOf(":") + 1)..].Trim();
            if (!operationText.StartsWith("new ="))
                throw new ArgumentException("Formato da operação incorreto");

            if (operationText.Equals("new = old * old"))
                return new ExponentialOperation();

            if(!int.TryParse(operationText[11..].Trim(), out int value))
                throw new ArgumentException("Formato da operação incorreto");

            switch (operationText[10])
            {
                case '+':
                    return new AddOperation(value);
                case '*':
                    return new TimesOperation(value);
                default:
                    throw new ArgumentException("Formato da operação incorreto");
            }
        }

        internal long Calculate(long oldValue);
    }

    internal class AddOperation : IMonkeyOperation
    {

        public long FixedValue { get; set; }

        public AddOperation(int fixedValue)
        {
            FixedValue = fixedValue;
        }

        long IMonkeyOperation.Calculate(long oldValue)
        {
            return oldValue + FixedValue;
        }
    }

    internal class TimesOperation : IMonkeyOperation
    {

        public long FixedValue { get; set; }

        public TimesOperation(int fixedValue)
        {
            FixedValue = fixedValue;
        }

        long IMonkeyOperation.Calculate(long oldValue)
        {
            return oldValue * FixedValue;
        }
    }

    internal class ExponentialOperation : IMonkeyOperation
    {       

        long IMonkeyOperation.Calculate(long oldValue)
        {
            return oldValue * oldValue;
        }
    }
}
