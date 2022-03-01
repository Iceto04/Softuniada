using System;
using System.Collections.Generic;
using System.Linq;

namespace P08.Satelites
{
    internal class Program
    {
        private static SortedDictionary<string, List<string>> graph;
        private static int smallestNexusNodesCount;
        private static HashSet<string> smallestNexus;
        private static Dictionary<string, bool> visited;

        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            visited = new Dictionary<string, bool>();

            graph = ReadGraph(n);
            smallestNexusNodesCount = int.MaxValue;

            foreach (var node in graph.Keys)
            {
                if (visited[node])
                {
                    continue;
                }

                var component = new List<string>();
                DFS(node, component);
                if (smallestNexusNodesCount > component.Count && component.Count >= 4)
                {
                    smallestNexus = new HashSet<string>(component);
                }
            }

            ;

            foreach (var node in graph.Where(x => x.Value.Count >= 3))
            {

                var key = node.Key;
                if (!smallestNexus.Contains(key))
                {
                    continue;
                }

                var children = node.Value;

                foreach (var child in children.OrderBy(x => x))
                {
                    Console.WriteLine($"{key} <-> {child}");
                }
            }
        }

        private static void DFS(string node, List<string> component)
        {
            if (visited[node])
            {
                return;
            }

            visited[node] = true;

            foreach (var child in graph[node])
            {
                DFS(child, component);
            }

            component.Add(node);
        }

        private static SortedDictionary<string, List<string>> ReadGraph(int n)
        {
            var result = new SortedDictionary<string, List<string>>();

            for (int i = 0; i < n; i++)
            {
                var edgeData = Console.ReadLine()
                    .Split();

                var first = edgeData[0];
                var second = edgeData[1];

                if (!result.ContainsKey(first))
                {
                    result.Add(first, new List<string>());
                }

                if (!result.ContainsKey(second))
                {
                    result.Add(second, new List<string>());
                }

                result[first].Add(second);
                result[second].Add(first);

                visited[first] = false;
                visited[second] = false;
            }

            return result;
        }
    }
}
