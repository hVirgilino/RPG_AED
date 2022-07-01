using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Classes
{
    public class Estado
    {
        public Jogador Jogador { get; init; }
        public int X { get; init; }
        public int Y { get; init; }

        public Estado(Jogador jogador, int x, int y)
        {
            Jogador = jogador;
            X = x;
            Y = y;
        }
    }
}
