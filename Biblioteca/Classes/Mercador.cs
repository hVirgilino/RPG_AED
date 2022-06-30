using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Classes
{
    public class Mercador : Personagem
    {
        public int ID { get; set; }

        public Mercador(int id, string nome) : base(nome, 9999, 9999, 9999, new List<ItemJogo>())
        {
            ID = id;
        }
    }
}

