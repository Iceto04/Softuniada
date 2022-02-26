using System;
using System.Linq;

namespace P05.HolidayTreat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var nums = Console.ReadLine()
                .Split(", ")
                .Select(int.Parse)
                .ToArray();

            var k = int.Parse(Console.ReadLine());

            var numberOfWorkers = nums.Sum();

            if (numberOfWorkers % k != 0)
            {
                Console.WriteLine("Packaging is not possible!");
                return;
            }

            var bagsCapacity = numberOfWorkers / k;

            // Console.WriteLine(CanPartitionKSubsets(nums, k));
        }

        private static bool CanPartitionKSubsets(int[] nums, int k)
        {
            int sumOfArrayItems = nums.Sum();

            if (k == 0 || sumOfArrayItems % k != 0)
            {
                return false;
            }
            return CanPartition(0, nums, new bool[nums.Length], k, 0, sumOfArrayItems / k);
        }

        private static bool CanPartition(int iterationStart, int[] nums, bool[] used, int k, int inProgressBucketSum, int targetBucketSum)
        {
            if (k == 1)
            {
                return true;
            }

            if (inProgressBucketSum == targetBucketSum)
            {
                return CanPartition(0, nums, used, k - 1, 0, targetBucketSum);
            }

            for (int i = iterationStart; i < nums.Length; i++)
            {
                if (!used[i])
                {
                    used[i] = true;
                    if (CanPartition(i + 1, nums, used, k, inProgressBucketSum + nums[i], targetBucketSum))
                    {
                        return true;
                    }
                    used[i] = false;
                }
            }
            return false;
        }
    }
}
