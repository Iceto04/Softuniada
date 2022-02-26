using System;

namespace P10.CatPasswords
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var p = int.Parse(Console.ReadLine());
            var c = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());
            var g = int.Parse(Console.ReadLine());

            var fact = 1;
            for (int i = 1; i <= p; i++)
            {
                fact = fact * i;
            }

            var combinations = 1.0;

            combinations *= fact;
            if (c > 0)
            {
                combinations *= Math.Pow(10, c);
            }
            if (m > 0)
            {
                combinations *= Math.Pow(30, m);
            }
            if (g > 0)
            {
                combinations *= Math.Pow(30, g);
            }

            Console.WriteLine(combinations);
        }
    }
}
