using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Commands.Day3
{
    internal class ElfGroup
    {
        public char Badge { get; set; }
        public int BadgeValue { get; set; }
        private IList<Rucksack> Rucksacks { get; set; }
        public bool[] DuplicateItemsInGroup { get; set; } = new bool[52];
        public ElfGroup(IList<Rucksack> rucksacks)
        {
            this.Rucksacks = rucksacks;
            DuplicateItemsInGroup = Rucksacks[0].ItemsInTheRucksack;
            for (int i = 0; i < DuplicateItemsInGroup.Length; i++)
            {
                DuplicateItemsInGroup[i] &=
                    Rucksacks[1].ItemsInTheRucksack[i] &&
                    Rucksacks[2].ItemsInTheRucksack[i];
            }
            BadgeValue = DuplicateItemsInGroup.ToList().FindIndex(x => x) + 1;
            Badge = ConvertionUtils.ConvertRucksackItemToCharacter(BadgeValue);

        }
        
        
    }
}
