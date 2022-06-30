namespace Biblioteca
{
    public static class EscreverLento
    {
        public static void Escrever(string texto)
        {
            for (int i = 0; i < texto.Length; i++)
            {
                Thread.Sleep(20);
                Console.Write(texto[i]);
            }
        }

        public static void Escrever(string texto, int tempo)
        {
            for (int i = 0; i < texto.Length; i++)
            {
                Thread.Sleep(tempo);
                Console.Write(texto[i]);
            }
        }

        public static void EscreverLinha(string texto)
        {
            Escrever(texto);
            Console.WriteLine("");
        }

        public static void EscreverLinha(string texto, int tempo)
        {
            Escrever(texto, tempo);
            Console.WriteLine("");
        }
    }
}
