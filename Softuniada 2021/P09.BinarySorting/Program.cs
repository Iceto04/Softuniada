using System;
using System.Collections.Generic;
using System.Linq;

namespace P09.BinarySorting
{
    internal class Program
    {
        private static List<string> binaryStrings;
        private static int zeros;
        private static int ones;

        static void Main(string[] args)
        {
            zeros = int.Parse(Console.ReadLine());
            ones = int.Parse(Console.ReadLine());

            var n = int.Parse(Console.ReadLine());

            binaryStrings = new List<string>();

            var length = zeros + ones;

            var arr = new int[length];

            GenerateVectors(arr, 0);

            Console.WriteLine(binaryStrings[n - 1]);
        }

        private static void GenerateVectors(int[] arr, int index)
        {
            if (index == arr.Length)
            {
                var binaryString = string.Join("", arr);
                var strZeros = binaryString.Count(x => x == '0');
                var strOnes = binaryString.Count(x => x == '1');
                if (strZeros == zeros && strOnes == ones)
                {
                    binaryStrings.Add(binaryString);
                }
                return;
            }

            for (int number = 0; number <= 1; number++)
            {
                arr[index] = number;
                GenerateVectors(arr, index + 1);
            }
        }
    }
}
