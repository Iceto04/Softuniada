using System;
using System.Collections.Generic;

namespace P02.Crocs
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var heigth = n * 4 + 2;

            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine($"{new string(' ', n)}{new string('#', 3 * n)}{new string(' ', n)}");
            }

            heigth -= n / 2;

            Console.WriteLine($"{new string('#', n)}{new string(' ', 3 * n)}{new string('#', n)}");

            heigth--;

            var hashtags = new List<string>();
            for (int i = 0; i < n * 3 / 2; i++)
            {
                hashtags.Add("#");
            }

            for (int i = 0; i < 2 * n - 1; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine($"{new string('#', n)} {string.Join(" ", hashtags)} {new string('#', n)}");
                }
                else
                {
                    hashtags.RemoveAt(hashtags.Count - 1);
                    Console.WriteLine($"{new string('#', n)}  {string.Join(" ", hashtags)}  {new string('#', n)}");
                    hashtags.Add("#");
                }
            }

            heigth -= 2 * n - 1;

            Console.WriteLine($"{new string('#', n)}{new string(' ', 3 * n)}{new string('#', n)}");

            heigth--;

            heigth -= n / 2;
            for (int i = 0; i < heigth; i++)
            {
                if (i % 2 == 0)
                {
                    Console.WriteLine(new string('#', 5 * n));
                }
                else
                {
                    Console.WriteLine($"{new string('#', n)} {string.Join(" ", hashtags)} {new string('#', n)}");
                }
            }

            for (int i = 0; i < n / 2; i++)
            {
                Console.WriteLine($"{new string(' ', n)}{new string('#', 3 * n)}{new string(' ', n)}");
            }

        }
    }
}
