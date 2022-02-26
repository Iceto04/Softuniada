using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.SoftJump
{
    internal class Program
    {
        private static string[][] matrix;
        private static int playerRow;
        private static int playerCol;
        private static int totalJumps;

        public static void Main()
        {
            Initialize();

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] coordinates = Console.ReadLine()
                   .Split();

                int row = int.Parse(coordinates[0]);
                int steps = int.Parse(coordinates[1]);

                Move(row, steps);
                Jump();
            }


            Console.WriteLine("Lose");
            Console.WriteLine($"Total Jumps: {totalJumps}");
            matrix[^1] = new[] { new string('0', matrix[0].Length) };
            Print();
        }

        private static void Print()
        {
            foreach (var row in matrix)
            {
                Console.WriteLine(string.Join("", row));
            }
        }

        private static void Jump()
        {
            int desiredRow = playerRow - 1;

            if (desiredRow == 0 && matrix[desiredRow][playerCol] == "-")
            {
                totalJumps++;
                Console.WriteLine("Win");
                Console.WriteLine($"Total Jumps: {totalJumps}");
                matrix[playerRow][playerCol] = "-";
                matrix[--playerRow][playerCol] = "S";
                matrix[^1] = new[] { new string('0', matrix[0].Length) };
                Print();
                Environment.Exit(0);
            }

            if (matrix[desiredRow][playerCol] == "-")
            {
                totalJumps++;
                matrix[playerRow][playerCol] = "-";
                playerRow--;
                matrix[playerRow][playerCol] = "S";
            }
        }

        private static void Move(int row, int steps)
        {
            var listOfIndexes = new HashSet<int>();

            for (int col = 0; col < matrix[row].Length; col++)
            {
                if (matrix[row][col] == "-")
                {
                    int targetIndex = (col + steps) % matrix[row].Length;
                    listOfIndexes.Add(targetIndex);
                }
            }

            for (int col = 0; col < matrix[row].Length; col++)
            {
                if (listOfIndexes.Contains(col))
                    matrix[row][col] = "-";
                else
                    matrix[row][col] = "0";
            }
        }

        private static void Initialize()
        {
            int[] dimensions = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            int rows = dimensions[0];
            int cols = dimensions[1];

            matrix = new string[rows][];

            for (int row = 0; row < matrix.Length; row++)
            {
                matrix[row] = new string[cols];
                string inputRow = Console.ReadLine();

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    matrix[row][col] = inputRow[col].ToString();

                    if (matrix[row][col] == "S")
                    {
                        playerRow = row;
                        playerCol = col;
                    }
                }
            }
        }
    }
}
