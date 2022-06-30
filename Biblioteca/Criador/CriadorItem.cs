    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Classes;

namespace Biblioteca.Criador
{
    public static class CriadorItem
    {
        private static readonly List<ItemJogo> _itensJogoComum = new ();

        static CriadorItem()
        {

            _itensJogoComum.Add(new Arma(1001, "Espada de Madeira", 1, "Arma", 1, 2, 1));
            _itensJogoComum.Add(new Arma(1002, "Espada de Pedra", 5, "Arma", 2, 3, 1));
            _itensJogoComum.Add(new Arma(1003, "Espada de Cobre", 10, "Arma", 3, 5, 2));
            _itensJogoComum.Add(new Arma(1004, "Espada de Aço", 30, "Arma", 5, 9, 4));
            _itensJogoComum.Add(new Arma(1005, "Espada de Diamante", 70, "Arma", 12, 15, 7));

            _itensJogoComum.Add(new Arma(1006, "Presas de Morcego", 10, "Arma", 1, 3, 1));
            _itensJogoComum.Add(new ItemJogo(9001, "Asa de Morcego", 1, "Loot", 1));
            _itensJogoComum.Add(new ItemJogo(9002, "Orelha de Morcego", 2, "Loot", 1));

            _itensJogoComum.Add(new Arma(1007, "Presas de Aranha", 15, "Arma", 2, 5, 1));
            _itensJogoComum.Add(new ItemJogo(9003, "Teia de Aranha", 5, "Loot", 1));
            _itensJogoComum.Add(new ItemJogo(9004, "Olho de Aranha", 8, "Loot", 1));
            
            _itensJogoComum.Add(new Arma(1008, "Garras de Capivara", 20, "Arma", 3, 7, 1));
            _itensJogoComum.Add(new ItemJogo(9005, "Pelo de Capivara", 14, "Loot", 1));
            _itensJogoComum.Add(new ItemJogo(9006, "Dentes de Capivara", 15, "Loot", 1));
            
            _itensJogoComum.Add(new Arma(1009, "Garras de Dragão", 100, "Arma", 10, 20, 7));
            _itensJogoComum.Add(new ItemJogo(9005, "Osso de Dragão", 75, "Loot", 1));
            _itensJogoComum.Add(new ItemJogo(9006, "Sangue de Dragão", 200, "Loot", 1));



        }

        public static ItemJogo CriarItemJogo(int ItemID)
        {
            ItemJogo comumItem = _itensJogoComum.FirstOrDefault(i => i.GetItemID() == ItemID);


            if (comumItem != null)
            {
                if(comumItem is Arma)
                {
                    return comumItem as Arma;
                }

                return comumItem;
            }
            else
            {
            return null;

            }

        }

        public static ItemJogo GetItemJogo(int itemID)
        {
            foreach (ItemJogo itemJogo in _itensJogoComum)
            {
                if (itemJogo.GetItemID() == itemID)
                {
                    return itemJogo;
                }
            }
            return null;
        }
    }
}
