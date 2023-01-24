using System.Runtime.CompilerServices;
using System.Text;
using System.Xml;

[assembly: InternalsVisibleTo("TestesUnitarios")]
namespace AdventOfCode2022.Commands.Day8
{

    internal class TreeGrid
    {
        Tree[,] Trees;
        bool[,] VisibleTreeMap;
        int linhas, colunas;
        public bool ResolvedGrid { get; set; }

        internal int CountVisible()
        {
            if (!ResolvedGrid)
                ResolveTreeGrid();

            int count = 0;
            foreach (var item in Trees)
            {
                count += item.Visible ? 1 : 0;
            }

            return count;
        }

        internal int MaxScenicScore()
        {
            if (!ResolvedGrid)
                ResolveTreeGrid();

            int max = 0;
            foreach (var item in Trees)
            {
                if (item.ScenicScore > max)
                    max = item.ScenicScore;
            }

            return max;
        }

        internal void SetGrid(string[] input)
        {
            if (input == null || input.Length == 0)
                throw new ArgumentException("Necessário informar pelo menos uma linha");

            linhas = input.Length;
            colunas = input[0].Length;

            Trees = new Tree[linhas, colunas];
            VisibleTreeMap = new bool[linhas, colunas];
            for (int linha = 0; linha < linhas; linha++)
            {
                for (int coluna = 0; coluna < colunas; coluna++)
                {
                    int heigth = int.Parse(input[linha][coluna].ToString());
                    Trees[linha, coluna] = new Tree() { Heigth = heigth };
                }
            }
            ResolvedGrid = false;
        }

        internal void ResolveTreeGrid()
        {
            for (int linha = 0; linha < linhas; linha++)
            {
                for (int coluna = 0; coluna < colunas; coluna++)
                {
                    validaLinha(Trees[linha, coluna], linha, coluna);
                    validaColuna(Trees[linha, coluna], linha, coluna);
                    VisibleTreeMap[linha, coluna] = Trees[linha, coluna].Visible;
                    CalculateScoreForTree(Trees[linha, coluna], linha, coluna);
                }
            }
            ResolvedGrid = true;
        }

        private void validaLinha(Tree treeAtual, int linha, int coluna)
        {
            if (linha == 0 || linha == linhas - 1)
            {
                treeAtual.VisibleByTop = linha == 0;
                treeAtual.VisibleByDown = linha == linhas - 1;
                return;
            }

            int maiorParaCima = 0;
            int maiorParaBaixo = 0;
            for (int i = linha - 1; i >= 0; i--)
            {
                Tree compareTree = Trees[i, coluna];
                if (compareTree.VisibleByTop)
                {
                    maiorParaCima = compareTree.Heigth;
                    break;
                }

                if (compareTree.Heigth > maiorParaCima)
                {
                    maiorParaCima = compareTree.Heigth;
                }
            }

            for (int i = linha + 1; i < linhas; i++)
            {
                Tree compareTree = Trees[i, coluna];
                if (compareTree.Heigth > maiorParaBaixo)
                {
                    maiorParaBaixo = compareTree.Heigth;
                }
            }


            if (treeAtual.Heigth > maiorParaCima)
                treeAtual.VisibleByTop = true;

            if (treeAtual.Heigth > maiorParaBaixo)
                treeAtual.VisibleByDown = true;
        }

        private void validaColuna(Tree treeAtual, int linha, int coluna)
        {
            if (coluna == 0 || coluna == colunas - 1)
            {
                treeAtual.VisibleByLeft = coluna == 0;
                treeAtual.VisibleByRight = coluna == colunas - 1;
                return;
            }

            int maiorParaEsquerda = 0;
            int maiorParaDireita = 0;
            for (int i = coluna - 1; i >= 0; i--)
            {
                Tree compareTree = Trees[linha, i];
                if (compareTree.VisibleByLeft)
                {
                    maiorParaEsquerda = compareTree.Heigth;
                    break;
                }

                if (compareTree.Heigth > maiorParaEsquerda)
                {
                    maiorParaEsquerda = compareTree.Heigth;
                }
            }

            for (int i = coluna + 1; i < colunas; i++)
            {
                Tree compareTree = Trees[linha, i];
                if (compareTree.Heigth > maiorParaDireita)
                {
                    maiorParaDireita = compareTree.Heigth;
                }
            }

            if (treeAtual.Heigth > maiorParaEsquerda)
                treeAtual.VisibleByLeft = true;

            if (treeAtual.Heigth > maiorParaDireita)
                treeAtual.VisibleByRight = true;

        }

        internal string PrintVisible()
        {
            if (!ResolvedGrid)
                ResolveTreeGrid();

            StringBuilder print = new StringBuilder();
            for (int i = 0; i < linhas; i++)
            {
                for (int j = 0; j < colunas; j++)
                {
                    print.Append(@$"{(VisibleTreeMap[i, j] ? '1' : '0')} ");
                }
                print.Append("\n");
            }
            return print.ToString();
        }

        private void CalculateScoreForTree(Tree tree, int linha, int coluna)
        {
            int linhaInicial = linha;
            int colunaInicial = coluna;
            int scenicScore = 1;
            foreach (TreeDirection direcao in Enum.GetValues<TreeDirection>())
            {
                linha = linhaInicial;
                coluna = colunaInicial;
                Tree? compareTree = Walk(direcao, ref linha, ref coluna);
                int distanciaLinear = 0;
                while (compareTree != null)
                {
                    int comparedTreeIndex = compareTree.CompareTo(tree);
                    if (comparedTreeIndex < 0)
                    {
                        distanciaLinear++;
                        compareTree = Walk(direcao, ref linha, ref coluna);
                    }
                    else
                    {
                        if (compareTree != null)
                            distanciaLinear++;
                        break;
                    }
                }

                scenicScore *= distanciaLinear;
                if (scenicScore == 0)
                    break;
            }
            tree.ScenicScore = scenicScore;
        }

        private Tree? Walk(TreeDirection treeDirection, ref int linha, ref int coluna)
        {
            (int x, int y) directions = DirectionToPoints(treeDirection);
                        
            if (linha + directions.x < 0 || linha + directions.x == linhas)
                return null;

            if (coluna + directions.y < 0 || coluna + directions.y == linhas)
                return null;

            linha += directions.x;
            coluna += directions.y;
            return Trees[linha, coluna];

        }

        private static (int dirX, int dirY) DirectionToPoints(TreeDirection treeDirection)
        {
            int dirX = 0;
            int dirY = 0;
            switch (treeDirection)
            {
                case TreeDirection.top:
                    dirX = -1;
                    break;
                case TreeDirection.left:
                    dirY = -1;
                    break;
                case TreeDirection.right:
                    dirY = 1;
                    break;
                case TreeDirection.down:
                    dirX = 1;
                    break;
                default:
                    break;
            }
            return (dirX, dirY);
        }
    }
}