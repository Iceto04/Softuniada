using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.StarsInTheCube
{
    internal class Program
    {
        private static char[,,] cube;
        private static readonly Dictionary<char, int> starsCount = new Dictionary<char, int>();
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());
            cube = new char[n, n, n];
            ReadCube(n);

            FindStars();

            PrintResult();

        }

        private static void PrintResult()
        {
            Console.WriteLine(starsCount.Values.Sum());

            foreach (var letterByStair in starsCount.OrderBy(x => x.Key))
            {
                Console.WriteLine($"{letterByStair.Key} -> {letterByStair.Value}");
            }
        }

        private static void FindStars()
        {
            for (int depth = 0; depth < cube.GetLength(0) - 2; depth++)
            {
                for (int row = 1; row < cube.GetLength(1) - 1; row++)
                {
                    for (int col = 1; col < cube.GetLength(2) - 1; col++)
                    {
                        char currentLettter = cube[depth, row, col];

                        if (cube[depth + 1, row, col] == currentLettter &&
                            cube[depth + 1, row + 1, col] == currentLettter &&
                            cube[depth + 1, row - 1, col] == currentLettter &&
                            cube[depth + 1, row, col + 1] == currentLettter &&
                            cube[depth + 1, row, col - 1] == currentLettter &&
                            cube[depth + 2, row, col] == currentLettter)
                        {
                            if (!starsCount.ContainsKey(currentLettter))
                            {
                                starsCount.Add(currentLettter, 0);
                            }

                            starsCount[currentLettter]++;
                        }
                    }
                }
            }
        }

        private static void ReadCube(int n)
        {
            for (int row = 0; row < n; row++)
            {
                var layer = Console.ReadLine().Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);

                for (int depth = 0; depth < n; depth++)
                {
                    var letters = layer[depth].Split().Select(char.Parse).ToArray();

                    for (int col = 0; col < n; col++)
                    {
                        cube[depth, row, col] = letters[col];
                    }
                }
            }
        }
    }
}
