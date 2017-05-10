using System.Collections.Generic;
using System.Text;
using pather.Models;

namespace pather.Builders
{
    public class PathBuilder
    {
        private const string Dot = ".";
        private const string Star = "*";

        public PathBuilder(string[] lines)
        {
            Lines = lines;
        }

        public string[] Lines { get; }

        public string[] BuildPath(List<Coordinate> coordinates)
        {
            for (int i = 0; i < coordinates.Count; i++)
            {
                if (i != coordinates.Count - 1)
                {
                    if (coordinates[i].Y != coordinates[i + 1].Y)
                    {
                        CreateVerticalLine(coordinates[i], coordinates[i + 1]);
                        CreateHorizontalLine(coordinates[i], coordinates[i + 1]);
                    }
                    else
                    {
                        CreateHorizontalLine(coordinates[i], coordinates[i + 1]);
                    }
                }
            }

            return Lines;
        }

        private void CreateHorizontalLine(Coordinate first, Coordinate second)
        {
            var builder = new StringBuilder(Lines[second.Y]);

            int amount;
            int start;

            if (second.X > first.X)
            {
                amount = second.X - first.X - 1;
                start = first.X;
            }
            else
            {
                amount = first.X - second.X - 1;
                start = second.X;
            }

            Lines[second.Y] = builder.Replace(Dot, Star, start + 1, amount).ToString();
        }

        private void CreateVerticalLine(Coordinate first, Coordinate second)
        {
            for (int i = first.Y + 1; i <= second.Y; i++)
            {
                var builder = new StringBuilder(Lines[i]);

                Lines[i] = builder.Replace(Dot, Star, first.X, 1).ToString();
            }
        }
    }
}
