using System;

namespace P01.SumOfGCPandLCM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());

            var gcd = GCD(a, b);
            var lcm = LCM(a, b);

            Console.WriteLine(gcd + lcm);
        }

        private static int GCD(int a, int b)
        {
            int Remainder;

            while (b != 0)
            {
                Remainder = a % b;
                a = b;
                b = Remainder;
            }

            return a;
        }

        private static int LCM(int a, int b)
        {
            return (a / GCD(a, b)) * b;
        }
    }
}
