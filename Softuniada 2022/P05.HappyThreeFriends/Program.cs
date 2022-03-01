using System;
using System.Collections.Generic;
using System.Linq;

namespace P05.HappyThreeFriends
{
    internal class Program
    {
        static Dictionary<string, int> cache;
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                var bottles = Console.ReadLine().Split().Select(int.Parse).ToArray();
                cache = new Dictionary<string, int>();
                CheckEqualSum(bottles, bottles.Length);
            }
        }

        static int CheckEqualSumUtil(int[] arr, int length, int sum1, int sum2, int sum3, int j)
        {
            string key = sum1.ToString() + "_" + sum2.ToString() + j.ToString();

            if (j == length)
            {
                if (sum1 == sum2 && sum2 == sum3)
                    return 1;
                else
                    return 0;
            }

            if (cache.ContainsKey(key))
            {
                return cache[key];
            }
            else
            {
                int l = CheckEqualSumUtil(arr, length, sum1 + arr[j], sum2, sum3, j + 1);
                int m = CheckEqualSumUtil(arr, length, sum1, sum2 + arr[j], sum3, j + 1);
                int r = CheckEqualSumUtil(arr, length, sum1, sum2, sum3 + arr[j], j + 1);

                cache[key] = Math.Max(Math.Max(l, m), r);

                return cache[key];
            }
        }
        static void CheckEqualSum(int[] arr, int length)
        {
            int sum1 = 0;
            int sum2 = 0;
            int sum3 = 0;

            if (CheckEqualSumUtil(arr, length, sum1, sum2, sum3, 0) == 1)
            {
                Console.WriteLine("Yes");
            }
            else
            {
                Console.WriteLine("No");
            }
        }

    }
}
