namespace Biblioteca.Tela
{
    public static class Imagens
    {
        

        public static void MercadorComMedo(int i)
        {
            switch (i)
            {
                case 1:
                    Console.WriteLine("                ......               ");
                    Console.WriteLine("             .:||||||||:.            ");
                    Console.WriteLine("            /            \\           ");
                    Console.WriteLine("           (   o      o   )          ");
                    Console.WriteLine(" --@@@@----------:  :----------@@@@--");

                    break;
                case 2:
                    Console.WriteLine("                ......       | | |   ");
                    Console.WriteLine("             .:||||||||:.    | | |   ");
                    Console.WriteLine("            / ´        ' \\   . . .   ");
                    Console.WriteLine("           ( ´ O      O ' )          ");
                    Console.WriteLine(" --@@@@----------:  :----------@@@@--");

                    break;

                default:
                    break;
            }
        }

        public static void Mercador()
        {
            Console.WriteLine("    _//////|\\\\\\\\\\\\_   ");
            Console.WriteLine("   ////////|\\\\\\\\\\\\\\\\  ");
            Console.WriteLine("  |////////|\\\\\\\\\\\\\\\\| ");
            Console.WriteLine("  |   ___     ___   | ");
            Console.WriteLine("  |  - o -   - o -  | ");
            Console.WriteLine("  |   \"\"\"     \"\"\"   | ");
            Console.WriteLine("  |         \\       | ");
            Console.WriteLine("  |      '---'      | ");
            Console.WriteLine("   \\  .________.   /  ");
            Console.WriteLine("    .  \\______/   .   ");
            Console.WriteLine("     -_         _-    ");
            Console.WriteLine("     \" - _____ - \"      ");
            Console.WriteLine("       |       |      ");
            Console.WriteLine("  __--'         '--__ ");
            Console.WriteLine(" '                   '");
        }

        public static void Instalacao()
        {
            Console.WriteLine("        ______             ");
            Console.WriteLine("       /     /\\            ");
            Console.WriteLine("      /     /  \\           ");
            Console.WriteLine("     /_____/----\\_    (    ");
            Console.WriteLine("    \"     \"          ).    ");
            Console.WriteLine("   _ ___          o (:') o ");
            Console.WriteLine("  (@))_))        o ~/~~\\~ o");
            Console.WriteLine("                  o  o  o  ");
        }

        public static void TorreInicial()
        {
            Console.WriteLine("Nada é absoluto, nem mesmo a verdade sobre quem você é.                  ");
            Console.WriteLine("     \\,/           /`\\                \\,/                 /`\\            ");
            Console.WriteLine("Você entra em uma jornada para salvar a               |>>>               ");
            Console.WriteLine("princesa de seu reino, e para salvar a si mesma.      |                  ");
            Console.WriteLine("O castelo abandonado é a escolha óbvia para       _  _|_  _              ");
            Console.WriteLine("se manter uma princesa, as criaturas?            |;|_|;|_|;|             ");
            Console.WriteLine("Nem tanto.                                       \\\\.    .  /             ");
            Console.WriteLine("A cada andar você tem que enfrentar criaturas     \\\\:  .  /              ");
            Console.WriteLine("que ela não entende como podem existir,            ||:   |               ");
            Console.WriteLine("e como ela nunca ouviu falar delas em sua vida.    ||:.  |               ");
            Console.WriteLine("As criaturas ficam mais fortes à medida            ||:  .|               ");
            Console.WriteLine("que você avança pelos andares do castelo,          ||:   |       \\,/     ");
            Console.WriteLine("e a verdade sobre você também começa a se revelar. ||: , |            /`\\");
            Console.WriteLine("                                                   ||:   |               ");
            Console.WriteLine("              __                            ___.   ||_   |               ");
            Console.WriteLine("     ____--``    '--``__            __ ----`    ``---,___|_.             ");
            Console.WriteLine("-`--`                   `---__ ,--`'                        `_____-`'    ");

        }
        public static void Torre()
        {
            Console.WriteLine("                         ._                 ");
            Console.WriteLine("                          |~                ");
            Console.WriteLine("                        uuuuu               ");
            Console.WriteLine("                        |_#-|               ");
            Console.WriteLine("                        | _#|               ");
            Console.WriteLine("                        |_ -|               ");
            Console.WriteLine("   ________ .$$. ______ | - | _____________ ");
            Console.WriteLine("           .#$$$. __    |- _| ....__        ");
            Console.WriteLine("     _.--' $$$$$$    ` -[_-_]        `----- ");
            Console.WriteLine("           $$$$$$    -.                     ");
            Console.WriteLine("      -.    `:/'    _.))        .--.        ");
            Console.WriteLine("             ||   .'.-'     _..-.. _.-.     ");
            Console.WriteLine("      ._.-.  '\" / (     .'      `.          ");
            Console.WriteLine("    -'     `.   .    `. -'                  ");
            Console.WriteLine("             `. .      `--..                ");
            Console.WriteLine("                 `.                         ");
        }

