using System;

namespace P01.DreamCar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = double.Parse(Console.ReadLine());
            var m = double.Parse(Console.ReadLine());
            var x = double.Parse(Console.ReadLine());
            var y = double.Parse(Console.ReadLine());
            var t = double.Parse(Console.ReadLine());

            var sum = 0.0;
            for (int i = 0; i < t; i++)
            {
                sum += n + (i * x);
            }
            ;

            sum -= t * m;

            if (sum >= y)
            {
                Console.WriteLine("Have a nice ride!");
            }
            else
            {
                Console.WriteLine("Work harder!");
            }
        }
    }
}
