using System;
using System.Collections.Generic;
using System.Linq;

namespace P04.SpiralMatrix
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var rows = int.Parse(Console.ReadLine());
            var cols = int.Parse(Console.ReadLine());

            var matrix = new int[rows, cols];

            for (int row = 0; row < rows; row++)
            {
                var line = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                for (int col = 0; col < cols; col++)
                {
                    matrix[row, col] = line[col];
                }
            }

            var output = GetItemsInSpiralOrder(matrix);
            Console.WriteLine(string.Join(" ", output));
        }

        private static List<int> GetItemsInSpiralOrder(int[,] matrix)
        {

            List<int> result = new List<int>();

            if (matrix.Length == 0)
            {
                return result;
            }

            int rowStart = 0;
            int rowEnd = matrix.GetLength(0) - 1;
            int columnStart = 0;
            int coloumnEnd = matrix.GetLength(1) - 1;

            while (rowStart <= rowEnd && columnStart <= coloumnEnd)
            {
                for (int c = columnStart; c <= coloumnEnd; c++)
                {
                    result.Add(matrix[rowStart, c]);
                }

                for (int r = rowStart + 1; r <= rowEnd; r++)
                {
                    result.Add(matrix[r, coloumnEnd]);
                }

                if (rowStart < rowEnd && columnStart < coloumnEnd)
                {
                    
                    for (int c = coloumnEnd - 1; c > columnStart; c--)
                    {
                        result.Add(matrix[rowEnd, c]);
                    }

                    for (int r = rowEnd; r > rowStart; r--)
                    {
                        result.Add(matrix[r, columnStart]);
                    }
                }

                rowStart++;
                rowEnd--;
                columnStart++;
                coloumnEnd--;
            }
            return result;
        }
    }
}
