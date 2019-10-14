using System;

namespace Fafnir.NET
{
    class Program
    {
        static void Main(string[] args)
        {
        }
        private static int GenKey()
        {
            Random rng = new Random();
            return rng.Next(256);
        }
        private static string XORString(string input)
        {
            int key;
            string output = input;
            int current;
            for(int i = 0; i < output.Length; i++)
            {
                key = GenKey();
                current = output[i];
                current ^= key;
                output.Replace(output[i], (char)current);
            }
            return output;
        }
    }
}
