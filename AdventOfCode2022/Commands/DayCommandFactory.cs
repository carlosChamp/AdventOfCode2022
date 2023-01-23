// See https://aka.ms/new-console-template for more information
using AdventOfCode2022.Commands;

internal class DayCommandFactory
{
    internal IDayCommand Create(string day)
    {
        switch (day)
        {
            case "1":
                return new Day1Command();
            case "2":
                return new Day2Command();
            case "3":
                return new Day3Command();
            case "4":
                return new Day4Command();
            case "5":
                return new Day5Command();
            case "6":
                return new Day6Command();
            case "7":
                return new Day7Command();
            case "8":
                return new Day8Command();
            default: throw new NotImplementedException("Não resolvemos o problema desse dia ainda.");
        }
    }
}