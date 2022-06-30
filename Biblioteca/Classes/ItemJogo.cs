using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteca.Classes
{
    public class ItemJogo
    {

        private int itemID;
        public int GetItemID()
        {
            return itemID;
        }

        private void SetItemID(int value)
        {
            itemID = value;
        }

        private string tipo;

        public string GetTipo()
        {
            return tipo;
        }

        private void SetTipo(string value)
        {
            tipo = value;
        }

        private int minNivelNecessario;
        private string nome;
        private int preco;
        public int MinNivelNecessario { get => minNivelNecessario; set => minNivelNecessario = value; }
        public string Nome { get => nome; set => nome = value; }
        public int Preco { get => preco; set => preco = value; }

        public ItemJogo()
        {

        }
        public ItemJogo(int itemID, string nome, int preco, string tipo, int minNivelNecessario)
        {
            SetItemID(itemID);
            Nome = nome;
            Preco = preco;
            SetTipo(tipo);
            MinNivelNecessario = minNivelNecessario;
        }

    }
}
