namespace Biblioteca
{
    public static class RandomNumberGenerator
    {
        private static readonly Random _simpleGenerator = new Random();
        public static int NumberBetween(int minimumValue, int maximumValue)
        {
            return _simpleGenerator.Next(minimumValue, maximumValue + 1);
        }
    }
}
