using System;

namespace P09.SoftUniCoins
{
    internal class Program
    {
        public static void Main()
        {
            var n = long.Parse(Console.ReadLine());
            Console.WriteLine(DynamicProgramming(n));
        }

        private static long DynamicProgramming(long n)
        {
            // Solve for 0 to 99
            var dp = new long[100];
            for (var i = 0; i < 100; i++)
            {
                dp[i] = i;
            }

            for (var i = 10; i < 100; i++)
            {
                dp[i] = Math.Min(dp[i - 10] + 1, dp[i]);
            }

            for (var i = 25; i < 100; i++)
            {
                dp[i] = Math.Min(dp[i - 25] + 1, dp[i]);
            }

            // Solve for n for each 2 digits
            long count = 0;
            while (n > 0)
            {
                count += dp[(int)(n % 100)];
                n /= 100;
            }

            return count;
        }
    }
}
