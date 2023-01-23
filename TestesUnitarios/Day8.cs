using AdventOfCode2022.Commands.Day8;

namespace TestesUnitarios
{
    public class TestsDay8
    {
        DayCommandFactory _dayCommandFactory;
        [SetUp]
        public void Setup()
        {
            _dayCommandFactory = new DayCommandFactory();
        }

        [Test]
        public void TestDay8Factory()
        {
            Assert.IsTrue(_dayCommandFactory.Create("8") is Day8Command);
        }
    }

    public class TestsDay8TreeGrid
    {
        TreeGrid tree = new TreeGrid();
        [SetUp]
        public void Setup()
        {
            string[] input = new string[]
            {
                "30373",
                "25512",
                "65332",
                "33549",
                "35390"
            };
            tree.SetGrid(input);
        }

        [Test]
        public void Part1()
        {
            int quantidadeVisivel = tree.CountVisible();

            Assert.That(quantidadeVisivel, Is.EqualTo(21));

        }
        [Test]
        public void Part2()
        {
            int maxScenicScore = tree.MaxScenicScore();

            Assert.That(maxScenicScore, Is.EqualTo(8));
        }
    }
}