using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Classes;

namespace Biblioteca.Criador
{
    public static class CriadorMundo
    {
        public static Mundo CriarMundo()
        {
            Mundo novoMundo = new();
            novoMundo.CriarLocal(0, 0, "Instalação",
                "Instalação temporária feita para descansar enquanto cumpre a missão de resgatar a princesa.");

            novoMundo.CriarLocal(0, 1, "Torre",
                "Onde se encontra o objetivo de sua missão, a princesa, no mais alto nível.");

            novoMundo.CriarLocal(0, 2, "Interior da Torre",
                "Interior da Torre, Térreo");
            novoMundo.LocalEm(0, 2).CriarMonstroAqui(801, 2);
            novoMundo.LocalEm(0, 2).CriarMonstroAqui(802, 1);

            novoMundo.CriarLocal(0, 3, "Interior da Torre",
                "Interior da Torre, 1º Andar");
            novoMundo.LocalEm(0, 3).CriarMonstroAqui(801, 5);
            novoMundo.LocalEm(0, 3).CriarMonstroAqui(802, 2);
            novoMundo.LocalEm(0, 3).CriarMonstroAqui(803, 1);

            novoMundo.CriarLocal(0, 4, "Interior da Torre",
                "Interior da Torre, 2º Andar");
            novoMundo.LocalEm(0, 4).CriarMonstroAqui(801, 5);
            novoMundo.LocalEm(0, 4).CriarMonstroAqui(802, 5);
            novoMundo.LocalEm(0, 4).CriarMonstroAqui(803, 2);

            novoMundo.CriarLocal(0, 5, "Interior da Torre",
                "Interior da Torre, 3º Andar");
            novoMundo.LocalEm(0, 5).CriarMonstroAqui(801, 5);
            novoMundo.LocalEm(0, 5).CriarMonstroAqui(802, 5);
            novoMundo.LocalEm(0, 5).CriarMonstroAqui(803, 5);
            novoMundo.LocalEm(0, 5).CriarMonstroAqui(804, 1);


            novoMundo.CriarLocal(-1, 0, "Caverna dos Morcegos",
                "Moradores dizem ouvir barulhos 'vivos'");
            novoMundo.LocalEm(-1, 0).CriarMonstroAqui(801, 15);

            novoMundo.CriarLocal(-2, 0, "Bosque das Aranhas",
                "Moradores dizem ouvir barulhos 'vivos'");
            novoMundo.LocalEm(-2, 0).CriarMonstroAqui(802, 15);

            novoMundo.CriarLocal(-3, 0, "Lago das Capivaras",
                "Moradores dizem ouvir barulhos 'vivos'");
            novoMundo.LocalEm(-3, 0).CriarMonstroAqui(803, 15);


            novoMundo.CriarLocal(1, 0, "Mercado",
                "Mercado local");
            novoMundo.LocalEm(1, 0).CriarMonstroAqui(801);
            novoMundo.LocalEm(1, 0).CriarMercadorAqui(1);

            return novoMundo;
        }
    

    }
}
