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
            knotListPosition.AddFirst(StartPoint);
            var curr = knotListPosition.First;
            for (int i = 0; i < Size - 1; i++)
            {
                knotListPosition.AddAfter(curr, new Point(0, 0));
                curr = curr.Next;
            }
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
            first.ValueRef.Offset(offsetValues.x, offsetValues.y);
            atualizaMinimoMaximo(first.Value);
            this.Footprints.Add(TailPosition);
            if (first.Next != null)
                this.moveTailToHeadIfNeeded(first.Next, direcao);
        }

        private void atualizaMinimoMaximo(Point value)
        {
            if (value.X < minX) minX = value.X;

            if (value.X > maxX) maxX = value.X;

            if (value.Y < minY) minY = value.Y;

            if (value.Y > maxY) maxY = value.Y;
        }

        private bool moveTailToHeadIfNeeded(LinkedListNode<Point> knot, Direcao lastHeadMovement)
        {
            if (knot == null)
            {
                this.Footprints.Add(TailPosition);
                return false;
            }

            if (this.DistanceBetweenKnots(knot.Value, knot.Previous.Value) < 2)
                return false;

            (int x, int y) direcaoParaCauda = offsetPelaDirecao(lastHeadMovement.Inverter());
            knot.Value = ClonePoint(knot.Previous.Value);
            knot.ValueRef.Offset(direcaoParaCauda.x, direcaoParaCauda.y);
            return moveTailToHeadIfNeeded(knot.Next, lastHeadMovement);
        }

        private double DistanceBetweenKnots(Point actual, Point previous)
        {
            int deltaX = (actual.X - previous.X);
            int deltaY = (actual.Y - previous.Y);
            return Math.Sqrt(Math.Pow(deltaX, 2) + Math.Pow(deltaY, 2));
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

        internal string Print()
        {
            StringBuilder stringBuilder = new StringBuilder();

            for (int i = minY; i <= maxY; i++)
            {
                string linha = string.Empty;
                for (int j = minX; j <= maxX + 1; j++)
                {
                    Point tempMapPoint = new(j, i);
                    if (i == 0 && j == 0)
                        linha += "s";
                    else if (tempMapPoint == knotListPosition.Last())
                        linha += "#";
                    else
                        linha += Footprints.Contains(tempMapPoint) ?
                            "#" : ".";

                }
                stringBuilder.Insert(0, linha + "\r\n");
            }

            return stringBuilder.ToString();
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