        public static string Espada()
        {
            return "     /\n O===[====================-\n     \\";
        }

        public static void Jogador(int i)
        {
            switch (i)
            {
                case 1:
                    Console.WriteLine("       _,.");
                    Console.WriteLine("     ,` -.)");
                    Console.WriteLine("    ( _/-\\\\-._");
                    Console.WriteLine("   /,|`--._,-^|            ,");
                    Console.WriteLine("   \\_| |`-._/||          ,'|");
                    Console.WriteLine("     |  `-, / |         /  /");
                    Console.WriteLine("     |     || |        /  /");
                    Console.WriteLine("      `r-._||/   __   /  /");
                    Console.WriteLine("  __,-<_     )`-/  `./  /");
                    Console.WriteLine(" /  \\   `---'   \\   /  /");
                    Console.WriteLine("|    |           |./  /");
                    Console.WriteLine("|    /           //  /");
                    Console.WriteLine(" \\_/' \\         |/  /");
                    Console.WriteLine("  |    |   _,^-'/  /");
                    Console.WriteLine("  |    , ``  (\\/  /_");
                    Console.WriteLine("   \\,.->._    \\X-=/^");
                    Console.WriteLine("   (  /   `-._//^`");
                    Console.WriteLine("    `Y-.____(__}");
                    Console.WriteLine("     |     {__)");
                    Console.WriteLine("           ()");
                    break;

                case 2:
                    Console.WriteLine("       _,.");
                    Console.WriteLine("     ,` -.)");
                    Console.WriteLine("    ( _/-\\\\-._");
                    Console.WriteLine("   /,|`--._,-^|            ,");
                    Console.WriteLine("   \\_| |`-._/||          ,'|");
                    Console.WriteLine("     |' `-, /'|         / ./");
                    Console.WriteLine("     |   . ||.|        /  /");
                    Console.WriteLine("      `r-._||/   __   /. /");
                    Console.WriteLine("  __,-<_     )`-/  `./  /");
                    Console.WriteLine(" /  \\   `---' ' \\ ' /  /");
                    Console.WriteLine("| '  |  '      . |./  /");
                    Console.WriteLine("|    /           //' /");
                    Console.WriteLine(" \\_/' \\  '    ' |/  /");
                    Console.WriteLine("  |    |   _,^-'/' /");
                    Console.WriteLine("  |  ' , ``  (\\/  /_");
                    Console.WriteLine("   \\,.->._ '' \\X-=/^");
                    Console.WriteLine("   (  /   `-._//^`");
                    Console.WriteLine("    `Y-.__'_(__}");
                    Console.WriteLine("     |     {__)");
                    Console.WriteLine("           ()");
                    break;

                case 3:
                    Console.WriteLine("       _,.");
                    Console.WriteLine("     ,`,-.)");
                    Console.WriteLine("    ( _/-\\\\-._");
                    Console.WriteLine("   /,|`--._,-^|");
                    Console.WriteLine("   \\_|'|`-._/||          ,_.");
                    Console.WriteLine("     |',`-,./'|         / ./");
                    Console.WriteLine("     |','.;||;|        /' /");
                    Console.WriteLine("      `r-._/\\/   __   /. /");
                    Console.WriteLine("  __,-<_',\".,)`-/,.`./. / ");
                    Console.WriteLine(" / \\ , `---','.\\ ' / ./");
                    Console.WriteLine("| '  |, '; \\ . . |./' /");
                    Console.WriteLine("|, ' / '  . '\\ , //' /");
                    Console.WriteLine(" \\_/' \\  ' ' ,' |/ '/");
                    Console.WriteLine("  |;' ,| ' _,^-'/' /");
                    Console.WriteLine("  |. ' , ``,;(\\/ '/_");
                    Console.WriteLine("   \\,.->._ '' \\X-=/^");
                    Console.WriteLine("   (. / ' `-._//^`");
                    Console.WriteLine("    `Y-.__'_(__}");
                    Console.WriteLine("     |     {__)");
                    Console.WriteLine("           ()");
                    break;

                case 4:
                    Console.WriteLine("                                        ,gg@@@@@gg,,                             ");
                    Console.WriteLine("                                      g@@@@@NMMMN@@@@@gg                        ");
                    Console.WriteLine("                                     @@M\" '   ||||||j%@@@@,                     ");
                    Console.WriteLine("                                    @M`          |||ll$@$@@@                    ");
                    Console.WriteLine("                                   $F            |||ll$@@@@@@                   ");
                    Console.WriteLine("                                  j@ ,,,,    ,ygw|||lll%@@@@@                   ");
                    Console.WriteLine("                                  ]W|||||L ||lT||||l$llj$@@@@                   ");
                    Console.WriteLine("                                 ]y||W#@$$Ll$L#5&MMlT|$$$@@@@                   ");
                    Console.WriteLine("                                  |||||||' l||||''||ll$$$$l@@                   ");
                    Console.WriteLine("                                  | ''' | |lT|   ||ll$$$$$@@l                   ");
                    Console.WriteLine("                                  ||   'j%&@@@L ||||ll$$$$M$$                   ");
                    Console.WriteLine("                                   ||||||||||||||||ll$$$$@$\"                    ");
                    Console.WriteLine("                                   ||||MM*MMMWW|Llll$$$$$$P                     ");
                    Console.WriteLine("                                   }|||||M&MM||ll$$$$$$$@@                      ");
                    Console.WriteLine("                                    'l|||  ||lLl$$$@@@@@$F                      ");
                    Console.WriteLine("                                      %@l@lllg@@@@$@@$$@$,                      ");
                    Console.WriteLine("                                      lj$$$$$$$$@@$$M||ll@@                     ");
                    Console.WriteLine("                                       'llM&@&$%M|||||||@@@@g                   ");
                    Console.WriteLine("                                  ,,g@   l&&*`       ,@@@@@@@@gg                ");
                    Console.WriteLine("                          ,,gg@@@@@@@F .MF*T       ,g@@@@@@@@@@@@@,             ");
                    Console.WriteLine("                     ,g@@@@@@@@@@@@@@ @%,\" | lg    g@@@@@@@@@@@@@@@@@@g, ");
                    Console.WriteLine("                   ,@@@@@@@@@@@@@@@@@/ | |g$@M\",@@@@@@@@@@@@@@@@@@@@@@@@g, ");
                    Console.WriteLine("                   @@@@@@@@@@@@@@@@@@  L\'jLF\'  @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@   ");
                    Console.WriteLine("                 ,@@@@@@@@@@@@@@@@@@L    #T   @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@` ");
                    Console.WriteLine("                g@@@@@@@@@@@@@@@@@@@ |,',*  ,@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@K|");
                    Console.WriteLine("               @@@@@@@@@@@@@@@@@@@@-|\" -   >,@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@| ");
                    Console.WriteLine("             ,@@@@@@@@@@@@@@@@@@@@@,/    ,j@@@@@@@$@@@@@@@@@@@@@@@@@@@@@@@@@@@@|");
                    Console.WriteLine("            g@@@@@@@@@@@@@@@@@@@@@@L r - ,@@@@@@$@@@@@@@@@@@@@@@@@@@@@@@@@@@@@L|");
                    Console.WriteLine("          ,g@@@@@@@@@@@@@@@@@@@@@@Mr,'  ,@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@||");
                    Console.WriteLine("         @@*\"\"%  '%@@@@@@@@@@@@@@@,'  r,@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@||");
                    Console.WriteLine("      ,g@P- ~  '\"L |%@@@@@@@@@@@@ , ^, j@@@@@$@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@K || ");
                    Console.WriteLine("    ,@@@@@M|  \\||||||||%@@@@@@@@@@^,\" @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@P || ");
                    Console.WriteLine("   g@@@@@@  ||||',||lL|||%@@@@@@@@\"  g@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@||| ");
                    Console.WriteLine(" ,@@@@@@$$@gg,||L||| ||||lj@@@@@@@ / @@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@|||");
                    break;
                default:
                    break;
            }
        }

