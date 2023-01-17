using System.Numerics;

namespace AdventOfCode2022.Commands
{
    public class SectionInterval
    {
        public int Start { get; set; }
        public int End { get; set; }
        public int Size
        {
            get
            {
                return End - Start;
            }
        }

        public SectionInterval(string interval)
        {
            var values = interval.Split("-");
            Start = int.Parse(values[0]);
            End = int.Parse(values[1]);

        }

        public bool Contains(SectionInterval interval)
        {
            return Start <= interval.Start && End >= interval.End;
        }

        internal bool Overlaps(SectionInterval pair2)
        {
            return (this.Start <= pair2.Start && this.End >= pair2.Start) ||
                    (this.Start <= pair2.End && this.End >= pair2.End);
        }
    }
}