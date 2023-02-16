using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Commands.Day11
{
    internal interface IMonkeyTest
    {
        internal static IMonkeyTest Create(string[] testText)
        {
            if (!testText[0].Trim().StartsWith("Test: divisible by"))
                throw new ArgumentException("Formato incorreto");

            if (!int.TryParse(testText[0].Trim().Split(" ").Last(), out int testValue))
                throw new ArgumentException("Formato incorreto");

            if (!int.TryParse(testText[1].Trim().Split(" ").Last(), out int throwIfTrue))
                throw new ArgumentException("Formato incorreto");

            if (!int.TryParse(testText[2].Trim().Split(" ").Last(), out int throwIfFalse))
                throw new ArgumentException("Formato incorreto");

            return new DivisibleByTest(testValue, throwIfTrue, throwIfFalse);
        }

        public bool Test(long valueToTest);

        public int ThrowIfTrue { get; set; }

        public int ThrowIfFalse { get; set; }

        public long TestValue { get; set; }

    }

    internal class DivisibleByTest : IMonkeyTest
    {
        public DivisibleByTest(long testValue, int throwIfTrue, int throwIfFalse)
        {
            TestValue = testValue;
            ThrowIfTrue = throwIfTrue;
            ThrowIfFalse = throwIfFalse;
        }

        public long TestValue { get; set; }
        public int ThrowIfTrue { get; set; }
        public int ThrowIfFalse { get; set; }

        public bool Test(long valueToTest)
        {
            long resto = valueToTest % TestValue;
            return resto == 0;
        }

    }

}
