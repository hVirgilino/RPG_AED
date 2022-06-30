using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Tela;
using Spectre.Console;

namespace Biblioteca.Classes
{
    public class Batalha
    {
        private readonly Jogador _jogador;
        private readonly Monstro _oponente;
        private readonly Menus _menu;
        private string _registro = "";
        private int _indRegistro = 1;
        private enum Combatente
        {
            Jogador,
            Oponente
        }
        private static Combatente PrimeiroAtaque =>
            RandomNumberGenerator.NumberBetween(1, 2) == 1 ?
                Combatente.Jogador :
                Combatente.Oponente;

        public Batalha(Jogador jogador, Monstro oponente, Menus menu)
        {
            _jogador = jogador;
            _oponente = oponente;
            _menu = menu;

            EscreverLento.EscreverLinha($"\nVocê encontrou um(a) {_oponente.Nome}!");
            if (PrimeiroAtaque == Combatente.Oponente)
            {
                EscreverLento.EscreverLinha("Você foi surpreendido(a)!");
                Console.ReadKey();
                AtacarJogador();
            }
            else
            {
                EscreverLento.EscreverLinha("Você surpreendeu o inimigo! Ataque!!!");
                Console.ReadKey();
                AtacarOponente();
            }
        }

        public string MenuJogador()
        {
            Console.Clear();
            EscreverLento.EscreverLinha("Registro da batalha:", 5);
            Console.WriteLine(_registro);

            var escolha = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("O que fazer?")
            .PageSize(10)
            .AddChoices(new[] {
                "Atacar", "Inventario", "Status",
                "Fugir"
            }));


            return escolha;

        }
        public void AtacarOponente()
        {
            string escolha = MenuJogador();

            switch (escolha)
            {
                case "Atacar":
                    Atacar(_jogador, _oponente);
                    if (_oponente.TaVivo)
                    {
                        AtacarJogador();
                        
                    }
                    else
                    {
                        OponenteMorto();
                        
                    }
                    return;

                case "Inventario":
                    _menu.ExibirInventario();
                    AtacarOponente();
                    return;

                case "Status":
                    _menu.ExibirStatus();
                    AtacarOponente();
                    return;

                case "Fugir":
                    if (RandomNumberGenerator.NumberBetween(1, 100) <= 10)
                    {
                        EscreverLento.EscreverLinha("Os monstros conseguiram te alcançar!!!");
                        AtacarJogador();
                        return;
                    }
                    else
                    {
                        if (_jogador.PrimeiraVezMercador)
                        {
                            _menu.TelaMercador(3);
                            MenuJogador();
                            return;
                        }
                        else
                        {
                            EscreverLento.EscreverLinha("\nVocê consegue fugir.");
                            Console.ReadKey();
                            _menu.Andar();
                            return;
                        }
                    }

                default:
                    break;
            }

            
        }

        private void AtacarJogador()
        {
            Atacar(_oponente, _jogador);
            Console.ReadKey();

            if (_jogador.TaVivo)
            {
                AtacarOponente();
                
            }
            else
            {
                JogadorMorto();

            }


        }


        private void OponenteMorto()
        {
            EscreverLento.EscreverLinha($"\nVocê derrotou o(a) {_oponente.Nome}!");
            EscreverLento.EscreverLinha($"Você recebeu {_oponente.RecompensaXP} pontos de experiência.");
            _jogador.ReceberXP(_oponente.RecompensaXP);

            EscreverLento.EscreverLinha($"Você recebeu {_oponente.Dinheiro} reais.");
            _jogador.ReceberDinheiro(_oponente.Dinheiro);

            foreach (ItemJogo itemJogo in _oponente.Inventario)
            {
                EscreverLento.EscreverLinha($"Você recebeu um(a) {itemJogo.Nome}.");
                _jogador.Inventario.Add(itemJogo);
            }

            _jogador.PrimeiraVezMercador = false;

        }
        private void JogadorMorto()
        {
            EscreverLento.EscreverLinha($"\nO(A) {_oponente.Nome} te derrotou!");
            Console.ReadKey();
            _menu.TelaFimDeJogo();

        }

        public void Atacar(Personagem autor, Personagem vitima)
        {
            int ch;
            string nomeAutor = (autor is Jogador) ? "Você" : $"O(A) {autor.Nome.ToLower()}";
            string nomeVitima = (vitima is Jogador) ? "você" : $"o(a) {vitima.Nome.ToLower()}";

            if ((ch = RandomNumberGenerator.NumberBetween(1, 100)) > 10)
            {
                string critico = ch > 90 ? "CRÍTICO!!! " : "";

                int dano = RandomNumberGenerator.NumberBetween(autor.ArmaAtual.MinDano, autor.ArmaAtual.MaxDano) * (ch > 90 ? 2 : 1);


                string resultado = $"{critico}{nomeAutor} acertou {nomeVitima} com {dano} ponto{(dano > 1 ? "s" : "")} de dano.";
                _registro += _indRegistro + " - " + resultado + "\n";
                _indRegistro++;
                EscreverLento.EscreverLinha(resultado);
                Thread.Sleep(500);

                vitima.ReceberDano(dano);
            }
            else
            {
                string resultado = $"{nomeAutor} errou {nomeVitima}.";
                _registro += _indRegistro + " - " + resultado + "\n";
                _indRegistro++;
                EscreverLento.EscreverLinha(resultado);
            }
        }


    }
}

