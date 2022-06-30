using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Biblioteca.Classes;
using Biblioteca.Criador;
using System.Media;
using System.IO;
using Spectre.Console;

namespace Biblioteca.Tela
{
    public class Menus
    {
        Sessao _sessaoAtual;
        Jogador _jogadorAtual;
        FigletText _titulo = new FigletText("RPG AED").Centered().Color(Color.Blue);
        FigletText _tituloGameOver = new FigletText("GAME OVER").Centered().Color(Color.Red);
        static SoundPlayer _toqueAtual = new();
        public static SoundPlayer _toqueBatalha  = new SoundPlayer("./Audios/batalha.wav");
        SoundPlayer _toqueBeep = new SoundPlayer("./Audios/beep.wav");
        SoundPlayer _toqueBoss = new SoundPlayer("./Audios/boss.wav");
        SoundPlayer _toqueFimDeJogo = new SoundPlayer("./Audios/fimdejogo.wav");
        public static SoundPlayer _toqueFimVitoria = new SoundPlayer("./Audios/fimvitoria.wav");
        public static SoundPlayer _toqueInstalacao = new SoundPlayer("./Audios/instalacao.wav");
        SoundPlayer _toqueItem = new SoundPlayer("./Audios/item.wav");
        SoundPlayer _toqueMenu = new SoundPlayer("./Audios/menu.wav");
        SoundPlayer _toqueMercado = new SoundPlayer("./Audios/mercado.wav");
        SoundPlayer _toqueOutro = new SoundPlayer("./Audios/outro.wav");
        SoundPlayer _toqueOutro2 = new SoundPlayer("./Audios/outro2.wav");
        SoundPlayer _toqueSelecionar = new SoundPlayer("./Audios/selecionar.wav");
        SoundPlayer _toqueTorre = new SoundPlayer("./Audios/torre.wav");
        Arma _armaAtual;
        StreamWriter _arquivoGravar;
        StreamReader _arquivoLer;
        private readonly string _arquivoCaminho = @"..\..\..\..\Save\\savegame.txt";
        public Menus()
        {
            CarregarSons();
            MenuInicial();
        }

        public void CarregarSons()
        {
            _toqueBatalha.Load();
            _toqueBeep.Load();
            _toqueBoss.Load();
            _toqueFimDeJogo.Load();
            _toqueFimVitoria.Load();
            _toqueInstalacao.Load();
            _toqueItem.Load();
            _toqueMenu.Load();
            _toqueMercado.Load();
            _toqueOutro.Load();
            _toqueOutro2.Load();
            _toqueSelecionar.Load();
            _toqueTorre.Load();
        }

        public void MenuInicial()
        {


            var panel = new Panel(_titulo);
            panel.Border = BoxBorder.Ascii;
            panel.BorderColor(Color.Blue);
            AnsiConsole.Write(panel);

            _toqueMenu.PlayLooping();
            _toqueAtual = new SoundPlayer(_toqueMenu.SoundLocation);


            var escolha = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .PageSize(10)
            .AddChoices(new[] {
                "Novo Jogo", "Continuar", "Sair",
            }));

            switch (escolha)
            {
                case "Novo Jogo":
                    NovoJogo(1);
                    break;
                case "Continuar":
                    NovoJogo(2);
                    break;
                case "Sair":
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }
        }

