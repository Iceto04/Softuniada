using System;

namespace P06.Tri_Force
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var perimeter = int.Parse(Console.ReadLine());
            var radius = double.Parse(Console.ReadLine());

            var biggestSide = (int)(radius * 2);
            int a = 2;
            int b = -(perimeter - biggestSide) * 2;
            int c = (perimeter - biggestSide) * (perimeter - biggestSide) - biggestSide * biggestSide;

            double x1 = 0;
            double x2 = 0;
            double d = b * b - 4 * a * c;
            if (d == 0)
            {
                x1 = -b / (2.0 * a);
                x2 = x1;
            }
            else if (d > 0)
            {
                x1 = (-b + Math.Sqrt(d)) / (2 * a);
                x2 = (-b - Math.Sqrt(d)) / (2 * a);
            }

            int middleSide = (int)x1;
            int lastSide = (int)x2;
            if (x1 < x2)
            {
                middleSide = (int)x2;
                lastSide = (int)x1;
            }

            Console.WriteLine($"{biggestSide}.{middleSide}.{lastSide}");
            Console.WriteLine($"{biggestSide}.{lastSide}.{middleSide}");
            Console.WriteLine($"{middleSide}.{biggestSide}.{lastSide}");
            Console.WriteLine($"{middleSide}.{lastSide}.{biggestSide}");
            Console.WriteLine($"{lastSide}.{biggestSide}.{middleSide}");
            Console.WriteLine($"{lastSide}.{middleSide}.{biggestSide}");

        }
    }
}
