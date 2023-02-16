using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Commands.Day11
{
    internal class MonkeyItems : List<long>
    {
        internal static MonkeyItems Create(string startingItemsText)
        {
            MonkeyItems monkeyItems = new MonkeyItems();
            startingItemsText = startingItemsText[(startingItemsText.IndexOf(":")+1)..]
                                                 .Trim();
            var itemValues = startingItemsText.Split(",");
            foreach (var item in itemValues)
            {
                if (int.TryParse(item, out int value))
                    monkeyItems.Add(value);
            }

            return monkeyItems;
        }
    }
}
