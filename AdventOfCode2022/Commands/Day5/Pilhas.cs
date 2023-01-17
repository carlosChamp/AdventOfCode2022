using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace AdventOfCode2022.Commands
{
    internal class Pilhas<T>
    {
        public IMoveStrategy<T> MoveStrategy;

        public List<Stack<T>> CaixasEmpilhadas { get; set; } = new List<Stack<T>>();

        public Pilhas()
        {
            MoveStrategy = new CrateMover9000<T>();
        }
        public Pilhas(IMoveStrategy<T> moveStrategy)
        {
            MoveStrategy = moveStrategy;
        }

        public void Push(int pilha, T valor)
        {
            if (pilha > CaixasEmpilhadas.Count)
                CaixasEmpilhadas.Add(new Stack<T>());

            CaixasEmpilhadas[pilha - 1].Push(valor);
        }

        public T Pop(int pilha)
        {
            return CaixasEmpilhadas[pilha - 1].Pop();
        }

        public void Move(int quantidade, int from, int to)
        {
            MoveStrategy.Move(quantidade, from, to, this);
        }

        public string Print()
        {
            StringBuilder topChars = new StringBuilder();
            for (int i = 0; i < CaixasEmpilhadas.Count; i++)
            {
                topChars.Append(CaixasEmpilhadas[i].Peek());
            }
            return topChars.ToString();
        }  

        internal void MoveByCommand(string line)
        {
            Regex regex = new Regex(@"move (?<quantidade>[0-9]+) from (?<from>[0-9]) to (?<to>[0-9])");
            var match = regex.Match(line);
            int quantidade = int.Parse(match.Groups["quantidade"].Value);
            int from = int.Parse(match.Groups["from"].Value);
            int to = int.Parse(match.Groups["to"].Value);
            Move(quantidade, from, to);
        }
    }
}