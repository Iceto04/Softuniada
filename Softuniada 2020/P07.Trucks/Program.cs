using System;
using System.Collections.Generic;
using System.Linq;

namespace P07.Trucks
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string start = Console.ReadLine();
            string end = Console.ReadLine();

            Dictionary<string, Node<string>> graph = new Dictionary<string, Node<string>>();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split();
                string from = input[0];
                string to = input[1];
                int capacity = int.Parse(input[2]);

                if (!graph.ContainsKey(from))
                {
                    graph.Add(from, new Node<string>(from));
                }
                if (!graph.ContainsKey(to))
                {
                    graph.Add(to, new Node<string>(to));
                }

                var edge = new Edge<string>();

                edge.From = graph[from];
                edge.To = graph[to];
                edge.Capacity += capacity;
                graph[from].Edges.Add(edge);

                edge = new Edge<string>();
                edge.From = graph[to];
                edge.To = graph[from];
                edge.Capacity = 0;
                edge.IsBackwards = true;
                graph[to].Edges.Add(edge);
            }

            Console.WriteLine(Fulkursen(graph, start, end));
        }

        public static int Fulkursen<T>(Dictionary<T, Node<T>> graph, T start, T end)
            where T : class
        {
            int maxFlow = 0;
            Dictionary<T, T> path = new Dictionary<T, T>();

            while (BFS(graph, start, end, path))
            {
                int minFlow = int.MaxValue;
                var current = end;

                while (path[current] != default(T))
                {
                    var old = current;
                    current = path[current];

                    var edge = graph[current].Edges.First(x => x.To.Value.Equals(old));

                    minFlow = Math.Min(minFlow, edge.Capacity - edge.CurrentFlow);
                }

                current = end;

                while (path[current] != default(T))
                {
                    var old = current;
                    current = path[current];

                    var edge = graph[current].Edges.First(x => x.To.Value.Equals(old));
                    edge.CurrentFlow += minFlow;

                    var backEdge = graph[old].Edges.FirstOrDefault(x => x.To.Value.Equals(current));

                    if (backEdge != null && backEdge.IsBackwards)
                        backEdge.CurrentFlow -= minFlow;
                }
                maxFlow += minFlow;

                path = new Dictionary<T, T>();
            }

            return maxFlow;
        }

        public static void Print<T>(Dictionary<T, Node<T>> graph, Node<T> node, int level, HashSet<T> visited, int cap, int flow)
        {
            Console.WriteLine(new string(' ', level) + (node.Value) + " => " + cap + ":" + flow);
            Console.Write(new string(' ', level));

            foreach (var item in node.Edges)
            {
                Console.Write("  " + $"{item.From.Value}:{item.To.Value}:{item.Capacity}:{item.IsBackwards}  ,  ");
            }

            Console.WriteLine();

            foreach (var item in node.Edges)
            {
                if (!item.IsBackwards && !visited.Contains(item.To.Value))
                {
                    visited.Add(item.To.Value);
                    Print(graph, graph[item.To.Value], level + 5, visited, item.Capacity, item.CurrentFlow);
                }
            }
        }

        public static bool BFS<T>(Dictionary<T, Node<T>> graph, T start, T end, Dictionary<T, T> path)
        {
            Queue<Node<T>> queue = new Queue<Node<T>>();
            queue.Enqueue(graph[start]);

            HashSet<T> visited = new HashSet<T>();
            visited.Add(start);

            path.Add(start, default(T));

            while (queue.Count != 0)
            {
                var node = queue.Dequeue();

                for (int j = 0; j < node.Edges.Count; j++)
                {
                    var edge = node.Edges[j];

                    if (edge.Capacity - edge.CurrentFlow > 0 && !visited.Contains(edge.To.Value))
                    {
                        path.Add(edge.To.Value, node.Value);
                        queue.Enqueue(edge.To);
                        visited.Add(edge.To.Value);
                    }
                }
            }

            return visited.Contains(end);
        }
    }

    public class Edge<T>
    {
        public bool IsBackwards { get; set; }
        public Node<T> From { get; set; }

        public Node<T> To { get; set; }

        public int Capacity { get; set; }

        public int CurrentFlow { get; set; }
    }

    public class Node<T>
    {
        public Node(T value)
        {
            this.Value = value;
            this.Edges = new List<Edge<T>>();
        }
        public List<Edge<T>> Edges { get; set; }

        public T Value { get; set; }
    }
}
