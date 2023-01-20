using AdventOfCode2022.Commands.Day7;

namespace AdventOfCode2022.Commands
{
    internal class ElfFileSystem
    {
        private const string COMMANDLINE_PREFIX = "$";
        private const string COMMAND_CHECKDIR = "cd";
        private const string COMMAND_LISTDIR = "ls";
        private const int DEFAULT_COMMANDLINE_COMMANDSIZE = 4;
        private const string DEFAULT_BACKFOLDER_COMMAND = "..";
        int linhasProcessadas = 1;
        string[] InputFileSystem;
        Stack<Diretorio> DiretorioAtual;

        public ElfFileSystem()
        {
            DiretorioAtual = new Stack<Diretorio>();
            DiretorioAtual.Push(new Diretorio("/"));
        }
        internal void InterpretInput(string[] inputFileSystem)
        {
            InputFileSystem = inputFileSystem;
            while (linhasProcessadas < inputFileSystem.Length)
            {
                interpretCommand(inputFileSystem[linhasProcessadas]);
                linhasProcessadas++;
            }
        }

        private void interpretCommand(string command)
        {
            if (string.IsNullOrEmpty(command))
                return;

            if (command.StartsWith(COMMANDLINE_PREFIX))
            {
                switch (command.Substring(2, 2))
                {
                    case COMMAND_CHECKDIR:
                        cd(command[DEFAULT_COMMANDLINE_COMMANDSIZE..]);
                        break;
                    case COMMAND_LISTDIR:
                        ls(command[DEFAULT_COMMANDLINE_COMMANDSIZE..]);
                        break;
                    default:
                        break;
                }
            }

        }

        internal ulong getDirectorySize()
        {
            return (DiretorioAtual.Peek()).Tamanho;
        }

        internal void setFolderSystemFolder()
        {
            while (DiretorioAtual.Count > 1)
                DiretorioAtual.Pop();
        }

        internal void cd(string commandParams)
        {
            string nomePasta = commandParams.Trim();

            if (DiretorioAtual.Peek().ExisteDiretorio(nomePasta))
            {
                DiretorioAtual.Push((Diretorio)DiretorioAtual.Peek().Diretorios[nomePasta]);
            }
            else if (nomePasta == DEFAULT_BACKFOLDER_COMMAND)
            {
                DiretorioAtual.Pop();
            }
            else
                throw new ArgumentException("Comando incorreto");

        }

        internal void ls(string commandParams)
        {
            bool endOfDirectory = false;
            string line = InputFileSystem[linhasProcessadas];
            do
            {
                linhasProcessadas++;
                line = InputFileSystem[linhasProcessadas];
                if (linhasProcessadas + 1 >= InputFileSystem.Length ||
                    InputFileSystem[linhasProcessadas + 1].StartsWith("$"))
                    endOfDirectory = true;

                if (line.StartsWith("dir"))
                    (DiretorioAtual.Peek()).CriarDiretorio(line.Substring(4));
                else
                {
                    Arquivo tempArquivo = CriarAquivoPorString(line);
                    DiretorioAtual.Peek().AdicionarArquivo(tempArquivo);
                }
            } while (!endOfDirectory);

        }

        public List<Diretorio> FindAll(Predicate<Diretorio> predicate)
        {
            return DiretorioAtual.Last().Filter(predicate);
        }


        private static Arquivo CriarAquivoPorString(string line)
        {
            string[] parametros = line.Split(" ");
            string nome;
            ulong tamanho;
            tamanho = ulong.Parse(parametros[0]);
            nome = parametros[1];
            Arquivo tempArquivo = new Arquivo(nome, tamanho);
            return tempArquivo;
        }

        
    }
}