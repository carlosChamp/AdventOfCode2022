using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AdventOfCode2022.Commands.Day9
{
    internal class KnotMap
    {
        LinkedList<Point> knotListPosition = new LinkedList<Point>();
        int minX, minY, maxX, maxY;


        public KnotMap()
        {
            Size = 2;
            StartPoint = new Point(0, 0);
            generateBodyStructure();
        }
        public KnotMap(int size)
        {
            Size = size;
            StartPoint = new Point(0, 0);
            generateBodyStructure();
        }
        public KnotMap(int size, Point startPoint)
        {
            Size = size;
            StartPoint = startPoint;
            generateBodyStructure();
        }

        private void generateBodyStructure()
        {
            knotListPosition.Clear();
            LinkedListNode<Point> curr = knotListPosition.AddFirst(StartPoint);
            for (int i = 0; i < Size - 1; i++)
            {
                curr = knotListPosition.AddAfter(curr, ClonePoint(StartPoint));
            }
            Footprints.Add(StartPoint);
        }

        public Point StartPoint { get; private set; }

        public int Size { get; set; }

        public Point HeadPosition
        {
            get
            {
                return knotListPosition.First();

            }
        }
        public Point TailPosition
        {
            get
            {
                return knotListPosition.Last();
            }
        }

        private HashSet<Point> Footprints { get; set; } = new HashSet<Point>();

        internal void Reset()
        {
            Footprints.Clear();
            generateBodyStructure();
        }

        internal void Walk(Direcao direcao, int passos)
        {
            for (int i = 0; i < passos; i++)
            {
                this.moveHeadAndTail(direcao);
            }
        }

        private void moveHeadAndTail(Direcao direcao)
        {
            (int x, int y) offsetValues = offsetPelaDirecao(direcao);
            var first = knotListPosition.First;
            if (first == null)
                throw new Exception("Aconteceu algo errado ao encontrar o primeiro nó. Verifique os parâmetros.");
            first.ValueRef.Offset(offsetValues.x, offsetValues.y);
            atualizaMinimoMaximo(first.Value);
            if (first.Next != null)
                this.moveTailToHeadIfNeeded(first.Next);
        }

        private void atualizaMinimoMaximo(Point value)
        {
            if (value.X < minX) minX = value.X;

            if (value.X > maxX) maxX = value.X;

            if (value.Y < minY) minY = value.Y;

            if (value.Y > maxY) maxY = value.Y;
        }

        private bool moveTailToHeadIfNeeded(LinkedListNode<Point> knot)
        {
            if (knot == null)
            {
                this.Footprints.Add(TailPosition);
                return false;
            }

            (int x, int y) direcaoParaCauda;

            if (DistanceBetweenKnots(knot.Value, knot.Previous?.Value, out direcaoParaCauda) < 2)
                return false;


            knot.ValueRef.Offset(direcaoParaCauda.x, direcaoParaCauda.y);
#pragma warning disable CS8604 // Função recursiva, o nulo é condição de parada.
            return moveTailToHeadIfNeeded(knot.Next);
#pragma warning restore CS8604 // Função recursiva, o nulo é condição de parada.
        }

        private double DistanceBetweenKnots(Point actual, Point? previous, out (int x, int y) moreDistanceIn)
        {
            if(!previous.HasValue)
                throw new ArgumentNullException(nameof(previous));

            int deltaX = previous.Value.X - actual.X;
            int deltaY = previous.Value.Y - actual.Y;

            moreDistanceIn.y = Math.Clamp(deltaY, -1, 1);
            moreDistanceIn.x = Math.Clamp(deltaX, -1, 1);

            return Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
        }

        private Direcao determinarMaiorDiferencaPeloDelta(int deltaX, int deltaY)
        {
            if (Math.Abs(deltaX) > Math.Abs(deltaY))
            {
                if (deltaX >= 0)
                    return Direcao.LEFT;
                else
                    return Direcao.RIGHT;
            }
            else
            {
                if (deltaY >= 0)
                    return Direcao.DOWN;
                else
                    return Direcao.UP;
            }

        }

        private (int x, int y) offsetPelaDirecao(Direcao direcao)
        {
            switch (direcao)
            {
                case Direcao.UP:
                    return (0, 1);
                case Direcao.DOWN:
                    return (0, -1);
                case Direcao.RIGHT:
                    return (1, 0);
                default:
                case Direcao.LEFT:
                    return (-1, 0);
            }
        }

        private static Point ClonePoint(Point original)
        {
            return new Point(original.X, original.Y);
        }

        internal void InterpretEntry(string command)
        {
            if (string.IsNullOrEmpty(command))
                return;

            string[] parametros = command.Split(" ");
            char dir = char.Parse(parametros[0]);
            if (!int.TryParse(parametros[1], out int quantidade))
                throw new ArgumentException("Comando no formato incorreto.");

            this.Walk((Direcao)dir, quantidade);
        }

        internal string Print(bool printKnot = false, bool debug = false)
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = minY; i <= maxY; i++)
            {
                string linha = string.Empty;
                for (int j = minX; j <= maxX + 1; j++)
                {
                    linha += printNode(printKnot, i, j, debug);

                }
                stringBuilder.Insert(0, linha + "\r\n");
            }

            return stringBuilder.ToString();
        }

        private string printNode(bool printKnot, int i, int j, bool debug)
        {
            Func<string, string, string, string> formatString =
                (string valor1, string valor2, string altValue) =>
            {
                return debug ? $"({valor1,4},{valor2,4})" : altValue;
            };

            string linha = String.Empty;
            Point tempMapPoint = new(j, i);
            int knotPosition = knotListPosition.ToList().FindIndex(k => k == tempMapPoint);
            if (i == StartPoint.Y && j == StartPoint.X)
                linha += formatString("s", "s", "s");
            else if (tempMapPoint == knotListPosition.Last())
                linha += formatString("#", "#", "#");
            else if (tempMapPoint == knotListPosition.First() && printKnot)
                linha += formatString("H", "H", "H");
            else if (knotPosition != -1 && printKnot)
                linha += formatString(knotPosition.ToString(), knotPosition.ToString(), knotPosition.ToString());
            else
                linha += Footprints.Contains(tempMapPoint) ?
                    formatString("#", "#", "#") : formatString(j.ToString(), i.ToString(), ".");
            return linha;
        }

        internal int CountFootprints()
        {
            if (Footprints == null)
                return 0;
            HashSet<Point> pegadasUnicas = Footprints.Distinct().ToHashSet();

            if (!pegadasUnicas.Contains(TailPosition))
                return pegadasUnicas.Count() + 1;

            return pegadasUnicas.Count();

        }
    }
}