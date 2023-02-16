using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2022.Commands.Day11;

namespace TestesUnitarios.Day11
{
    internal class Day11Test
    {
        string[] textMonkeys;
        [SetUp]
        public void SetUp()
        {
            textMonkeys = ("Monkey 0:\r\n" +
                            "  Starting items: 79, 98\r\n" +
                            "  Operation: new = old * 19\r\n" +
                            "  Test: divisible by 23\r\n" +
                            "    If true: throw to monkey 2\r\n" +
                            "    If false: throw to monkey 3\r\n" +
                            "\r\n" +
                            "Monkey 1:\r\n" +
                            "  Starting items: 54, 65, 75, 74\r\n" +
                            "  Operation: new = old + 6\r\n" +
                            "  Test: divisible by 19\r\n" +
                            "    If true: throw to monkey 2\r\n" +
                            "    If false: throw to monkey 0\r\n" +
                            "\r\n" +
                            "Monkey 2:\r\n" +
                            "  Starting items: 79, 60, 97\r\n" +
                            "  Operation: new = old * old\r\n" +
                            "  Test: divisible by 13\r\n" +
                            "    If true: throw to monkey 1\r\n" +
                            "    If false: throw to monkey 3\r\n" +
                            "\r\n" +
                            "Monkey 3:\r\n" +
                            "  Starting items: 74\r\n" +
                            "  Operation: new = old + 3\r\n" +
                            "  Test: divisible by 17\r\n" +
                            "    If true: throw to monkey 0\r\n" +
                            "    If false: throw to monkey 1").Split("\r\n");

        }

        [Test]
        public void TestMonkeyConstructor()
        {
            string startingItemsText = "Starting items: 79, 98";
            string operationText = "Operation: new = old * 19";
            string[] testText = ("Test: divisible by 23\r\n" +
                                    "If true: throw to monkey 2\r\n" +
                                    "If false: throw to monkey 3").Split("\r\n");

            MonkeyList monkeyList = new();
            IMonkeyOperation monkeyOperation = IMonkeyOperation.Create(operationText);
            IMonkeyTest monkeyTest = IMonkeyTest.Create(testText);
            MonkeyItems monkeyItems = MonkeyItems.Create(startingItemsText);

            Monkey monkey0 = new(0, monkeyItems, monkeyOperation, monkeyTest);
            Monkey monkey2 = new(2);
            Monkey monkey3 = new(3);

            monkeyList.Add(monkey0);
            monkeyList.Add(monkey2);
            monkeyList.Add(monkey3);

            monkeyList.ExecuteAndTransfer();

            Assert.IsTrue(monkey3.Items.Contains(500));
            Assert.IsTrue(monkey3.Items.Contains(620));
        }

        [Test]
        public void MonkeyItemsTest()
        {
            string startingItemsText = "Starting items: 79, 98";
            MonkeyItems monkeyItems = MonkeyItems.Create(startingItemsText);
            Assert.IsTrue(monkeyItems.Contains(79));
            Assert.IsTrue(monkeyItems.Contains(98));
        }

        [Test]
        public void OperationCreateTest()
        {
            IMonkeyOperation multiplication = IMonkeyOperation.Create("Operation: new = old * 19");
            IMonkeyOperation exponential = IMonkeyOperation.Create("Operation: new = old * old");
            IMonkeyOperation addition = IMonkeyOperation.Create("Operation: new = old + 19");

            Assert.That(multiplication is TimesOperation);
            Assert.That(exponential is ExponentialOperation);
            Assert.That(addition is AddOperation);
        }
        [Test]
        public void TestCreateTest()
        {
            IMonkeyOperation multiplication = IMonkeyOperation.Create("Operation: new = old * 19");
            IMonkeyOperation exponential = IMonkeyOperation.Create("Operation: new = old * old");
            IMonkeyOperation addition = IMonkeyOperation.Create("Operation: new = old + 19");

            Assert.That(multiplication is TimesOperation);
            Assert.That(exponential is ExponentialOperation);
            Assert.That(addition is AddOperation);
        }

        [Test]
        public void InterpretTest()
        {
            MonkeyList monkeys = new();
            monkeys.Interpret(textMonkeys);
            Assert.That(monkeys.Count, Is.EqualTo(4));
        }


        [Test]
        public void BasicScenarioTest()
        {
            MonkeyList monkeys = new();
            monkeys.Interpret(textMonkeys);
            for (int i = 0; i < 20; i++)
                monkeys.ExecuteAndTransfer();

            Assert.That(monkeys[0].TestCount, Is.EqualTo(101));
            Assert.That(monkeys[1].TestCount, Is.EqualTo(95));
            Assert.That(monkeys[2].TestCount, Is.EqualTo(7));
            Assert.That(monkeys[3].TestCount, Is.EqualTo(105));
        }
               
