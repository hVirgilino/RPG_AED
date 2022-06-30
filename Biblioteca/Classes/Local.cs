using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Criador;

namespace Biblioteca.Classes
{
    public class Local
    {
        private int x;
        private int y;
        private string descricao;
        private string nome;

        public int X { get => x; private set => x = value; }
        public int Y { get => y; private set => y = value; }
        public string Nome { get => nome; private set => nome = value; }
        public string Descricao { get => descricao ; private set => descricao  = value; }
        public List<Monstro> MonstrosAqui { get; set; } = new List<Monstro>();
        public List<Mercador> MercadorAqui { get; set; } = new List<Mercador>();

        public Local(int x, int y, string nome, string descricao)
        {
            X = x;
            Y = y;
            Nome = nome;
            Descricao = descricao;
        }

        public void CriarMonstroAqui(int monstroID)
        {
            if (MonstrosAqui.Exists(m => m.ID == monstroID))
            {
                MonstrosAqui.First(m => m.ID == monstroID);
            }
            else
            {
                MonstrosAqui.Add(CriadorMonstro.GetMonstro(monstroID));
            }
        }

        public void CriarMonstroAqui(int monstroID, int quantidade)
        {
            for (int i = 0; i < quantidade; i++)
            {
                MonstrosAqui.Add(CriadorMonstro.GetMonstro(monstroID));
            }
            
        }

        public void RemoverMonstroDaqui(int monstroID)
        {
            if (MonstrosAqui.Exists(m => m.ID == monstroID))
            {
                MonstrosAqui.RemoveAll(m => m.ID == monstroID);
            }
        }

        public void RemoverMonstrosDaqui()
        {
            foreach(Monstro m in MonstrosAqui.ToList())
            {
                MonstrosAqui.Remove(m);
            }
        }
        public void CriarMercadorAqui(int id)
        {
            if (MercadorAqui.Exists(m => m.ID == id))
            {
                _ = MercadorAqui.First(m => m.ID == id);
            }
            else
            {
                MercadorAqui.Add(CriadorMercador.GetMercador(id));
            }
        }

    }
}
