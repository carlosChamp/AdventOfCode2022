namespace AdventOfCode2022.Commands.Day11
{
    internal class Monkey
    {
        public Monkey(int monkeyId)
        {
            Id = monkeyId;
        }

        public Monkey(int monkeyId, MonkeyItems monkeyItems, IMonkeyOperation monkeyOperation, IMonkeyTest monkeyTest)
        {
            Id = monkeyId;
            Items = monkeyItems;
            Operation = monkeyOperation;
            Test = monkeyTest;
        }

        public int Id { get; }
        public MonkeyItems Items { get; set; } = new();
        public IMonkeyOperation? Operation { get; set; }
        public IMonkeyTest? Test { get; set; }
        public long TestCount { get; set; }
    }
}
