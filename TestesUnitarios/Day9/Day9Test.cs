using AdventOfCode2022.Commands.Day9;
using System.Drawing;

namespace TestesUnitarios.Day9
{
    internal class Day9Test
    {
        string[] input;
        string[] input2;
        private KnotMap knotMap = new();
        private KnotMap knotMap2 = new(10, new Point(11,5));

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

            input2 = new string[]
            {
                "R 5",
                "U 8",
                "L 8",
                "D 3",
                "R 17",
                "D 10",
                "L 25",
                "U 20"
            };

        }
        [Test]
        public void ResetTest()
        {
            knotMap.Walk(Direcao.RIGHT, 4);
            knotMap.Reset();
            Point headPosition = knotMap.HeadPosition;
            Point tailPosition = knotMap.TailPosition;
            Assert.Multiple(() =>
            {
                Assert.That(headPosition, Is.EqualTo(new Point(0, 0)));
                Assert.That(tailPosition, Is.EqualTo(new Point(0, 0)));
            });
        }

        [Test]
        public void WalkTest()
        {
            knotMap.Reset();
            knotMap.Walk(Direcao.RIGHT, 4);
            Point headPosition = knotMap.HeadPosition;
            Point tailPosition = knotMap.TailPosition;
            Assert.Multiple(() =>
            {
                Assert.That(headPosition, Is.EqualTo(new Point(4, 0)));
                Assert.That(tailPosition, Is.EqualTo(new Point(3, 0)));
            });
        }

        [Test]
        public void InterpretEntryTest()
        {
            knotMap.Reset();
            knotMap.InterpretEntry("R 4");
            Point headPosition = knotMap.HeadPosition;
            Point tailPosition = knotMap.TailPosition;
            Assert.Multiple(() =>
            {
                Assert.That(headPosition, Is.EqualTo(new Point(4, 0)));
                Assert.That(tailPosition, Is.EqualTo(new Point(3, 0)));
            });
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
            Assert.Multiple(() =>
            {
                Assert.That(headPosition, Is.EqualTo(new Point(2, 2)));
                Assert.That(tailPosition, Is.EqualTo(new Point(1, 2)));
                Assert.That(knotMap.CountFootprints(), Is.EqualTo(13));
            });
        }

        [Test]
        public void Part1PrintTest()
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

        [Test]
        public void Part2PrintTest()
        {
            string saida =
                "...........................\r\n" +
                "...........................\r\n" +
                "...........................\r\n" +
                "...........................\r\n" +
                "...........................\r\n" +
                "...........................\r\n" +
                "...........................\r\n" +
                "...........................\r\n" +
                "...........................\r\n" +
                "#..........................\r\n" +
                "#.............###..........\r\n" +
                "#............#...#.........\r\n" +
                ".#..........#.....#........\r\n" +
                "..#..........#.....#.......\r\n" +
                "...#........#.......#......\r\n" +
                "....#......s.........#.....\r\n" +
                ".....#..............#......\r\n" +
                "......#............#.......\r\n" +
                ".......#..........#........\r\n" +
                "........#........#.........\r\n" +
                ".........########..........\r\n";
            
            knotMap2.Reset();
            foreach (var item in input2)
            {
                knotMap2.InterpretEntry(item);
            }
            Assert.That(knotMap2.Print(), Is.EqualTo(saida));
        }

        [Test]
        public void Part2Test()
        {
            knotMap2.Reset();
            foreach (var item in input2)
            {
                knotMap2.InterpretEntry(item);
            }
            Point headPosition = knotMap2.HeadPosition;
            Point tailPosition = knotMap2.TailPosition;
            Assert.Multiple(() =>
            {
                Assert.That(headPosition, Is.EqualTo(new Point(0, 20)));
                Assert.That(tailPosition, Is.EqualTo(new Point(0, 11)));
                Assert.That(knotMap2.CountFootprints(), Is.EqualTo(36));
            });
        }
    }
}
