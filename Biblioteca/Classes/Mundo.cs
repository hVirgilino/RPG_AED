using Biblioteca.Criador;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Classes
{
    public class Mundo
    {
        private readonly List<Local> _local = new();
        public void CriarLocal(int x, int y, string nome, string descricao)
        {
            Local local = new(x, y, nome, descricao);

            _local.Add(local);
        }
        public Local LocalEm(int x, int y)
        {
            foreach (Local local in _local)
            {
                if (local.X == x && local.Y == y)
                {
                    return local;
                }
            }
            return null;
        }

    }
}
