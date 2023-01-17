using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Commands.Day3
{
    internal class ConvertionUtils
    {
        private const int BASE_LOWERCASE_CHARACTER_VALUE = 97;
        private const int BASE_UPPERCASE_CHARACTER_VALUE_MINUS_26 = 39;
        private const int TOTAL_CHARACTER_REPRESENTATION = 26;

        public static int ConvertCharacterToRucksackItem(char item)
        {
            if (item >= BASE_LOWERCASE_CHARACTER_VALUE)
                return Convert.ToInt32(item) - BASE_LOWERCASE_CHARACTER_VALUE;
            else
                return Convert.ToInt32(item) - BASE_UPPERCASE_CHARACTER_VALUE_MINUS_26;
        }
        public static char ConvertRucksackItemToCharacter(int item)
        {
            if (item < TOTAL_CHARACTER_REPRESENTATION)
                return Convert.ToChar(item -1 + BASE_LOWERCASE_CHARACTER_VALUE);
            else
                return Convert.ToChar(item -1 + BASE_UPPERCASE_CHARACTER_VALUE_MINUS_26);
        }
    }
}
