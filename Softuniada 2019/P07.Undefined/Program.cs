using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.Undefined
{
    internal class Program
    {
        private static Dictionary<string, List<string>> owners;
        private static Dictionary<string, string> blockPairs;
        private static List<string> blocksLeft;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            owners = new Dictionary<string, List<string>>();
            blockPairs = new Dictionary<string, string>();
            blocksLeft = new List<string>();

            var totalSum = 0;
            for (int line = 0; line < n; line++)
            {
                var data = Console.ReadLine()
                    .Split(" -> ", StringSplitOptions.RemoveEmptyEntries)
                    .ToArray();

                var owner = data[0];
                var businesses = data[1]
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                    .Select(int.Parse)
                    .ToList();

                if (!owners.ContainsKey(owner))
                {
                    owners[owner] = new List<string>();
                }

                var maxBlock = int.MinValue;
                var minBlock = int.MaxValue;
                while (businesses.Count > 0)
                {
                    maxBlock = businesses.Max();
                    minBlock = businesses.Min();

                    var sum = Math.Abs(maxBlock - minBlock);
                    totalSum += sum;

                    owners[owner].Add($"{maxBlock} <-> {minBlock}");

                    businesses.Remove(maxBlock);
                    businesses.Remove(minBlock);
                    if (businesses.Count == 1)
                    {
                        blocksLeft.Add($"{owner}{businesses.First()}");
                        businesses.Clear();
                    }
                }
            }

            foreach (var owner in owners)
            {
                Console.WriteLine($"{owner.Key} | {string.Join(", ", owner.Value)}");
            }

            for (int i = 0; i < blocksLeft.Count; i++)
            {
                var maxBlock = blocksLeft.Max();
                var minBlock = blocksLeft.Min();

                Console.WriteLine($"{minBlock} <-> {maxBlock}");

                blocksLeft.Remove(minBlock);
                blocksLeft.Remove(maxBlock);
            }

            Console.WriteLine(totalSum);
        }
    }
}
