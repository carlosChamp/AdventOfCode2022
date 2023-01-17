using System.Drawing;

namespace AdventOfCode2022.Commands
{
    internal class PairOfElves
    {
        public SectionInterval Pair1 { get; set; }
        public SectionInterval Pair2 { get; set; }

        public PairOfElves(string line)
        {
            var values = line.Split(",");
            Pair1 = new SectionInterval(values[0]);
            Pair2 = new SectionInterval(values[1]);
        }

        internal bool HasFullyContainedIntervals()
        {
            return Pair1.Contains(Pair2) || Pair2.Contains(Pair1);
        }

        internal bool HasPairsOverlapeds()
        {
            return Pair1.Overlaps(Pair2) || Pair2.Overlaps(Pair1);
        }
    }
}