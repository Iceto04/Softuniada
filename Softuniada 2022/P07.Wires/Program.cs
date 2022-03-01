using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.Wires
{
    internal class Program
    {
        private static string[] elements;
        private static string[] permutation;
        private static bool[] used;
        private static List<Connection> connections;

        private static int numberOfCombinations;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            var m = int.Parse(Console.ReadLine());

            connections = new List<Connection>();

            for (int i = 0; i < m; i++)
            {
                var connection = Console.ReadLine()
                    .Split(" > ");

                var first = connection[0];
                var second = connection[1];

                connections.Add(new Connection(first, second));
            }

            ;

            elements = new string[n];

            for (int i = 0; i < n; i++)
            {
                elements[i] = $"{i + 1}";
            }

            permutation = new string[elements.Length];
            used = new bool[elements.Length];

            Permute(0);

            Console.WriteLine(numberOfCombinations);
        }

        private static void Permute(int index)
        {
            if (index >= elements.Length)
            {
                foreach (var connection in connections)
                {
                    var first = connection.First;
                    var second = connection.Second;

                    var firstIndex = permutation.ToList().IndexOf(first);
                    var secondIndex = permutation.ToList().IndexOf(second);

                    if (firstIndex < secondIndex)
                    {
                        return;
                    }
                }
                numberOfCombinations++;
                return;
            }

            for (int elmIdx = 0; elmIdx < elements.Length; elmIdx++)
            {
                if (!used[elmIdx])
                {
                    used[elmIdx] = true;
                    permutation[index] = elements[elmIdx];
                    Permute(index + 1);
                    used[elmIdx] = false;
                }
            }
        }
    }

    public class Connection
    {
        public Connection(string first, string second)
        {
            First = first;
            Second = second;
        }

        public string First { get; set; }

        public string Second { get; set; }

        public override string ToString()
        {
            return $"{this.First} {this.Second}";
        }
    }
}
