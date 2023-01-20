using AdventOfCode2022.Commands.Day7;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Commands
{
    internal class Day7Command : IDayCommand
    {
        public static int Day => 7;

        public static string InputFileName => CommandUtils.GetInputFilePath(Day);

        public bool IsPartOneComplete => true;

        private const int TOTAL_SPACE = 70000000;
        private const int SPACE_TO_UPDATE = 30000000;
        ElfFileSystem ElfFileSystem = new ElfFileSystem();

        void IDayCommand.Execute()
        {
            string[] inputFileSystem = CommandUtils.GetInput(InputFileName);
            ElfFileSystem.InterpretInput(inputFileSystem);
        }



        string IDayCommand.PrintHeader()
        {
            return "Day 7: No Space Left On Device";
        }

        string IDayCommand.PrintPart1()
        {
            var pastasAte100000 = ElfFileSystem.FindAll(dir => dir.Tamanho <= 100000);
            ulong total = 0ul;
            foreach (var pasta in pastasAte100000)
                total += pasta.Tamanho;
            return total.ToString();
        }

        string IDayCommand.PrintPart2()
        {
            ElfFileSystem.setFolderSystemFolder();
            ulong usedSpaceNow = ElfFileSystem.getDirectorySize();
            ulong howMuchSpaceToUpdate = SPACE_TO_UPDATE - (TOTAL_SPACE - usedSpaceNow);
            List<Diretorio> menorDiretorioQueCumpreOCriterio = ElfFileSystem.FindAll(dir => dir.Tamanho >= howMuchSpaceToUpdate)
                                                                            .OrderBy(dir => dir.Tamanho)
                                                                            .ToList();

            return menorDiretorioQueCumpreOCriterio.First().Tamanho.ToString();
        }
    }
}
