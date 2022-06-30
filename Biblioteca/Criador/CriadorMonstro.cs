using System;
using Biblioteca.Classes;
namespace Biblioteca.Criador
{
    public static class CriadorMonstro
    {
        public static Monstro GetMonstro(int monstroID)
        {
            switch (monstroID)
            {
                case 801:
                    Monstro morcego =
                        new Monstro(801, "Morcego", 2, 2, CriadorItem.CriarItemJogo(1006), 3, 10);

                    AdicionarItemLoot(morcego, 9001, 25);
                    AdicionarItemLoot(morcego, 9002, 75);
                    return morcego;
                case 802:
                    Monstro aranha =
                        new Monstro(802, "Aranha", 10, 10, CriadorItem.CriarItemJogo(1007), 4, 25);
                    AdicionarItemLoot(aranha, 9003, 25);
                    AdicionarItemLoot(aranha, 9004, 75);
                    return aranha;
                case 803:
                    Monstro capivara =
                        new Monstro(803, "Capivara", 20, 20, CriadorItem.CriarItemJogo(1008), 10, 50);
                    AdicionarItemLoot(capivara, 9005, 25);
                    AdicionarItemLoot(capivara, 9006, 75);
                    return capivara;
                case 804:
                    Monstro dragao =
                        new Monstro(804, "Dragão", 20, 20, CriadorItem.CriarItemJogo(1009), 10, 50);
                    AdicionarItemLoot(dragao, 9005, 25);
                    AdicionarItemLoot(dragao, 9006, 75);
                    return dragao;
                default:
                    throw new ArgumentException(string.Format("TipoMonstro '{0}' não existe", monstroID));
            }
        }
        private static void AdicionarItemLoot(Monstro monstro, int itemID, int porcentagem)
        {
            if (RandomNumberGenerator.NumberBetween(1, 100) <= porcentagem)
            {
                monstro.Inventario.Add(CriadorItem.CriarItemJogo(itemID));
            }
        }
    }
}