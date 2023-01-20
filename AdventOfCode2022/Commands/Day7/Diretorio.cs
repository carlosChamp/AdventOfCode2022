using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Commands.Day7
{
    internal class Diretorio : IFileSystemItem
    {
        public Dictionary<string, IFileSystemItem> Diretorios { get; set; }
        public Dictionary<string, IFileSystemItem> Arquivos { get; set; }
        public string Nome { get; set; }

        public ulong Tamanho
        {
            get
            {
                ulong total = 0ul;
                foreach (var item in Diretorios)
                    total += item.Value.Tamanho;
                                
                return total + TamanhoDosArquivos;
            }
        }

        public ulong TamanhoDosArquivos
        {
            get
            {
                ulong total = 0ul;

                foreach (var item in Arquivos)
                    total += item.Value.Tamanho;

                return total;
            }
        }

        public Diretorio(string nome)
        {
            Nome = nome;
            Diretorios = new Dictionary<string, IFileSystemItem>();
            Arquivos = new Dictionary<string, IFileSystemItem>();
        }

        public void CriarDiretorio(string nome)
        {
            Diretorios.Add(nome, new Diretorio(nome));
        }

        public void AdicionarArquivo(Arquivo arquivo)
        {
            Arquivos.Add(arquivo.Nome, arquivo);
        }

        public bool ExisteDiretorio(string nome)
        {
            return Diretorios.ContainsKey(nome);
        }

        public List<Diretorio> Filter(Predicate<Diretorio> predicate)
        {
            var diretoriosRetornados = new List<Diretorio>();
            foreach (var item in Diretorios)
            {
                diretoriosRetornados.AddRange(((Diretorio)item.Value).Filter(predicate));
            }
            if(predicate(this))
                diretoriosRetornados.Add(this);
            
            return diretoriosRetornados;
        }

    }
}
