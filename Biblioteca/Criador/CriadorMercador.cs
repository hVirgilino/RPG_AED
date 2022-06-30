using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Classes;

namespace Biblioteca.Criador
{
    public static class CriadorMercador
    {
        public static Mercador GetMercador(int id)
        {
            switch (id)
            {
                case 1:
                    Mercador andre = new(1, "André");
                    andre.Inventario.Add(CriadorItem.GetItemJogo(1002));
                    andre.Inventario.Add(CriadorItem.GetItemJogo(1003));
                    andre.Inventario.Add(CriadorItem.GetItemJogo(1004));
                    andre.Inventario.Add(CriadorItem.GetItemJogo(1005));
                    
                    return andre;

                default:
                    throw new ArgumentException(string.Format("TipoMercador '{0}' não existe", id));
            }
        }
    }
}
