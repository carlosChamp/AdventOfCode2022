namespace AdventOfCode2022.Commands
{
    internal interface IMoveStrategy<T>
    {
        public void Move(int quantidade, int from, int to, Pilhas<T> pilha);
    }
}