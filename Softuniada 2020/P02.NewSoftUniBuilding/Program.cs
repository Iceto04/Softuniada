using System;

namespace P02.NewSoftUniBuilding
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());

            int width = size;
            int height = size + size / 2;

            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    bool isStripe = (j + i) % 4 == 0;

                    if (isStripe)
                    {
                        Console.Write("#");
                    }
                    else
                    {
                        Console.Write(".");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
