using System;
using System.Collections.Generic;

namespace P01.EasterPrize
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var start = int.Parse(Console.ReadLine());
            var end = int.Parse(Console.ReadLine());

            var primes = new List<int>();

            for (int i = start; i <= end; i++)
            {
                if (i <= 1)
                {
                    continue;
                }

                var prime = true;
                for (int j = 2; j <= Math.Sqrt(i); j++)
                {
                    if (i % j == 0)
                    {
                        prime = false;
                        break;
                    }
                }

                if (prime)
                {
                    primes.Add(i);
                }
            }

            Console.WriteLine(string.Join(" ", primes));
            Console.WriteLine($"The total number of prime numbers between {start} to {end} is {primes.Count}");
        }
    }
}
