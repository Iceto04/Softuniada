using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.TheGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();
            var expectedOutput = Console.ReadLine();

            var map1 = GetFrequencyMap(input.ToCharArray());
            var map2 = GetFrequencyMap(expectedOutput.ToCharArray());

            ;

            if (isTransformable(input.ToCharArray(), expectedOutput.ToCharArray()))
            {
                Console.WriteLine($"The minimum operations required to convert \"{input}\" to \"{ expectedOutput}\"" +
                    $" are {GetMinimumOperations(input, expectedOutput)}");
            }
            else
            {
                Console.WriteLine("The name cannot be transformed!");
            }
        }
        public static int GetMinimumOperations(string first, string second)
        {
            int count = 0;

            for (int i = first.Length - 1, j = i; i >= 0; i--, j--)
            {
                while (i >= 0 && first[i] != second[j])
                {
                    i--;
                    count++;
                }
            }

            return count;
        }

        public static bool isTransformable(char[] first, char[] second)
        {
            if (first == null || second == null)
            {
                return false;
            }
            if (first.Length != second.Length)
            {
                return false;
            }

            var dic1 = GetFrequencyMap(first);
            var dic2 = GetFrequencyMap(second);
            return dic1.Count == dic2.Count && !dic1.Except(dic2).Any();
        }
        public static Dictionary<char, int> GetFrequencyMap(char[] chars)
        {
            return chars.GroupBy(x => x).ToDictionary(x => x.Key, x => x.Count());
        }
    }
}
