using System;

namespace P02.EasterEggs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var height = n;

            var spaces = 0;
            for (int i = 0; i < height; i++)
            {
                Console.Write(new string(' ', spaces));
                for (int j = 1; j <= n; j++)
                {
                    Console.Write(j);
                }

                for (int j = n - 1; j >= 1; j--)
                {
                    Console.Write(j);
                }

                Console.Write(new string(' ', spaces));

                n--;
                spaces++;
                Console.WriteLine();
            }
        }
    }
}
