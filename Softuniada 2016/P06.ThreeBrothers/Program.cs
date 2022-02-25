using System;
using System.Linq;

namespace P06.ThreeBrothers
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var numberOfBags = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfBags; i++)
            {
                var presents = Console.ReadLine().Split().Select(int.Parse).ToArray();
                Console.WriteLine(IsSplitableToThreeEqualParts(presents) ? "Yes" : "No");
            }
        }

        private static bool IsSplitableToThreeEqualParts(int[] presents)
        {
            var totalSum = presents.Sum();
            if (totalSum % 3 != 0)
            {
                return false;
            }

            int targetSum = totalSum / 3;
            var reachedSums = new bool[targetSum + 1, targetSum + 1];
            reachedSums[0, 0] = true;

            foreach (var present in presents)
            {
                for (int rowSum = targetSum; rowSum >= 0; rowSum--)
                {
                    for (int colSum = targetSum; colSum >= 0; colSum--)
                    {
                        if (reachedSums[rowSum, colSum])
                        {
                            if (rowSum + present <= targetSum)
                            {
                                reachedSums[rowSum + present, colSum] = true;
                            }
                            if (colSum + present <= targetSum)
                            {
                                reachedSums[rowSum, colSum + present] = true;
                            }
                        }
                    }
                }
            }

            return reachedSums[targetSum, targetSum];
        }
    }
}
