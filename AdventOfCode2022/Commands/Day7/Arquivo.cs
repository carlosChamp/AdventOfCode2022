using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Commands.Day7
{
    internal class Arquivo: IFileSystemItem
    {
        public string Nome { get; set; } = string.Empty;
        public ulong Tamanho { get; private set; }

        public Arquivo(string nome, ulong tamanho)
        {
            Nome = nome;
            Tamanho = tamanho;
        }
    }
}
