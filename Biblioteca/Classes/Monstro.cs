using System.Collections.ObjectModel;
namespace Biblioteca.Classes;

public class Monstro : Personagem
{
    public int ID { get; }
    public int RecompensaXP { get; private set; }

    public Monstro(int id, string nome, int maxHP, int hpAtual,
                   ItemJogo armaAtual, int dinheiro, int recompensaXP) :
            base(nome, maxHP, hpAtual, dinheiro, new List<ItemJogo>())
    {
        ID = id;
        ArmaAtual = (Arma) armaAtual;
        RecompensaXP = recompensaXP;

    }
}
