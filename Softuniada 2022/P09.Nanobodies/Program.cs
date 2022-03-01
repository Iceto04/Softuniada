using System;
using System.Collections.Generic;
using System.Linq;
using Wintellect.PowerCollections;

namespace P09.Nanobodies
{
    public class Edge
    {
        public int First { get; set; }

        public int Second { get; set; }

        public int Weight { get; set; }

        public override string ToString()
        {
            return $"{this.First} {this.Second} {this.Weight}";
        }
    }
    public class Program
    {
        public const int INF = 99999;

        private static int[,] graph;
        private static int[] parents;
        public static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            graph = ReadGraph(rows, cols);

            ;

            FloydWarshall(graph, rows, cols);
        }

        public static void FloydWarshall(int[,] graph, int rows, int cols)
        {
            int[,] distance = new int[rows, cols];

            for (int i = 0; i < rows; ++i)
                for (int j = 0; j < cols; ++j)
                    distance[i, j] = graph[i, j];

            for (int k = 0; k < rows; ++k)
            {
                for (int i = 0; i < cols; ++i)
                {
                    for (int j = 0; j < cols; ++j)
                    {
                        if (distance[i, k] + distance[k, j] < distance[i, j])
                            distance[i, j] = distance[i, k] + distance[k, j];
                    }
                }
            }

            Print(distance, rows, cols);
        }

        private static int[,] ReadGraph(int rows, int cols)
        {
            var result = new int[rows, cols];

            for (int node = 0; node < rows; node++)
            {
                var capacities = Console.ReadLine()
                    .Split(" ")
                    .Select(int.Parse)
                    .ToArray();

                for (int child = 0; child < capacities.Length; child++)
                {
                    var capacity = capacities[child];

                    result[node, child] = capacity;
                }
            }

            return result;
        }

        private static void Print(int[,] distance, int rows, int cols)
        {
            Console.WriteLine("Shortest distances between every pair of vertices:");

            for (int i = 0; i < rows; ++i)
            {
                for (int j = 0; j < cols; ++j)
                {
                    if (distance[i, j] == INF)
                        Console.Write("INF".PadLeft(7));
                    else
                        Console.Write(distance[i, j].ToString().PadLeft(7));
                }

                Console.WriteLine();
            }
        }
    }
}
