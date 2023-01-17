// See https://aka.ms/new-console-template for more information
using AdventOfCode2022.Commands;

try
{
    do
    {
        string? day = Console.ReadLine();
        if (string.IsNullOrEmpty(day))
            return;

        DayCommandFactory factoryCommand = new DayCommandFactory();
        IDayCommand comando = factoryCommand.Create(day);

        Console.Clear();
        Console.WriteLine(comando.PrintHeader());
        comando.Execute();
        Console.WriteLine("Part 1 - " + comando.PrintPart1());
        if (comando.IsPartOneComplete)
            Console.WriteLine("Part 2 - " + comando.PrintPart2());

    } while (true);
}
catch (Exception ex)
{
    Console.WriteLine("Ops! " + ex.Message);
    Console.ReadKey();
    throw;
}