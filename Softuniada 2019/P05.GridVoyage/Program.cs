using System;
using System.Linq;

namespace P05.GridVoyage
{
    internal class Program
    {
        private const string Down = "down";
        private const string Up = "up";
        private const string Right = "right";
        private const string Left = "left";
        private static int size;
        private static int[,] matrix;

        static void Main(string[] args)
        {
            size = int.Parse(Console.ReadLine());

            matrix = new int[size, size];

            var startData = Console.ReadLine().Split();
            int row = int.Parse(startData[0]);
            int col = int.Parse(startData[1]);

            var line = Console.ReadLine();
            while (line != "eastern odyssey")
            {
                var destinationData = line.Split();

                var targetRow = int.Parse(destinationData[0]);
                var targetCol = int.Parse(destinationData[1]);

                var direction = destinationData[2];
                var stamina = int.Parse(destinationData[3]);

                var rests = -1;

                bool isVoyagePossible = Math.Abs(targetRow - row) % stamina == 0 && Math.Abs(targetCol - col) % stamina == 0;
                if (!isVoyagePossible)
                {
                    Console.WriteLine("Voyage impossible");
                    line = Console.ReadLine();
                    continue;
                }

                while (true)
                {
                    var currStamina = stamina;
                    rests++;
                    if (!IsPossibleTurn(row, col, currStamina, direction))
                    {
                        isVoyagePossible = false;
                        break;
                    }

                    while (currStamina > 0)
                    {
                        if (direction == Left)
                        {
                            col--;
                        }
                        else if (direction == Right)
                        {
                            col++;
                        }
                        else if (direction == Down)
                        {
                            row++;
                        }
                        else if (direction == Up)
                        {
                            row--;
                        }

                        matrix[row, col]++;
                        currStamina--;
                    }

                    if (row == targetRow && col == targetCol)
                    {
                        break;
                    }

                    direction = GetNextDirection(row, col, direction, targetRow, targetCol, stamina);

                    if (direction == null)
                    {
                        isVoyagePossible = false;
                        break;
                    }
                }

                if (!isVoyagePossible)
                {
                    Console.WriteLine("Voyage impossible");
                }
                else
                {
                    Console.WriteLine(rests);
                }

                line = Console.ReadLine();
            }

            PrintMatrix();
        }

        private static void PrintMatrix()
        {
            for (int row = 0; row < size; row++)
            {
                for (int col = 0; col < size; col++)
                {
                    Console.Write($"{matrix[row, col]} ");
                }

                Console.WriteLine();
            }
        }

        private static bool IsPossibleTurn(int row, int col, int currentStamina, string direction)
        {
            bool isPossible = false;

            if (direction == Right && col + currentStamina < size)
            {
                isPossible = true;
            }
            else if (direction == Left && col - currentStamina >= 0)
            {
                isPossible = true;
            }
            else if (direction == Down && row + currentStamina < size)
            {
                isPossible = true;
            }
            else if (direction == Up && row - currentStamina >= 0)
            {
                isPossible = true;
            }

            return isPossible;
        }

        private static string GetNextDirection(int row, int col, string direction, int targetRow, int targetCol, int stamina)
        {
            string nextDirection = null;

            if (direction == Left)
            {
                if (targetRow >= row && row + stamina < size)
                {
                    nextDirection = Down;
                }
                else if (row - stamina >= 0)
                {
                    nextDirection = Up;
                }
            }
            else if (direction == Right)
            {
                if (targetRow <= row && row - stamina >= 0)
                {
                    nextDirection = Up;
                }
                else if (row + stamina < size)
                {
                    nextDirection = Down;
                }
            }
            else if (direction == Up)
            {
                if (targetCol <= col && col - stamina >= 0)
                {
                    nextDirection = Left;
                }
                else if (col + stamina < size)
                {
                    nextDirection = Right;
                }
            }
            else if (direction == Down)
            {
                if (targetCol >= col && col + stamina < size)
                {
                    nextDirection = Right;
                }
                else if (col - stamina >= 0)
                {
                    nextDirection = Left;
                }
            }

            return nextDirection;
        }
    }
}
