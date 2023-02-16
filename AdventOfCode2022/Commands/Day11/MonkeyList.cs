using AdventOfCode2022.Commands.Day10;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Commands.Day11
{
    internal class MonkeyList : List<Monkey>
    {
        public Func<long, long> WorryLevelReductionFunction { get; set; } = (x => x / 3);
        public int CountExecutions { get; set; }
        internal long CalculateMonkeyBusiness()
        {
            var orderedList = this.OrderByDescending(x => x.TestCount).ToList();
            return orderedList[0].TestCount * orderedList[1].TestCount;
        }

        internal void ExecuteAndTransfer()
        {
            CountExecutions++;
            foreach (var monkey in this)
            {
                if (monkey.Operation == null)
                    continue;

                if (monkey.Test == null)
                    continue;

                while (monkey.Items.Count > 0)
                {
                    monkey.Items[0] = monkey.Operation.Calculate(monkey.Items[0]);
                    monkey.Items[0] = WorryLevelReductionFunction(monkey.Items[0]);
                    bool passouNoTeste = monkey.Test.Test(monkey.Items[0]);
                    monkey.TestCount++;
                    if (passouNoTeste)
                        Throw(monkey.Items[0], monkey.Id, monkey.Test.ThrowIfTrue);
                    else
                        Throw(monkey.Items[0], monkey.Id, monkey.Test.ThrowIfFalse);
                }
            }
        }

        internal void Interpret(string[] textMonkeys)
        {
            Monkey current = null;
            int currentLine = 0;
            while (currentLine < textMonkeys.Length)
            {
                if (textMonkeys[currentLine].StartsWith("Monkey "))
                {

                    if (!int.TryParse(textMonkeys[currentLine].Split(" ").Last().Trim(':'), out int monkeyId))
                        throw new ArgumentException("Formato incorreto.");
                    MonkeyItems monkeyItems = MonkeyItems.Create(textMonkeys[++currentLine]);
                    IMonkeyOperation monkeyOperation = IMonkeyOperation.Create(textMonkeys[++currentLine]);
                    IMonkeyTest monkeyTest = IMonkeyTest.Create(textMonkeys[(++currentLine)..(currentLine + 3)]);

                    current = new Monkey(monkeyId, monkeyItems, monkeyOperation, monkeyTest);
                    this.Add(current);
                }
                currentLine++;

            }
        }

        internal void Throw(long monkeyItem, int from, int to)
        {
            this.First(x => x.Id == from).Items.Remove(monkeyItem);
            this.First(x => x.Id == to).Items.Add(monkeyItem);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            sb.AppendLine($"== After round {CountExecutions} ==");
            foreach (var mk in this)
            {
                sb.AppendLine($"Monkey {mk.Id} inspected items {mk.TestCount} times.");
            }

            return sb.ToString();
        }
    }
}
