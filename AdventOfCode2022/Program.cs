// See https://aka.ms/new-console-template for more information
using AdventOfCode2022.Commands;
using System.Diagnostics;

string ActionTimeCounter(Func<string> func, string processo)
{
#if DEBUG
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
#endif
    string retorno = func();

#if DEBUG
    Console.WriteLine("Tempo " + processo + " - " + stopwatch.ElapsedMilliseconds);
    stopwatch.Stop();
#endif
    return retorno;
}

void ActionTimeCounterVoid(Action func, string processo)
{
#if DEBUG
    Stopwatch stopwatch = new Stopwatch();
    stopwatch.Start();
#endif
    func();
#if DEBUG
    Console.WriteLine("Tempo " + processo + " - " + stopwatch.ElapsedMilliseconds);
    stopwatch.Stop();
#endif

}

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
        ActionTimeCounterVoid(() => comando.Execute(), "Processamento");
        Console.WriteLine(ActionTimeCounter(() => "Part 1 - " + comando.PrintPart1(), "Print part 1"));
        if (comando.IsPartOneComplete)
            Console.WriteLine(ActionTimeCounter(() => "Part 2 - " + comando.PrintPart2(), "Print part 2"));

    } while (true);
}
catch (Exception ex)
{
    Console.WriteLine("Ops! " + ex.Message);
    Console.ReadKey();
    throw;
}

