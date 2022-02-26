using System;

namespace P01.Digitivision
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var a = int.Parse(Console.ReadLine());
            var b = int.Parse(Console.ReadLine());
            var c = int.Parse(Console.ReadLine());

            var sum = a + b + c;

            if (sum == 0)
            {
                Console.WriteLine("No digitivision possible!");
                return;
            }

            var posibble1 = a * 100 + b * 10 + c;
            var posibble2 = a * 100 + c * 10 + b;
            var posibble3 = b * 100 + a * 10 + c;
            var posibble4 = b * 100 + c * 10 + a;
            var posibble5 = c * 100 + a * 10 + b;
            var posibble6 = c * 100 + b * 10 + a;

            if (posibble1 % sum == 0 ||
                posibble2 % sum == 0 ||
                posibble3 % sum == 0 ||
                posibble4 % sum == 0 ||
                posibble5 % sum == 0 ||
                posibble6 % sum == 0)
            {
                Console.WriteLine("Digitivision successful!");
            }
            else
            {
                Console.WriteLine("No digitivision possible.");
            }
        }
    }
}
