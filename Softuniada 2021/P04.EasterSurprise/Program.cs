using System;
using System.Linq;

namespace P04.EasterSurprise
{
    public class Program
    {
        private static char[,] matrix;
        private static int rows;
        private static int cols;

        private static int initialRow;
        private static int initialCol;

        private static bool[,] visited;

        public static void Main(string[] args)
        {
            var sizes = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            rows = sizes[0];
            cols = sizes[1];

            matrix = ReadMatrix();

            visited = new bool[rows, cols];

            var symbolFound = char.Parse(Console.ReadLine());

            var startData = Console.ReadLine()
                .Split()
                .Select(int.Parse)
                .ToArray();

            initialRow = startData[0];
            initialCol = startData[1];

            var initialSymbol = matrix[initialRow, initialCol];

            ChangeEggs(initialRow, initialCol, initialSymbol, symbolFound);

            PrintMatrix();
        }

        private static void ChangeEggs(int row, int col, char initialSymbol, char symbolFound)
        {
            if (IsOutside(row, col))
            {
                return;
            }

            if (visited[row, col])
            {
                return;
            }

            if (matrix[row, col] != initialSymbol)
            {
                return;
            }

            visited[row, col] = true;
            matrix[row, col] = symbolFound;

            ChangeEggs(row + 1, col, initialSymbol, symbolFound);
            ChangeEggs(row - 1, col, initialSymbol, symbolFound);
            ChangeEggs(row, col + 1, initialSymbol, symbolFound);
            ChangeEggs(row, col - 1, initialSymbol, symbolFound);
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write($"{matrix[row, col]}");
                }
                Console.WriteLine();
            }
        }

        private static char[,] ReadMatrix()
        {
            var result = new char[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine()
                    .Split()
                    .Select(char.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    result[row, col] = line[col];
                }
            }

            return result;
        }

        private static bool IsOutside(int row, int col)
        {
            return row < 0 ||
                col < 0 ||
                row >= matrix.GetLength(0) ||
                col >= matrix.GetLength(1);
        }
    }
}
