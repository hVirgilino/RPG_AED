using System;
using System.Collections.Generic;
using System.Collections.ObjectModel; 
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Tela;

namespace Biblioteca.Classes
{
    public class Jogador : Personagem
    {
        private string Classe { get; set; }
        private int XP { get; set; }
        public int GetXP()
        {
            return XP;
        }

        public void SetXP(int value)
        {
            XP = value;
        }
        public bool PrimeiraVezMercador { get; set; } = true;

        public Jogador(string nome, int xp,
                      int maxHP, int hpAtual, int dinheiro, string classe, int nivel) :
            base(nome, maxHP, hpAtual, dinheiro, new List<ItemJogo>(), nivel)
        {
            Classe = classe;
            XP = xp;
        }

        public void ReceberXP(int xp)
        {
            XP += xp;

            if(XP > 100)
            {
                int algo = XP / 100;

                for (int k = 0; k < algo; k++)
                {
                    XP -= 100;
                    Nivel++;
                    HPAtual = MaxHP;
                    EscreverLento.EscreverLinha($"Parabéns! Você subiu para o nível {Nivel}!");

                }
            }
        }

        public void ExibirStatus()
        {
            Console.Clear();
            if(Nome.ToLower() == "andré"|| Nome.ToLower() == "andre")
            {
                Imagens.Jogador(4);
            }
            else
            {
                switch (HPAtual)
                {
                    case > 0 when HPAtual >= (MaxHP * 0.50):
                        Imagens.Jogador(1);
                        break;
                    case > 0 when (HPAtual > (MaxHP * 0.25)) && (HPAtual < (MaxHP * 0.50)):
                        Imagens.Jogador(2);
                        break;
                    case > 0 when HPAtual < (MaxHP * 0.25):
                        Imagens.Jogador(3);
                        break;
                }
            }
            foreach (var arma in Inventario)
            {
                if (arma is Arma)
                {
                    ArmaAtual = (Arma)arma;
                }
            }
            EscreverLento.EscreverLinha(ToString(), 10);

            EscreverLento.EscreverLinha("\nAperte qualquer tecla para voltar");
            Console.ReadKey();
            return;
        }

        public override string ToString()
        {
            return "Nome: " + Nome 
                 + "\nVida: " + HPAtual 
                 + "\nNível: " + Nivel 
                 + "\nXP: " + XP
                 + "\nDinheiro: " + Dinheiro + " reais"
                 + "\nArma: " + (ArmaAtual == null ? "Sem arma" : ArmaAtual.Nome) 
                 + "\n";
        }
    }
}
