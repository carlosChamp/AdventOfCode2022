namespace AdventOfCode2022.Commands.Day8
{
    internal class Tree : IComparable<Tree>
    {
        public int Heigth { get; set; }

        public bool VisibleByTop { get; set; }
        public bool VisibleByLeft { get; set; }
        public bool VisibleByRight { get; set; }
        public bool VisibleByDown { get; set; }

        public bool Visible
        {
            get
            {
                return VisibleByTop || VisibleByLeft || VisibleByRight || VisibleByDown;
            }
        }

        public int ScenicScore { get; internal set; }

        public int CompareTo(Tree? other)
        {
            if (other == null) return 1;
            return this.Heigth.CompareTo(other.Heigth);
        }
    }
}