using System;
using System.Linq;

namespace P03.Nexus
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var firstSeq = Console.ReadLine().Split().Select(int.Parse).ToList();
            var secondSeq = Console.ReadLine().Split().Select(int.Parse).ToList();

            var line = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
            while (line[0] != "nexus")
            {
                var isNexus = false;

                var firstConnectionData = line[0].Split(":").Select(int.Parse).ToArray();
                var secondConnectionData = line[1].Split(":").Select(int.Parse).ToArray();

                var firstConnStartIndex = firstConnectionData[0];
                var firstConnEndIndex = firstConnectionData[1];

                var secondConnStartIndex = secondConnectionData[0];
                var secondConnEndIndex = secondConnectionData[1];

                if (secondConnStartIndex >= firstConnStartIndex && 
                    secondConnEndIndex < firstConnEndIndex)
                {
                    isNexus = true;
                }

                if (secondConnStartIndex <= firstConnStartIndex &&
                   secondConnEndIndex > firstConnEndIndex)
                {
                    isNexus = true;
                }

                var nexusValue = firstSeq[firstConnStartIndex] + secondSeq[firstConnEndIndex] +
                                    firstSeq[secondConnStartIndex] + secondSeq[secondConnEndIndex];

                if (isNexus)
                {
                    var start = Math.Min(firstConnStartIndex, secondConnStartIndex);
                    var end = Math.Max(firstConnStartIndex, secondConnStartIndex);

                    firstSeq.RemoveRange(start, end - start + 1);

                    start = Math.Min(firstConnEndIndex, secondConnEndIndex);
                    end = Math.Max(firstConnEndIndex, secondConnEndIndex);

                    secondSeq.RemoveRange(start, end - start + 1);
                    

                    for (int i = 0; i < firstSeq.Count; i++)
                    {
                        firstSeq[i] += nexusValue;
                    }

                    for (int i = 0; i < secondSeq.Count; i++)
                    {
                        secondSeq[i] += nexusValue;
                    }
                }

                line = Console.ReadLine().Split("|", StringSplitOptions.RemoveEmptyEntries);
            }

            Console.WriteLine(string.Join(", ", firstSeq));
            Console.WriteLine(string.Join(", ", secondSeq));
        }
    }
}
