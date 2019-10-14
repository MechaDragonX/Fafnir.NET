using System;
using System.Security.Cryptography;

namespace Fafnir.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            // ASCII
            Console.WriteLine(XORString("bapple"));
            Console.WriteLine(XORString("banana"));
            Console.WriteLine(XORString("orange"));
            Console.WriteLine(XORString("Pokémon"));
            // Unicode
            Console.WriteLine(XORString("あなた"));
            Console.WriteLine(XORString("日本")); 
            Console.WriteLine(XORString("アメリカ"));
            Console.WriteLine(XORString("ﾆﾝﾃﾝﾄﾞｰ"));

            // All tests successfull
        }
        private static byte GenerateKey()
        {
            RandomNumberGenerator rng = RandomNumberGenerator.Create();
            byte[] bytes = new byte[1];
            rng.GetBytes(bytes);
            rng.Dispose();
            return bytes[0];
        }
        private static string XORString(string source) 
        {
            string result = source;
            byte key = GenerateKey();
            int temp = 0;
            foreach (char character in result)
            {
                while (true)
                {
                    key = GenerateKey();
                    temp ^= key;
                    if (temp >= 32 && temp <= 127)
                    {
                        break;
                    }
                }
                result = result.Replace(character, (char)temp);
            }
            return result;
        }
    }
}
