using System;

namespace P08.Rooks
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());
            var rooks = int.Parse(Console.ReadLine());

            if (rows == 1)
            {
                Console.WriteLine(0);
                return;
            }

            long result = (rows * cols) * (rows * cols - 1) / rooks;
            Console.WriteLine(result % 1_000_001);
        }
    }
}