        public static void Tocar(SoundPlayer tocar)
        {
            _toqueAtual.Stop();
            tocar.PlayLooping();
            _toqueAtual.SoundLocation = tocar.SoundLocation;
        }
        public void NovoJogo(int i)
        {
            AnsiConsole.Write(_titulo);
            switch (i)
            {
                case 1:

                    string nome;

                    Console.Clear();
                    AnsiConsole.Write(_titulo);
                    EscreverLento.EscreverLinha("Insira o nome do seu herói: ");
                    nome = Console.ReadLine() ?? "";

                    _jogadorAtual = new Jogador(nome, 0, 10, 10, 0, "Guerreiro", 1);
                    _sessaoAtual = new Sessao(_jogadorAtual);

                    break;
                case 2:
                    _arquivoLer = File.OpenText(_arquivoCaminho);

                    string linha = _arquivoLer.ReadLine() ?? "";

                    string[] dados = linha.Split(";");


                    try
                    {
                        _jogadorAtual = new Jogador(dados[0], int.Parse(dados[1]), int.Parse(dados[2]), int.Parse(dados[3]), int.Parse(dados[4]), "Guerreiro", int.Parse(dados[5]));

                    }
                    catch
                    {

                        NovoJogo(1);
                    }

                    string[] dadosInventario = dados[8].Split(",");

                    for (int j = 0; j < int.Parse(dados[7]); j++)
                    {
                        _jogadorAtual.Inventario.Add(CriadorItem.GetItemJogo(int.Parse(dadosInventario[j])));
                    }

                    _jogadorAtual.PrimeiraVezMercador = dados[6] != "False";

                    _sessaoAtual = new Sessao(_jogadorAtual);

                    _arquivoLer.Close();

                    Console.Clear();
                    EscreverLento.EscreverLinha("Dados Carregados!");
                    AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
                    Console.ReadKey();
                    break;
                default:
                    NovoJogo(i);
                    break;
            }

            Tocar(_toqueInstalacao);
            Iniciar();
        }

        public void Iniciar()
        {
            Console.Clear();

            Imagens.Instalacao();

            var escolha = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("O que fazer?")
            .PageSize(10)
            .AddChoices(new[] {
                "Andar", "Inventario", "Status",
                "Salvar", "Sair do Jogo"
            }));

