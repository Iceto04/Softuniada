using System;

namespace P10.SoftUniUsernames
{
    internal class Program
    {
        private const int Mod = 1000000007; // prime number
        private static long[] factorials; // index!
        private static long[] reverseFactorials; // 1 / index!
        private static long[] powersOf10; // 10 ^ index
        private static long[] powersOf30; // 30 ^ index

        public static void Main()
        {
            int n = int.Parse(Console.ReadLine());
            int d = int.Parse(Console.ReadLine());
            int l = int.Parse(Console.ReadLine());
            int u = int.Parse(Console.ReadLine());

            // pre-calculate the factorials and their modular multiplicative inverses
            factorials = new long[n + 1];
            reverseFactorials = new long[n + 1];
            factorials[0] = reverseFactorials[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                factorials[i] = (i * factorials[i - 1]) % Mod;

                // lets say i! is equal to x. So we need 1/x which is equal to x^(-1)
                // by Fermat's little theorem: x^(-1) mod m = x^(m-2) mod m
                reverseFactorials[i] = ModuloPower(factorials[i], Mod - 2);
            }

            // pre-calculate the powers of 30 and 10
            powersOf10 = new long[n + 1];
            powersOf30 = new long[n + 1];
            powersOf10[0] = powersOf30[0] = 1;
            for (int i = 1; i <= n; i++)
            {
                powersOf10[i] = (10 * powersOf10[i - 1]) % Mod;
                powersOf30[i] = (30 * powersOf30[i - 1]) % Mod;
            }

            var answer = Solve(n, d, l, u);
            Console.WriteLine(answer);
        }

        // calculates (x raised to the y-th power) modulo Mod using divide and conquer
        private static long ModuloPower(long x, long y)
        {
            long result = 1;
            while (y > 0)
            {
                if ((y & 1) != 0)
                {
                    result = (result * x) % Mod;
                }

                x = (x * x) % Mod;
                y /= 2;
            }

            return result;
        }

        // calculates the binomial/combinations(n,k)
        private static long BinomialCoefficient(int n, int k)
        {
            return (((factorials[n] * reverseFactorials[k]) % Mod) * reverseFactorials[n - k]) % Mod;
        }

        private static int Solve(int n, int d, int l, int u)
        {
            // prepare the array: "number of binary sequences of length A with at least l zeros and u ones"
            long[] count = new long[n + 1];
            count[0] = (l + u == 0) ? 1 : 0;
            for (int i = 1; i <= n; i++)
            {
                if (i >= l + u)
                {
                    count[i] = 2 * count[i - 1];

                    // avoid calling BinomialCoefficient() on negative values.
                    if (l > 0)
                    {
                        count[i] += BinomialCoefficient(i - 1, l - 1);
                    }

                    if (u > 0)
                    {
                        count[i] += BinomialCoefficient(i - 1, u - 1);
                    }

                    count[i] %= Mod;
                }
            }

            // solve the main problem:
            long result = 0;
            for (int i = l + u; i <= n - d; i++)
            {
                long current = 1;

                // number of ways to have i letters, with at least u upper case and l lower case: count[i]*powersOf30[i]
                current = (current * count[i]) % Mod;
                current = (current * powersOf30[i]) % Mod;

                // the remaining factors, there are 10^(n-i) ways to have the digit part of the password
                // and BinomialCoefficient(n,i) ways to choose the letter positions in the password of n characters.
                current = (current * powersOf10[n - i]) % Mod;
                current = (current * BinomialCoefficient(n, i)) % Mod;
                result = (result + current) % Mod;
            }

            return (int)result;
        }
    }
}