        public static void Princesa()
        {
            Console.WriteLine("          .....");
            Console.WriteLine("          WWWWW");
            Console.WriteLine("         ((. .))");
            Console.WriteLine("        ))) - (((");
            Console.WriteLine("      ((((`...\')))");
            Console.WriteLine("       ))))\\  /(((");
            Console.WriteLine("       /    \\/    \\");
            Console.WriteLine("      / /\\      /\\ \\");
            Console.WriteLine("     / /  \\    /  \\ \\");
            Console.WriteLine("    @@@@  / \\/ \\  @@@@");
            Console.WriteLine("    (v   /      \\   v)");
            Console.WriteLine("        @@@@@@@@@@");
            Console.WriteLine("       /          \\");
            Console.WriteLine("      /            \\");
            Console.WriteLine("     @@@@@@@@@@@@@@@@");
            Console.WriteLine("    /                \\");
            Console.WriteLine("   /                  \\");
            Console.WriteLine("  @@@@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine("  /                    \\");
            Console.WriteLine(" @@@@@@@@@@@@@@@@@@@@@@@@");
            Console.WriteLine("          v  v");
        }

        public static void TelaFinal(int i)
        {
            switch (i)
            {
                case 1:
                    Console.WriteLine("  (,);    /\\                    ");
                    Console.WriteLine(" ((  ^_   ||             ...     ");
                    Console.WriteLine("  ' /  \\  ||           (()))    ");
                    Console.WriteLine("    L {=) ||           {' ())   ");
                    Console.WriteLine("     ) -  ||            )_ (()  ");
                    Console.WriteLine("   (_   \\====       @  (   (_)  ");
                    Console.WriteLine("   | (___/{ }        \\7 \\ _) |  ");
                    Console.WriteLine("    \\____\\/)          {)=== /\\  ");
                    Console.WriteLine("    |    |             \\ |    | ");
                    Console.WriteLine("    |_/\\_|               |    | ");
                    Console.WriteLine("     |  |                |    | ");
                    Console.WriteLine("      ) )\\               |    | ");
                    Console.WriteLine("    _/| |/               |    | ");
                    Console.WriteLine("   ( ,\\ |_               '~~~~' ");
                    Console.WriteLine("    \\_(___)               _/Y   ");
                    break;

                case 2:
                    Console.WriteLine("        (,);        ...");
                    Console.WriteLine("       ((  ^_.     (()))");
                    Console.WriteLine("        ' / /_\\    {' ())");
                    Console.WriteLine("          L( '}     )_ (()");
                    Console.WriteLine("           ) (_    (   (_)");
                    Console.WriteLine("         (_  / }{)===='_/");
                    Console.WriteLine("         | `/\\/\\     |   \\");
                    Console.WriteLine("         L___/ |     |    |");
                    Console.WriteLine("          |  . \\     |    |");
                    Console.WriteLine("          |_/ \\_\\    |    |");
                    Console.WriteLine("          ( ____ )   |    |");
                    Console.WriteLine("           | | | |   |    |");
                    Console.WriteLine("       ( --' | \\ |_  '~~~~'");
                    Console.WriteLine("       /_/---) (___)  _/Y");
                    Console.WriteLine("          H");
                    Console.WriteLine("  -=======H%%O");
                    Console.WriteLine("          H");
                    break;

                case 3:
                    Console.WriteLine("                (\\/)");
                    Console.WriteLine("                 \\/");
                    Console.WriteLine("           (,);");
                    Console.WriteLine("          ((  ^_.  ...");
                    Console.WriteLine("           ' / /_\\(()))");
                    Console.WriteLine("             L( '}{' ())");
                    Console.WriteLine("             ) (   )_ (()");
                    Console.WriteLine("           (_   \\ (   (_)");
                    Console.WriteLine("           | (__'__\\_) |");
                    Console.WriteLine("            \\___|_(}==/ \\");
                    Console.WriteLine("            |    |  |    |");
                    Console.WriteLine("            |_/\\_|  |    |");
                    Console.WriteLine("             |  |   |    |");
                    Console.WriteLine("              ) )\\  |    |");
                    Console.WriteLine("            _/| |/  |    \\");
                    Console.WriteLine("           ( ,\\ |_  '~~~~/7");
                    Console.WriteLine("            \\_\\(___)  _/Y");
                    Console.WriteLine("         H");
                    Console.WriteLine(" -=======H%%O");
                    Console.WriteLine("         H");
                    break;
                default:
                    break;
            }
        }
    }
}