        [Test]
        public void StepsTest()
        {
            MonkeyList monkeys = new();
            monkeys.Interpret(textMonkeys);
            //round 1
            monkeys.ExecuteAndTransfer();

            Assert.That(monkeys[0].Items, Is.EqualTo(new MonkeyItems() { 20, 23, 27, 26 }));
            Assert.That(monkeys[1].Items, Is.EqualTo(new MonkeyItems() { 2080, 25, 167, 207, 401, 1046 }));
            //round 2
            monkeys.ExecuteAndTransfer();

            Assert.That(monkeys[0].Items, Is.EqualTo(new MonkeyItems() { 695, 10, 71, 135, 350 }));
            Assert.That(monkeys[1].Items, Is.EqualTo(new MonkeyItems() { 43, 49, 58, 55, 362 }));
            //round 3
            monkeys.ExecuteAndTransfer();

            Assert.That(monkeys[0].Items, Is.EqualTo(new MonkeyItems() { 16, 18, 21, 20, 122 }));
            Assert.That(monkeys[1].Items, Is.EqualTo(new MonkeyItems() { 1468, 22, 150, 286, 739 }));
            //round 4
            monkeys.ExecuteAndTransfer();

            Assert.That(monkeys[0].Items, Is.EqualTo(new MonkeyItems() { 491, 9, 52, 97, 248, 34 }));
            Assert.That(monkeys[1].Items, Is.EqualTo(new MonkeyItems() { 39, 45, 43, 258 }));

            //round 5
            monkeys.ExecuteAndTransfer();

            Assert.That(monkeys[0].Items, Is.EqualTo(new MonkeyItems() { 15, 17, 16, 88, 1037 }));
            Assert.That(monkeys[1].Items, Is.EqualTo(new MonkeyItems() { 20, 110, 205, 524, 72 }));

            //round 6
            monkeys.ExecuteAndTransfer();

            Assert.That(monkeys[0].Items, Is.EqualTo(new MonkeyItems() { 8, 70, 176, 26, 34 }));
            Assert.That(monkeys[1].Items, Is.EqualTo(new MonkeyItems() { 481, 32, 36, 186, 2190 }));

            //round 7
            monkeys.ExecuteAndTransfer();

            Assert.That(monkeys[0].Items, Is.EqualTo(new MonkeyItems() { 162, 12, 14, 64, 732, 17 }));
            Assert.That(monkeys[1].Items, Is.EqualTo(new MonkeyItems() { 148, 372, 55, 72 }));

            //round 8
            monkeys.ExecuteAndTransfer();

            Assert.That(monkeys[0].Items, Is.EqualTo(new MonkeyItems() { 51, 126, 20, 26, 136 }));
            Assert.That(monkeys[1].Items, Is.EqualTo(new MonkeyItems() { 343, 26, 30, 1546, 36 }));

            //round 9
            monkeys.ExecuteAndTransfer();

            Assert.That(monkeys[0].Items, Is.EqualTo(new MonkeyItems() { 116, 10, 12, 517, 14 }));
            Assert.That(monkeys[1].Items, Is.EqualTo(new MonkeyItems() { 108, 267, 43, 55, 288 }));

            //round 10
            monkeys.ExecuteAndTransfer();

            Assert.That(monkeys[0].Items, Is.EqualTo(new MonkeyItems() { 91, 16, 20, 98 }));
            Assert.That(monkeys[1].Items, Is.EqualTo(new MonkeyItems() { 481, 245, 22, 26, 1092, 30 }));

            //round 15
            monkeys.ExecuteAndTransfer();
            monkeys.ExecuteAndTransfer();
            monkeys.ExecuteAndTransfer();
            monkeys.ExecuteAndTransfer();
            monkeys.ExecuteAndTransfer();

            Assert.That(monkeys[0].Items, Is.EqualTo(new MonkeyItems() { 83, 44, 8, 184, 9, 20, 26, 102 }));
            Assert.That(monkeys[1].Items, Is.EqualTo(new MonkeyItems() { 110, 36 }));

            //round 20
            monkeys.ExecuteAndTransfer();
            monkeys.ExecuteAndTransfer();
            monkeys.ExecuteAndTransfer();
            monkeys.ExecuteAndTransfer();
            monkeys.ExecuteAndTransfer();

            Assert.That(monkeys[0].Items, Is.EqualTo(new MonkeyItems() { 10, 12, 14, 26, 34 }));
            Assert.That(monkeys[1].Items, Is.EqualTo(new MonkeyItems() { 245, 93, 53, 199, 115 }));

        }
    }
}
