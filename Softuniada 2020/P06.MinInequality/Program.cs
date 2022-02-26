using System;

namespace P06.MinInequality
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var k = int.Parse(Console.ReadLine());
            var n = int.Parse(Console.ReadLine());

            var numbers = new int[n];

            for (var i = 0; i < n; i++)
            {
                var currentNumber = int.Parse(Console.ReadLine());
                numbers[i] = currentNumber;
            }

            Array.Sort(numbers);
            var minDiff = int.MaxValue;

            for (var i = k - 1; i < n; i++)
            {
                var currentDiff = numbers[i] - numbers[i - (k - 1)];

                if (currentDiff < minDiff)
                {
                    minDiff = currentDiff;
                }
            }

            Console.WriteLine(minDiff);
        }
    }
}
