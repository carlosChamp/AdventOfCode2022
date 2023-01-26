using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2022.Commands.Day9
{
    internal enum Direcao
    {
        UP = 'U',
        DOWN = 'D',
        RIGHT = 'R',
        LEFT = 'L'
    }

    internal static class DirecaoExtensoes
    {
        internal static Direcao Inverter(this Direcao direcao)
        {
            switch (direcao)
            {
                case Direcao.UP:
                    return Direcao.DOWN;
                case Direcao.DOWN:
                    return Direcao.UP;
                case Direcao.RIGHT:
                    return Direcao.LEFT;
                default:
                case Direcao.LEFT:
                    return Direcao.RIGHT;

            }
        }
    }
}
