using System;
using System.Linq;

namespace P04.Elemelons
{
    internal class Program
    {
        private const char Watermelon = 'W';
        private const char Earthmelon = 'E';
        private const char Firemelon = 'F';
        private const char Airmelon = 'A';
        private static char[,,] cube;
        private static int size;

        static void Main(string[] args)
        {
            size = int.Parse(Console.ReadLine());
            cube = new char[size, size, size];
            ReadCube();

            var line = Console.ReadLine();
            while (line != "Melolemonmelon")
            {
                var cellIndexes = line.Split().Select(int.Parse).ToArray();
                var targetLayer = cellIndexes[0];
                var targetRow = cellIndexes[1];
                var targetCol = cellIndexes[2];

                cube[targetLayer, targetRow, targetCol] = '0';

                for (int layer = 0; layer < cube.GetLength(0); layer++)
                {
                    for (int row = 0; row < cube.GetLength(1); row++)
                    {
                        for (int col = 0; col < cube.GetLength(2); col++)
                        {
                            if (layer == targetLayer && row == targetRow && (col == targetCol - 1 || col == targetCol + 1))
                            {
                                continue;
                            }

                            if (layer == targetLayer && (row == targetRow - 1 || row == targetRow + 1) && col == targetCol)
                            {
                                continue;
                            }

                            if ((layer == targetLayer - 1 || layer == targetLayer + 1) && 
                                row == targetRow && col == targetCol)
                            {
                                continue;
                            }

                            cube[layer, row, col] = Morph(cube[layer, row, col]);
                        }
                    }
                }

                line = Console.ReadLine();
            }

            for (int row = 0; row < size; row++)
            {
                for (int layer = 0; layer < size; layer++)
                {
                    for (int col = 0; col < size; col++)
                    {
                        Console.Write($"{cube[layer, row, col]} ");
                    }

                    if (layer < size - 1)
                    {
                        Console.Write("| ");
                    }
                }

                Console.WriteLine();
            }
        }

        private static void ReadCube()
        {
            /*
            for (int row = 0; row < size; row++)
            {
                var layer = Console.ReadLine().Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);

                for (int depth = 0; depth < size; depth++)
                {
                    var letters = layer[depth].Split().Select(char.Parse).ToArray();

                    for (int col = 0; col < size; col++)
                    {
                        cube[depth, row, col] = letters[col];
                    }
                }
            }
            */

            for (int row = 0; row < cube.GetLength(1); row++)
            {
                string[] layers = Console.ReadLine().Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);

                for (int depth = cube.GetLength(0) - 1; depth >= 0; depth--)
                {
                    string[] elements = layers[depth].Split();
                    for (int col = 0; col < cube.GetLength(2); col++)
                    {
                        cube[depth, row, col] = char.Parse(elements[col]);
                    }
                }
            }
        }

        private static char Morph(char initialState)
        {
            switch (initialState)
            {
                case Watermelon:
                    return Earthmelon;
                case Earthmelon:
                    return Firemelon;
                case Firemelon:
                    return Airmelon;
                case Airmelon:
                    return Watermelon;
                default:
                    return initialState;
            }
        }
    }
}
