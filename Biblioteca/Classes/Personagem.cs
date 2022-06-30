using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Criador;

namespace Biblioteca.Classes
{
    public abstract class Personagem
    {
        private string nome;
        public string Nome { get => nome;  protected set => nome = value; }

        private int hpAtual ;
        public int HPAtual { get => hpAtual  ;  protected set => hpAtual  = value; }

        private int maxHP ;
        public int MaxHP { get => maxHP  ;  protected set => maxHP  = value; }

        private int dinheiro ;
        public int Dinheiro { get => dinheiro  ;  protected set => dinheiro  = value; }

        private int nivel;
        public int Nivel { get => nivel ;  protected set => nivel = value; }

        private List<ItemJogo> inventario ;
        public List<ItemJogo> Inventario { get => inventario  ;  protected set => inventario  = value; }

        public bool TaVivo => HPAtual > 0;
        public bool TaMorto => !TaVivo;

        public Arma ArmaAtual { get; set; }

        protected Personagem(string nome, int maxHP, int hpAtual, int dinheiro, List<ItemJogo> lista, int nivel = 1)
        {
            Nome = nome;
            MaxHP = maxHP;
            HPAtual = hpAtual;
            Dinheiro = dinheiro;
            Nivel = nivel;
            Inventario = lista;
            foreach (var arma in Inventario)
            {
                if (arma is Arma)
                {
                    ArmaAtual = (Arma?)arma;
                }
            }
        }

        public void ReceberDano(int dano)
        {
            HPAtual -= dano;

            if (TaMorto)
            {
                HPAtual = 0;
            }
        }

        public void ReceberDinheiro(int dinheiro)
        {
            Dinheiro += dinheiro;
        }

        public void GastarDinheiro(int dinheiro)
        {
            if (dinheiro > Dinheiro)
            {
                EscreverLento.EscreverLinha($"{Nome} só tem {Dinheiro} reais, portanto não consegue gastar {dinheiro} reais");
            }

            Dinheiro -= dinheiro;
        }

        public void AdicionarItemInventario(ItemJogo item)
        {
            this.Inventario.Add(item);
        }

        public void RemoverItemInventario(ItemJogo item)
        {
            this.Inventario.Remove(item);
        }

        public void ExibirInventario()
        {
            int i = 1;
            
            if(this is Jogador){
            
                if (!Inventario.Any())
                {
                    EscreverLento.Escrever("Inventário vazio!\n");
                }
                else
                {
                    foreach (var item in Inventario)
                    {
                        Console.WriteLine($"{i} - {item.Nome} ({item.GetTipo()})");

                        i++;
                    }

                }

            }else if(this is Mercador)
            {
                if (!Inventario.Any())
                {
                    EscreverLento.Escrever("Inventário vazio!\n");
                }
                else
                {
                    foreach (var item in Inventario)
                    {
                        Console.WriteLine($"{i} - {item.Nome} ({item.GetTipo()}) R$ {item.Preco},00");
                        i++;
                    }

                }
            }

        }


    }
}
