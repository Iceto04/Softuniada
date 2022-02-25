using System;

namespace P02.DrawHouse
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            // Roof
            var dots = n - 1;
            var spaces = 1;
            Console.WriteLine($"{new string('.', dots)}*{new string('.', dots)}");
            for (int i = 0; i < n - 2; i++)
            {
                dots--;
                Console.WriteLine($"{new string('.', dots)}*{new string(' ', spaces)}*{new string('.', dots)}");
                spaces += 2;
            }

            var asterixes = new char[n];
            for (int i = 0; i < asterixes.Length; i++)
            {
                asterixes[i] = '*';
            }
            Console.WriteLine(string.Join(" ", asterixes));


            // Body

            var dashes = (n * 2) - 3;
            var pipes = n - 2;
            Console.WriteLine($"+{new string('-', dashes)}+");
            for (int i = 0; i < pipes; i++)
            {
                Console.WriteLine($"|{new string(' ', dashes)}|");
            }
            Console.WriteLine($"+{new string('-', dashes)}+");
        }
    }
}