            switch (escolha)
            {
                case "Andar":
                    Andar();
                    Iniciar();
                    return;
                case "Inventario":
                    ExibirInventario();
                    Iniciar();
                    break;
                case "Status":
                    ExibirStatus();
                    Iniciar();
                    break;
                case "Salvar":
                    Salvar();
                    Iniciar();
                    break;
                case "Sair do Jogo":
                    Environment.Exit(0);
                    break;
                default:
                    Iniciar();
                    break;
            }


            
        }

        public void ExibirInventario()
        {
            Console.Clear();
            _jogadorAtual.ExibirInventario();

            EscreverLento.EscreverLinha("\nAperte qualquer tecla para voltar");
            AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
            Console.ReadKey();
            return;
        }

        public void ExibirStatus()
        {
            _jogadorAtual.ExibirStatus();
        }
        public void Andar()
        {
            Console.Clear();
            EscreverLento.EscreverLinha($"Você está em: {_sessaoAtual.GetNomeLocal(_sessaoAtual.LocalAtual.X, _sessaoAtual.LocalAtual.Y)}\n");

            if (_sessaoAtual.GetNomeLocal(_sessaoAtual.LocalAtual.X, _sessaoAtual.LocalAtual.Y) == "Instalação")
            {
                Tocar(_toqueInstalacao);
            }

            string nomeNorte = _sessaoAtual.GetNomeLocal(_sessaoAtual.LocalAtual.X, _sessaoAtual.LocalAtual.Y + 1);
            string nomeSul = _sessaoAtual.GetNomeLocal(_sessaoAtual.LocalAtual.X, _sessaoAtual.LocalAtual.Y - 1);
            string nomeLeste = _sessaoAtual.GetNomeLocal(_sessaoAtual.LocalAtual.X + 1, _sessaoAtual.LocalAtual.Y);
            string nomeOeste = _sessaoAtual.GetNomeLocal(_sessaoAtual.LocalAtual.X - 1, _sessaoAtual.LocalAtual.Y);

            var escolha = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .Title("O que fazer?")
            .PageSize(10)
            .AddChoices(new[] {
                nomeNorte, nomeSul, nomeLeste, nomeOeste, "Voltar",
            }));

            if(escolha == nomeNorte){escolha = "Norte";}
            else if(escolha == nomeSul){escolha = "Sul";}
            else if (escolha == nomeLeste){escolha = "Leste";}
            else if (escolha == nomeOeste){escolha = "Oeste";}

            switch (escolha)
            {
                case "Norte":
                    _sessaoAtual.IrProNorte(this);

                    switch (_sessaoAtual.LocalAtual.Y)
                    {
                        case 1:
                            TelaTorre();
                            Andar();
                            return;
                        case 2:
                            TelaTorreNivel0();
                            return;
                        case 3:
                            TelaTorreNivel1();
                            return;
                        case 4:
                            TelaTorreNivel2();
                            return;
                        case 5:
                            TelaTorreNivel3();
                            return;

                        default:
                            break;
                    }
                    break;
                case "Sul":
                    _sessaoAtual.IrProSul(this);
                    return;
                case "Leste":
                    _sessaoAtual.IrProLeste(this);
                    return;
                case "Oeste":
                    if (_jogadorAtual.PrimeiraVezMercador)
                    {
                        EscreverLento.EscreverLinha("Você não possui uma arma e está tentando ir para uma área perigosa. Para o seu bem, e pro jogo funcionar direito, vá ao mercado.");
                        AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
                        Console.ReadKey();
                        Andar();
                    }
                    _sessaoAtual.IrProOeste(this);
                    Iniciar();
                    return;
                case "Voltar":
                    return;
                default:
                    break;
            }
        }

        public void TelaEscolhaMercador()
        {
            Tocar(_toqueMercado);
            if (_sessaoAtual.JogadorAtual.PrimeiraVezMercador)
            {
                TelaGanhaEspada(_sessaoAtual.JogadorAtual);
                AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
                Console.ReadKey();
                _sessaoAtual.LocalAtual.RemoverMonstrosDaqui();
                TelaMercador(1);
                return;
            }
            else
            {
                TelaMercador(2);
            }
        }

        public void TelaGanhaEspada(Jogador jogadorAtual)
        {
            Console.Clear();

            EscreverLento.EscreverLinha("Ei, garota. Cuidado!!!");
            Thread.Sleep(500);

            Imagens.MercadorComMedo(1);
            Console.WriteLine("");
            EscreverLento.EscreverLinha("Eu encontrei alguns monstros por aqui... Estou me escondendo...");
            EscreverLento.EscreverLinha("Venha, esconda-se também!");
            AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
            Console.ReadKey();

            Console.Clear();
            Imagens.MercadorComMedo(2);
            EscreverLento.EscreverLinha("...", 500);
            EscreverLento.EscreverLinha("\nH-Hein?!! Você é algum tipo de guerreiro?!");
            EscreverLento.EscreverLinha("O que está esperando? Pegue sua arma e ataque os monstros!");
            AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
            Console.ReadKey();

            Console.Clear();
            Imagens.MercadorComMedo(2);
            EscreverLento.EscreverLinha("...", 500);
            EscreverLento.EscreverLinha("\nO quê?! Você não tem uma arma?!");
            EscreverLento.EscreverLinha("Ok, pega essa aqui. Eu estava guardando caso precisasse usar.\n");
            AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
            Console.ReadKey();
            Console.Clear();

            _jogadorAtual.AdicionarItemInventario(CriadorItem.CriarItemJogo(1001));
            Console.WriteLine(Imagens.Espada());

            _armaAtual = Sessao.GetArma(jogadorAtual);
            Thread.Sleep(200);

            Imagens.Espada();
            Console.WriteLine($"\nParabéns! Você conseguiu a {_armaAtual.Nome}");
            AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
            Console.ReadKey();
            Console.Clear();
            Imagens.MercadorComMedo(1);
            EscreverLento.EscreverLinha("\nAgora vai lá e mate aqueles monstros!!!");
            AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
            Console.ReadKey();
            TelaMonstros();
            
        }

        public void TelaMercador(int i)
        {
            switch (i)
            {
                case 1:
                    Console.Clear();
                    Imagens.Mercador();
                    Tocar(_toqueMercado);
                    EscreverLento.EscreverLinha("Muito obrigado... ");
                    EscreverLento.EscreverLinha("... é... ", 500);
                    EscreverLento.EscreverLinha("...", 500);
                    EscreverLento.EscreverLinha("Qual o seu nome mesmo?");
                    AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
                    Console.ReadKey();
                    Console.Clear();
                    Imagens.Mercador();
                    EscreverLento.EscreverLinha($"{_jogadorAtual.Nome}? É um belo nome.");
                    EscreverLento.EscreverLinha("De qualquer jeito, obrigado por derrotar os monstros. Pode ficar com a espada, vejo que ela está em melhor mãos.");
                    EscreverLento.EscreverLinha("Mas caso um dia você procure alguma melhoria, como uma espada melhor, é só falar comigo.");
                    AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
                    Console.ReadKey();
                    TelaMercador(2);

                    break;
                case 2:
                    Console.Clear();
                    Imagens.Mercador();

                    Console.WriteLine("");
                    EscreverLento.EscreverLinha($"Bem-vindo(a), {_jogadorAtual.Nome}! Aproveite as ofertas!");

                    var escolha = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .PageSize(10)
                    .Title("\nO que fazer?")
                    .AddChoices(new[] {
                        "Comprar", "Vender", "Status", "Sair",
                    }));

                    switch (escolha)
                    {
                        case "Comprar":
                            TelaCompra();
                            TelaMercador(2);
                            return;
                        case "Vender":
                            TelaVenda();
                            TelaMercador(2);
                            return;
                        case "Status":
                            ExibirStatus();
                            TelaMercador(2);
                            return;
                        case "Sair":
                            EscreverLento.EscreverLinha("\nVocê decide voltar para a instalação.");
                            AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
                            Console.ReadKey();
                            Tocar(_toqueInstalacao);
                            _sessaoAtual.IrProOeste(this);
                            Iniciar();
                            return;
                        default:
                            TelaMercador(i);
                            break;
                    }
                    break;
                case 3:
                    Console.Clear();
                    Imagens.MercadorComMedo(2);
                    EscreverLento.EscreverLinha("E-ei! Qual é!!! Não tente fugir!!!");
                    EscreverLento.EscreverLinha("Não tenho pra onde ir. Volte e acabe com eles!!!");
                    AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
                    Console.ReadKey();

                    return;
                default:
                    TelaMercador(i);
                    break;
            }
        }

        public void TelaCompra()
        {
            ItemJogo variavelTemporaria = new();
            int index;


            Console.Clear();
            Imagens.Mercador();
            EscreverLento.EscreverLinha("Gostaria de comprar alguma coisa?");

            string[] nomeArmas = new string[_sessaoAtual.MercadorAtual.Inventario.Count + 1];

            for (int i = 0; i < nomeArmas.Length - 1; i++)
            {
                nomeArmas[i] = _sessaoAtual.MercadorAtual.Inventario[i].Nome;
            }

            nomeArmas[nomeArmas.Length - 1] = "Voltar";
            var escolha = AnsiConsole.Prompt(
            new SelectionPrompt<string>()
            .PageSize(10)
            .AddChoices(nomeArmas));

            if (escolha == "Voltar")
            {
                return;
            }

            foreach (var item in _sessaoAtual.MercadorAtual.Inventario)
            {
                if (item.Nome == escolha)
                {
                    variavelTemporaria = item;

                }
            }
            index = _sessaoAtual.MercadorAtual.Inventario.IndexOf(variavelTemporaria);

            if (index < _sessaoAtual.MercadorAtual.Inventario.Count)
            {
                EscreverLento.EscreverLinha($"\nGostaria de comprar {_sessaoAtual.MercadorAtual.Inventario[index].Nome} (R$ {_sessaoAtual.MercadorAtual.Inventario[index].Preco},00)?");
                escolha = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .PageSize(10)
                .AddChoices(new[] {
                    "Sim", "Não", 
                }));

                switch (escolha)
                {
                    case "Sim":
                        if (_jogadorAtual.Nivel < _sessaoAtual.MercadorAtual.Inventario[index].MinNivelNecessario)
                        {
                            EscreverLento.EscreverLinha("Seu nível é baixo demais para empunhar uma espada dessas. Pela sua segurança, não irei vendê-la.");
                            AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
                            Console.ReadKey();
                            TelaCompra();
                            return;
                        }
                        else
                        {
                            foreach (ItemJogo arma in _jogadorAtual.Inventario.ToList())
                            {
                                if(arma is Arma)
                                {
                                    if (arma.Preco < _sessaoAtual.MercadorAtual.Inventario[index].Preco)
                                    {
                                        _jogadorAtual.Inventario.Remove(arma);
                                    }
                                    else
                                    {
                                        EscreverLento.EscreverLinha("Vejo que você já possui uma arma melhor que esta. Não faz sentido comprá-la, não é mesmo?");
                                        AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
                                        Console.ReadKey();
                                        TelaCompra();
                                        return;
                                    }
                                }
                            }

                            if (_jogadorAtual.Dinheiro >= _sessaoAtual.MercadorAtual.Inventario[index].Preco)
                            {
                                _jogadorAtual.GastarDinheiro(_sessaoAtual.MercadorAtual.Inventario[index].Preco);

                                _jogadorAtual.AdicionarItemInventario(_sessaoAtual.MercadorAtual.Inventario[index]);

                                _sessaoAtual.MercadorAtual.RemoverItemInventario(_sessaoAtual.MercadorAtual.Inventario[index]);
                                Console.Clear();
                                Imagens.Mercador();
                                EscreverLento.EscreverLinha("Obrigado pela compra!");
                                break;
                            }
                            else
                            {
                                EscreverLento.EscreverLinha($"Você só tem {_jogadorAtual.Dinheiro} reais, portanto não consegue gastar {_sessaoAtual.MercadorAtual.Inventario[index].Preco} reais");
                                break;
                            }
                        }

                    case "Não":
                        TelaCompra();
                        break;
                    default:
                        break;
                }

            }
            

            AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
            Console.ReadKey();
            TelaCompra();
        }

        public void TelaVenda()
        {
            ItemJogo variavelTemporaria = new();
            int index;

            Console.Clear();
            Imagens.Mercador();
            EscreverLento.EscreverLinha("Gostaria de vender alguma coisa?\n");

            string[] nomeArmas = new string[_jogadorAtual.Inventario.Count + 1];

            for (int i = 0; i < nomeArmas.Length - 1; i++)
            {
                nomeArmas[i] = _jogadorAtual.Inventario[i].Nome;
            }


            nomeArmas[nomeArmas.Length - 1] = "Voltar";

            var escolha = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .PageSize(10)
                .AddChoices(nomeArmas));

            if (escolha == "Voltar")
            {
                return;
            }

            foreach (var item in _jogadorAtual.Inventario)
            {
                if(item.Nome == escolha)
                {
                    variavelTemporaria = item;
                }
            }

            index = _jogadorAtual.Inventario.IndexOf(variavelTemporaria);

            if (_jogadorAtual.Inventario[index] is Arma)
            {
                EscreverLento.EscreverLinha("Desculpe, mas não compro armas.");
                AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
                Console.ReadKey();
                TelaVenda();
                return;
            }
            else
            {
                if (index < _jogadorAtual.Inventario.Count)
                {
                    EscreverLento.EscreverLinha($"\nGostaria de vender {_jogadorAtual.Inventario[index].Nome} (R$ {_jogadorAtual.Inventario[index].Preco},00?");

                    escolha = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .PageSize(10)
                    .AddChoices(new[] {
                        "Sim", "Não",
                    }));

                    switch (escolha)
                    {
                        case "Sim":

                            _sessaoAtual.MercadorAtual.AdicionarItemInventario(_jogadorAtual.Inventario[index]);
                            _jogadorAtual.ReceberDinheiro(_jogadorAtual.Inventario[index].Preco);
                            _jogadorAtual.RemoverItemInventario(_jogadorAtual.Inventario[index]);
                            Console.Clear();
                            Imagens.Mercador();
                            EscreverLento.EscreverLinha("Obrigado pela venda!");
                            break;

                        case "Não":
                            TelaVenda();
                            return;
                        default:
                            break;
                    }
                }
            }

            AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
            Console.ReadKey();
            TelaVenda();
        }

        public void TelaMonstros()
        {
            Console.Clear();
            EscreverLento.EscreverLinha($"Você está em: {_sessaoAtual.GetNomeLocal(_sessaoAtual.LocalAtual.X, _sessaoAtual.LocalAtual.Y)}\n");

            var escolha = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .PageSize(10)
                .Title("Foram encontrados monstros aqui. O que fazer?")
                .AddChoices(new[] {
                    "Enfrentá-los", "Inventário", "Fugir",
                }));

            switch (escolha)
            {
                case "Enfrentá-los":
                    _sessaoAtual.EnfrentarMonstros(_jogadorAtual, this);
                    return;
                case "Inventário":
                    ExibirInventario();
                    TelaMonstros();
                    return;

                case "Fugir":
                    
                    if (RandomNumberGenerator.NumberBetween(1, 100) <= 0)
                    {
                        EscreverLento.EscreverLinha("Os monstros conseguiram te alcançar!!!");
                        Console.Clear();
                        _sessaoAtual.EnfrentarMonstros(_jogadorAtual, this);
                    
                    }
                    else
                    {
                        if (_jogadorAtual.PrimeiraVezMercador == true)
                        {
                            TelaMercador(3);
                            TelaMonstros();
                        }
                        else
                        {
                            Console.WriteLine("\n");
                            EscreverLento.EscreverLinha("Você consegue fugir.");
                            AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
                            Console.ReadKey();
                            _sessaoAtual.IrPra(this, 0, 0);
                            Iniciar();
                        }
                        
                    }
                    
                    return;

                default:
                    TelaMonstros();
                    break;
            }
        }

        public void TelaTorre()
        {
            Console.Clear();
            Tocar(_toqueTorre);
            Imagens.TorreInicial();
            
            var escolha = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .PageSize(10)
                .AddChoices(new[] {
                    "Entrar", "Voltar",
                }));

            switch (escolha)
            {
                case "Entrar":

                    if (_jogadorAtual.Nivel >= 2)
                    {
                        _sessaoAtual.IrProNorte(this);
                        TelaTorreNivel0();
                    }
                    else
                    {
                        EscreverLento.EscreverLinha("O elevador só funciona para jogadores nível 2 ou mais.");
                        AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
                        Console.ReadKey();
                        TelaTorre();
                    }
                    return;
                case "Voltar":
                    EscreverLento.EscreverLinha("\nVocê decide voltar para a instalação.");
                    AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
                    Console.ReadKey();
                    Tocar(_toqueInstalacao);
                    _sessaoAtual.IrProSul(this);
                    Iniciar();
                    break;
                default:
                    break;
            }



            AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
            Console.ReadKey();  
        }

        public void TelaTorreNivel0()
        {
            _sessaoAtual.ConferePresenca(this);
            Console.Clear(); Tocar(_toqueTorre);
            EscreverLento.EscreverLinha("Preciso subir rápido, outros monstros estão nascendo.");
            AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
            Console.ReadKey();
            if (_jogadorAtual.Nivel > 3)
            {
                _sessaoAtual.IrProNorte(this);
                TelaTorreNivel1();
            }
            else
            {
                EscreverLento.EscreverLinha("O elevador só funciona para jogadores nível 3 ou mais");
            }
        }

        public void TelaTorreNivel1()
        {
            _sessaoAtual.ConferePresenca(this);
            Console.Clear(); Tocar(_toqueTorre);
            EscreverLento.EscreverLinha("Preciso subir rápido, outros monstros estão nascendo.");
            AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
            Console.ReadKey();
            if (_jogadorAtual.Nivel > 4)
            {
                _sessaoAtual.IrProNorte(this);
                TelaTorreNivel2();
            }
            else
            {
                EscreverLento.EscreverLinha("O elevador só funciona para jogadores nível 4 ou mais");
            }
        }

        public void TelaTorreNivel2()
        {
            _sessaoAtual.ConferePresenca(this);
            Console.Clear(); Tocar(_toqueTorre);
            EscreverLento.EscreverLinha("Estou perto do último andar.");
            AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
            Console.ReadKey();
            if (_jogadorAtual.Nivel > 7)
            {
                _sessaoAtual.IrProNorte(this);
                TelaTorreNivel3();
            }
            else
            {
                EscreverLento.EscreverLinha("O elevador só funciona para jogadores nível 7 ou mais");
            }
        }

        public void TelaTorreNivel3()
        {
            _sessaoAtual.ConferePresenca(this);
            Console.Clear(); Tocar(_toqueTorre);
            EscreverLento.EscreverLinha("Finalmente você chegou...");
            AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
            Console.ReadKey();
            Console.Clear();
            Imagens.Princesa();
            AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
            Console.ReadKey();
            Console.Clear();
            Imagens.TelaFinal(1);
            Thread.Sleep(1000);
            Console.Clear();
            Imagens.TelaFinal(2);
            Thread.Sleep(1500);
            Console.Clear();
            Imagens.TelaFinal(3);
            AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
            Console.ReadKey();
            Console.Clear();
            Thread.Sleep(1000);
            TelaFimDeJogo();
        }

        public void TelaFimDeJogo()
        {
            Console.Clear();

            if (_jogadorAtual.TaMorto)
            {
                Tocar(_toqueFimDeJogo);
            }
            else
            {
                Tocar(_toqueFimVitoria);
            }

            AnsiConsole.Write(_tituloGameOver);

            var escolha = AnsiConsole.Prompt(
                new SelectionPrompt<string>()
                .PageSize(10)
                .AddChoices(new[] {
                    "Novo Jogo", "Continuar", "Sair",
                }));

            switch (escolha)
            {
                case "Novo Jogo":
                    NovoJogo(1);
                    break;
                case "Continuar":
                    NovoJogo(2);
                    break;
                case "Sair":
                    Environment.Exit(0);
                    break;
                default:
                    break;
            }

        }

        public void Salvar()
        {
            string escolha = string.Empty;
            Console.Clear();
            FileInfo _arquivoInfo = new FileInfo(_arquivoCaminho);
            if (_arquivoInfo.Exists)
            {
                EscreverLento.EscreverLinha("Ao salvar, os dados serão sobrescritos.");
                AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
                Console.ReadKey();
                Console.Clear();

                escolha = AnsiConsole.Prompt(
                    new SelectionPrompt<string>()
                    .PageSize(10)
                    .AddChoices(new[] {
                    "Salvar", "Voltar",
                    }));
            }
            else
            {
                escolha = "Continuar";
            }

            switch (escolha)
            {
                case "Salvar":
                    File.Delete(_arquivoCaminho);


                    _arquivoGravar = File.CreateText(_arquivoCaminho);


                    _arquivoGravar.Write(_sessaoAtual.JogadorAtual.Nome + ";");

                    _arquivoGravar.Write(_sessaoAtual.JogadorAtual.GetXP() + ";");

                    _arquivoGravar.Write(_sessaoAtual.JogadorAtual.MaxHP + ";");

                    _arquivoGravar.Write(_sessaoAtual.JogadorAtual.HPAtual + ";");

                    _arquivoGravar.Write(_sessaoAtual.JogadorAtual.Dinheiro + ";");

                    _arquivoGravar.Write(_sessaoAtual.JogadorAtual.Nivel + ";");

                    _arquivoGravar.Write(_sessaoAtual.JogadorAtual.PrimeiraVezMercador + ";");

                    _arquivoGravar.Write(_sessaoAtual.JogadorAtual.Inventario.Count + ";");

                    foreach (ItemJogo item in _sessaoAtual.JogadorAtual.Inventario)
                    {
                        _arquivoGravar.Write(item.GetItemID());

                        if (item != _sessaoAtual.JogadorAtual.Inventario.Last())
                        {
                            _arquivoGravar.Write(",");
                        }
                    }



                    _arquivoGravar.Close();

                    EscreverLento.EscreverLinha("\nO jogo foi salvo com sucesso!");
                    AnsiConsole.Markup("[silver italic]Aperte Enter para continuar...[/]\n");
                    Console.ReadKey();
                    return;
                case "Voltar":
                    return;
            }


        }

    }
}
