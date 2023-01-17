using System.Drawing;

namespace AdventOfCode2022.Commands
{
    internal class CrateMover9000<T> : IMoveStrategy<T>
    {
        public void Move(int quantidade, int from, int to, Pilhas<T> pilha)
        {
            for (int i = 0; i < quantidade; i++)
            {
                T valor = pilha.Pop(from);
                pilha.Push(to, valor);
            }
        }
    }
    internal class CrateMover9001<T> : IMoveStrategy<T>
    {
        public void Move(int quantidade, int from, int to, Pilhas<T> pilha)
        {
            Stack<T> tempStack = new Stack<T>();
            for (int i = 0; i < quantidade; i++)
            {
                T valor = pilha.Pop(from);
                tempStack.Push(valor);
            }
            for (int i = 0; i < quantidade; i++)
            {
                pilha.Push(to, tempStack.Pop());
            }
        }
    }
}