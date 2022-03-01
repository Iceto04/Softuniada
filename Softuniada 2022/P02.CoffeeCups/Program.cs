using System;

namespace P02.CoffeeCups
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var name = Console.ReadLine();

            var width = 3 * n + 6;
            var height = 3 * n + 1;

            var leftHeigth = height;

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{new string(' ', n)}~ ~ ~");
            }

            leftHeigth -= n;

            Console.WriteLine(new string('=', width - 1));

            leftHeigth--;
            leftHeigth--;
            leftHeigth -= n;
            leftHeigth--;

            var nameRow = leftHeigth / 2;
            for (int i = 0; i < leftHeigth; i++)
            {
                if (i == nameRow)
                {
                    Console.WriteLine($"|{new string('~', n)}{name.ToUpper()}{new string('~', n)}|{new string(' ', n - 1)}|");
                }
                else
                {
                    Console.WriteLine($"|{new string('~', n)}{new string('~', name.Length)}{new string('~', n)}|" +
                        $"{new string(' ', n - 1)}|");
                }
            }

            Console.WriteLine(new string('=', width - 1));

            var spaces = 0;
            var Ats = n * 2 + name.Length;
            for (int i = 0; i < n; i++)
            {
                Console.WriteLine($"{new string(' ', spaces)}\\{new string('@', Ats)}/");
                spaces++;
                Ats -= 2;
            }

            Console.WriteLine(new string('-', width - 1));
        }
    }
}
