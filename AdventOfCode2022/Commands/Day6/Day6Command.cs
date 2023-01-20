using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Commands
{
    internal class Day6Command : IDayCommand
    {
        public static int Day => 6;

        public static string InputFileName => CommandUtils.GetInputFilePath(Day);

        public bool IsPartOneComplete => true;

        private const int QTD_CHAR_STARTER_PACKAGE = 4;
        private const int QTD_CHAR_STARTER_MESSAGE = 14;
        private int charsUntilPackage = 0;
        private int charsUntilMessage = 0;

        void IDayCommand.Execute()
        {
            string input = CommandUtils.GetInput(InputFileName)[0];
            int StartOfPackageCount = 0;
            bool foundPackage = false;
            bool foundMessage = false;
            while (true)
            {
                StartOfPackageCount++;
                if (!foundPackage && markerFound(StartOfPackageCount - 1, input, QTD_CHAR_STARTER_PACKAGE))
                {
                    charsUntilPackage = StartOfPackageCount + QTD_CHAR_STARTER_PACKAGE - 1;
                    foundPackage = true;
                }

                if (!foundMessage && markerFound(StartOfPackageCount - 1, input, QTD_CHAR_STARTER_MESSAGE))
                {
                    charsUntilMessage = StartOfPackageCount + QTD_CHAR_STARTER_MESSAGE - 1;
                    foundMessage = true;
                }
                if (foundPackage && foundMessage)
                    break;

            }
        }

        private bool markerFound(int countLetter, string input, int quantidade)
        {
            for (int i = countLetter; i < countLetter + quantidade && i < input.Length; i++)
                for (int j = i + 1; j < countLetter + quantidade; j++)
                    if (input[i] == input[j])
                        return false;

            return true;
        }

        string IDayCommand.PrintHeader()
        {
            return "Day 6: Tuning Trouble";
        }

        string IDayCommand.PrintPart1()
        {
            return charsUntilPackage.ToString();
        }

        string IDayCommand.PrintPart2()
        {
            return charsUntilMessage.ToString();
        }
    }
}
