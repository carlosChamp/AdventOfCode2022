using System.Drawing;

namespace TestesUnitarios.Day9
{
    internal class Day9Test
    {
        string[] input;
        KnotMap knotMap = new KnotMap();
        [SetUp]
        public void Setup()
        {
            input = new string[]
            {
                "R 4",
                "U 4",
                "L 3",
                "D 1",
                "R 4",
                "D 1",
                "L 5",
                "R 2"
            };

        }
        [Test]
        public void ResetTest()
        {
            knotMap.Walk(Direcao.RIGHT, 4);
            knotMap.Reset();
            Point headPosition = knotMap.HeadPosition;
            Point tailPosition = knotMap.TailPosition;
            Assert.That(headPosition, Is.EqualTo(new Point(0, 0)));
            Assert.That(tailPosition, Is.EqualTo(new Point(0, 0)));
        }

        [Test]
        public void WalkTest()
        {
            knotMap.Reset();
            knotMap.Walk(Direcao.RIGHT, 4);
            Point headPosition = knotMap.HeadPosition;
            Point tailPosition = knotMap.TailPosition;
            Assert.That(headPosition, Is.EqualTo(new Point(4, 0)));
            Assert.That(tailPosition, Is.EqualTo(new Point(3, 0)));
        }

        [Test]
        public void InterpretEntryTest()
        {
            knotMap.Reset();
            knotMap.InterpretEntry("R 4");
            Point headPosition = knotMap.HeadPosition;
            Point tailPosition = knotMap.TailPosition;
            Assert.That(headPosition, Is.EqualTo(new Point(4, 0)));
            Assert.That(tailPosition, Is.EqualTo(new Point(3, 0)));
        }

        [Test]
        public void Part1Test()
        {
            knotMap.Reset();
            foreach (var item in input)
            {
                knotMap.InterpretEntry(item);
            }
            Point headPosition = knotMap.HeadPosition;
            Point tailPosition = knotMap.TailPosition;
            Assert.That(headPosition, Is.EqualTo(new Point(2, 2)));
            Assert.That(tailPosition, Is.EqualTo(new Point(1, 2)));
            Assert.That(knotMap.CountFootprints(), Is.EqualTo(13));
        }

        [Test]
        public void PrintTest()
        {
            string saida =
                "..##...\r\n" +
                "...##..\r\n" +
                ".####..\r\n" +
                "....#..\r\n" +
                "s###...\r\n";
            knotMap.Reset();
            foreach (var item in input)
            {
                knotMap.InterpretEntry(item);
            }
            Assert.That(knotMap.Print(), Is.EqualTo(saida));

        }
    }
}
