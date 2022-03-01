using System;
using System.Collections.Generic;
using System.Linq;

namespace P06.Placeholder
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            var figures = new List<Figure>();
            var tallestPossibleConstruction = 0;


            for (int i = 0; i < n; i++)
            {
                var data = Console.ReadLine()
                    .Split()
                    .Select(int.Parse)
                    .ToArray();

                var height = data[0];
                var width = data[1];
                var length = data[2];

                figures.Add(new Figure(height, width, length));
            }

            while (true)
            {
                foreach (var figure in figures)
                {
                    var width = figure.Width;
                    var length = figure.Length;
                    var height = figure.Height;

                    var maxWidth = figures.Max(figure => figure.Width);
                    var maxLength = figures.Max(figure => figure.Length);
                    if ()
                    {

                    }
                }
            }
        }
    }

    public class Figure
    {
        public Figure(int height, int width, int length)
        {
            Height = height;
            Width = width;
            Length = length;
        }

        public int Height { get; set; }

        public int Width { get; set; }

        public int Length { get; set; }
    }
}
