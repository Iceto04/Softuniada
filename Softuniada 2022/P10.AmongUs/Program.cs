using System;
using System.Collections.Generic;

namespace P10.AmongUs
{
    internal class Program
    {
        private static Dictionary<string, long> cache;

        static void Main(string[] args)
        {
            //elements = Console.ReadLine().Split();
            //k = int.Parse(Console.ReadLine());
            //combinations = new string[k];

            //Combinations(0, 0);

            var groups = 2;
            cache = new Dictionary<string, long>();
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            if (n < m)
            {
                Console.WriteLine(n);
            }

            if (2 * m < n)
            {
                Console.WriteLine(0);
                return;
            }

            Console.WriteLine(GetBinom(n, m));
        }

        private static long GetBinom(int n, int k)
        {
            var id = $"{n} {k}";

            if (cache.ContainsKey(id))
            {
                return cache[id];
            }

            if (k == 0 || k == n)
            {
                return 1;
            }

            var result = GetBinom(n - 1, k) + GetBinom(n - 1, k - 1);
            cache[id] = result;
            return result;
        }
    }
}
