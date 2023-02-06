using AdventOfCode2022.Commands.Day10;
using Microsoft.Win32;

namespace TestesUnitarios.Day10
{
    internal class Day10
    {
        string[] instructionsTestCRT;
        [SetUp]
        public void Setup()
        {
            instructionsTestCRT = new string[] {
                "addx 15",
                "addx -11",
                "addx 6",
                "addx -3",
                "addx 5",
                "addx -1",
                "addx -8",
                "addx 13",
                "addx 4",
                "noop",
                "addx -1",
                "addx 5",
                "addx -1",
                "addx 5",
                "addx -1",
                "addx 5",
                "addx -1",
                "addx 5",
                "addx -1",
                "addx -35",
                "addx 1",
                "addx 24",
                "addx -19",
                "addx 1",
                "addx 16",
                "addx -11",
                "noop",
                "noop",
                "addx 21",
                "addx -15",
                "noop",
                "noop",
                "addx -3",
                "addx 9",
                "addx 1",
                "addx -3",
                "addx 8",
                "addx 1",
                "addx 5",
                "noop",
                "noop",
                "noop",
                "noop",
                "noop",
                "addx -36",
                "noop",
                "addx 1",
                "addx 7",
                "noop",
                "noop",
                "noop",
                "addx 2",
                "addx 6",
                "noop",
                "noop",
                "noop",
                "noop",
                "noop",
                "addx 1",
                "noop",
                "noop",
                "addx 7",
                "addx 1",
                "noop",
                "addx -13",
                "addx 13",
                "addx 7",
                "noop",
                "addx 1",
                "addx -33",
                "noop",
                "noop",
                "noop",
                "addx 2",
                "noop",
                "noop",
                "noop",
                "addx 8",
                "noop",
                "addx -1",
                "addx 2",
                "addx 1",
                "noop",
                "addx 17",
                "addx -9",
                "addx 1",
                "addx 1",
                "addx -3",
                "addx 11",
                "noop",
                "noop",
                "addx 1",
                "noop",
                "addx 1",
                "noop",
                "noop",
                "addx -13",
                "addx -19",
                "addx 1",
                "addx 3",
                "addx 26",
                "addx -30",
                "addx 12",
                "addx -1",
                "addx 3",
                "addx 1",
                "noop",
                "noop",
                "noop",
                "addx -9",
                "addx 18",
                "addx 1",
                "addx 2",
                "noop",
                "noop",
                "addx 9",
                "noop",
                "noop",
                "noop",
                "addx -1",
                "addx 2",
                "addx -37",
                "addx 1",
                "addx 3",
                "noop",
                "addx 15",
                "addx -21",
                "addx 22",
                "addx -6",
                "addx 1",
                "noop",
                "addx 2",
                "addx 1",
                "noop",
                "addx -10",
                "noop",
                "noop",
                "addx 20",
                "addx 1",
                "addx 2",
                "addx 2",
                "addx -6",
                "addx -11",
                "noop",
                "noop",
                "noop"
            };
        }
        [Test]
        public void BasicOperationTest()
        {

            string[] instructions = new string[] {
                "noop",
                "addx 3",
                "addx -5"
            };
            ElfCPU elf = new();
            elf.Instructions = instructions;
            elf.Run();
            Assert.That(elf.CurrentState.RegisterX, Is.EqualTo(-1));
            Assert.That(elf.History.Count, Is.EqualTo(6));
            Assert.That(elf.CurrentState.SignalStrength, Is.EqualTo(-6));
        }

        [TestCase(20, 21, 420)]
        [TestCase(60, 19, 1140)]
        [TestCase(100, 18, 1800)]
        [TestCase(140, 21, 2940)]
        [TestCase(180, 16, 2880)]
        [TestCase(220, 18, 3960)]
        public void CycleHistoryTest(int stateId, int registerX, int signalStrengh)
        {


            ElfCPU elf = new();
            elf.Instructions = instructionsTestCRT;
            elf.Run();
            Assert.That(elf.GetState(stateId).RegisterX, Is.EqualTo(registerX));
            Assert.That(elf.GetState(stateId).SignalStrength, Is.EqualTo(signalStrengh));

        }

        [Test]
        public void CRTTEst()
        {
            ElfCPU elf = new();
            elf.Instructions = instructionsTestCRT;
            elf.Run();
            string saidaEsperada = 
                "##..##..##..##..##..##..##..##..##..##..\r\n" +
                "###...###...###...###...###...###...###.\r\n" +
                "####....####....####....####....####....\r\n" +
                "#####.....#####.....#####.....#####.....\r\n" +
                "######......######......######......####\r\n" +
                "#######.......#######.......#######.....\r\n";
            Assert.That(elf.CRTPrint(), Is.EqualTo(saidaEsperada));

        }
    }
}
