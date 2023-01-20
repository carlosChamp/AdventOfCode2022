namespace AdventOfCode2022.Commands.Day7
{
    internal interface IFileSystemItem
    {
        string Nome { get; set; }
        ulong Tamanho { get; }
    }
}