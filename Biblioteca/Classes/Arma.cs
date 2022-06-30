using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Classes
{
    public class Arma : ItemJogo
    {
        private int minDano;
        public int MinDano { get => minDano; private set => minDano = value; }
        private int maxDano;
        public int MaxDano { get => maxDano; private set => maxDano = value; }

        public Arma(int itemID, string nome, int preco, string tipo, int minDano, int maxDano, int minNivelNecessario) : base(itemID, nome, preco, tipo, minNivelNecessario)
        {
            MinDano = minDano;
            MaxDano = maxDano;
            MinNivelNecessario = minNivelNecessario;
        }

    }
}
