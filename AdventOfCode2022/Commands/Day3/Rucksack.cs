namespace AdventOfCode2022.Commands.Day3
{
    internal class Rucksack
    {
        public string Compartment1 { get; set; }
        public string Compartment2 { get; set; }
        private bool[] Compartment1ItemsCheck { get; set; } = new bool[52];
        private bool[] Compartment2ItemsCheck { get; set; } = new bool[52];
        public bool[] DuplicateItemsInCompartments { get; set; } = new bool[52];
        public bool[] ItemsInTheRucksack { get; set; } = new bool[52];

        public Rucksack(string line)
        {
            Compartment1 = line.Substring(0, line.Length / 2);
            Compartment2 = line.Substring(line.Length / 2);
            refreshCountMatrix();
        }

        public void refreshCountMatrix()
        {
            for (int i = 0; i < Compartment1.Length; i++)
            {
                int index = ConvertionUtils.ConvertCharacterToRucksackItem(Compartment1[i]);
                Compartment1ItemsCheck[index] = true;
            }

            for (int i = 0; i < Compartment2.Length; i++)
            {
                int index = ConvertionUtils.ConvertCharacterToRucksackItem(Compartment2[i]);
                Compartment2ItemsCheck[index] = true;
            }

            for (int i = 0; i < DuplicateItemsInCompartments.Length; i++)
            {
                DuplicateItemsInCompartments[i] = Compartment1ItemsCheck[i] && Compartment2ItemsCheck[i];
                ItemsInTheRucksack[i] = Compartment1ItemsCheck[i] || Compartment2ItemsCheck[i];
            }
        }

        internal int EvaluateDuplicateItemValue()
        {
            return DuplicateItemsInCompartments.ToList().FindIndex(x => x) + 1;
        }
    }
}