using System;

namespace P09.Moneypoly
{
    internal class Program
    {
        static void Main(string[] args)
        {
            
        }
    }

    public class Edge
    {
        public Node First { get; set; }

        public Node Second { get; set; }

        public int Weight { get; set; }

        public override string ToString()
        {
            return $"{this.First} {this.Second} {this.Weight}";
        }
    }

    public class Node
    {
        public int Name { get; set; }

        public int Value { get; set; }
    }
}
