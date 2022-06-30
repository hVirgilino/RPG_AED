using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Classes;
using Biblioteca.Criador;

namespace Biblioteca.Tela
{
    public class Sessao
    {
        public Jogador JogadorAtual { get; set; }
        public Local LocalAtual { get; set; }
        private Mundo MundoAtual { get; set; }
        public Mercador MercadorAtual { get; set; }


        public Sessao(Jogador jogadorAtual)
        {
            JogadorAtual = jogadorAtual;

            MundoAtual = CriadorMundo.CriarMundo();
            
            LocalAtual = MundoAtual.LocalEm(0, 0);

            MercadorAtual = CriadorMercador.GetMercador(1);


        }

        public bool TemCaminho(string direcao)
        {
            switch (direcao)
            {
                case "Norte":
                    if (MundoAtual.LocalEm(LocalAtual.X, LocalAtual.Y + 1) != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case "Sul":
                    if (MundoAtual.LocalEm(LocalAtual.X, LocalAtual.Y - 1) != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case "Leste":
                    if (MundoAtual.LocalEm(LocalAtual.X + 1, LocalAtual.Y) != null)
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }

                case "Oeste":
                    if (MundoAtual.LocalEm(LocalAtual.X - 1, LocalAtual.Y) != null)
                    {
                        
                        return true;
                        
                    }
                    else
                    {
                        return false;
                    }

                default:
                    return false;
            }
        }

        public void IrProNorte(Menus _menuAtual)
        {
            if (TemCaminho("Norte")) {
                LocalAtual = MundoAtual.LocalEm(LocalAtual.X, LocalAtual.Y + 1);
            }

            if(JogadorAtual.Nivel >= 2)
            {
                ConferePresenca(_menuAtual);
                _menuAtual.Andar();
            }
            
        }
        public void IrProSul(Menus _menuAtual)
        {
            if(TemCaminho("Sul")){
                LocalAtual = MundoAtual.LocalEm(LocalAtual.X, LocalAtual.Y - 1);
            }
            ConferePresenca(_menuAtual);
            _menuAtual.Andar();
        }
        public void IrProLeste(Menus _menuAtual)
        {
            if(TemCaminho("Leste")){
                LocalAtual = MundoAtual.LocalEm(LocalAtual.X + 1, LocalAtual.Y);
            }
            ConferePresenca(_menuAtual);
            _menuAtual.Andar();
        }
        public void IrProOeste(Menus _menuAtual)
        {
            if(TemCaminho("Oeste")){
                LocalAtual = MundoAtual.LocalEm(LocalAtual.X - 1, LocalAtual.Y);
            }

            if (LocalAtual == MundoAtual.LocalEm(0, 0))
            {
                Menus.Tocar(Menus._toqueInstalacao);
                _menuAtual.Iniciar();
            }
        }

        public void IrPra(Menus _menuAtual, int x, int y)
        {
            if (MundoAtual.LocalEm(x, y) != null)
            {
                LocalAtual = MundoAtual.LocalEm(x, y);
                ConferePresenca(_menuAtual);
                _menuAtual.Andar();
            }
            else
            {
                EscreverLento.EscreverLinha("Não há caminho");
                return;
            }
        }

        public void EnfrentarMonstros(Jogador jogadorAtual, Menus menuAtual)
        {
            if (LocalAtual.MonstrosAqui.Any())
            {
                Menus.Tocar(Menus._toqueBatalha);
            }

            foreach (Monstro monstro in LocalAtual.MonstrosAqui)
            {

                    jogadorAtual.ArmaAtual = GetArma(jogadorAtual);

                    if (jogadorAtual.ArmaAtual == null)
                    {
                        Console.Clear();
                        EscreverLento.EscreverLinha("Você não possui uma arma para lutar. Fuja!!!");
                        Console.ReadKey();
                        return;
                    }

                    Batalha batalha = new Batalha(jogadorAtual, monstro, menuAtual);
               

            }
        }

        public bool ProcurarMercador()
        {
            if (LocalAtual.MercadorAqui.Any())
            {
                return true;
            }

            return false;
        }

        public bool ProcurarMonstros()
        {
            if (LocalAtual.MonstrosAqui.Any())
            {
                return true;
            }

            return false;
        }

        public void ConferePresenca(Menus menusAtual)
        {
            if (ProcurarMercador())
            {
                menusAtual.TelaEscolhaMercador();
                return;
            }

            if (ProcurarMonstros())
            {
                menusAtual.TelaMonstros();
                return;
            }
        }

        public string GetNomeLocal(int x, int y)
        {
            if (MundoAtual.LocalEm(x, y) != null)
            {
                return MundoAtual.LocalEm(x, y).Nome;
            }
            else
            {
                return "Não há caminho";
            }
        }

        public static Arma? GetArma(Jogador jogadorAtual)
        {
            foreach (ItemJogo arma in jogadorAtual.Inventario)
            {
                if (arma is Arma arma1)
                {
                    return arma1;
                }
            }

            return null;
        }
        
    }
}

