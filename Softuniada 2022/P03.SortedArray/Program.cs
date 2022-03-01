using System;
using System.Linq;

namespace P03.SortedArray
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int arrayLength = int.Parse(Console.ReadLine());
            int[] array = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            for (int i = 0; i < array.Length; i++)
            {
                for (int n = 0; n < array.Length - 1; n++)
                {
                    if (n % 2 != 0)
                    {
                        if (array[n] >= array[n + 1])
                        {
                            int temp = array[n];
                            array[n] = array[n + 1];
                            array[n + 1] = temp;
                        }
                    }
                    else if (n % 2 == 0)
                    {
                        if (array[n] <= array[n + 1])
                        {
                            int temp = array[n];
                            array[n] = array[n + 1];
                            array[n + 1] = temp;
                        }
                    }

                }
            }
            Console.WriteLine(string.Join(' ', array));
        }
    }
}
