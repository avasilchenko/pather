using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using pather.Builders;
using pather.Helpers;
using pather.Models;

namespace pather
{
    class Program
    {
        static void Main(string[] args)
        {
#if DEBUG
            if (args.Length == 0)
                args = new[] {"input.txt", "output.txt"};
#endif

            if (args.Length == 0)
            {
                Console.WriteLine("Please enter source and destination files.");
                return;
            }

            if (!File.Exists(args[0]))
            {
                Console.WriteLine($"File '{args[0]}' does not exist.");
                return;
            }

            var contentLines = File.ReadAllLines(args[0]);

            PrintLines(contentLines);

            var coordinates = new List<Coordinate>();

            for (int i = 0; i < contentLines.Length; i++)
            {
                var indexes = contentLines[i].AllIndexesOf("#").ToList();

                if (indexes.Any())
                {
                    coordinates.AddRange(indexes.Select(x => new Coordinate(x, i)));
                }
            }

            var result = new PathBuilder(contentLines).BuildPath(coordinates);

            PrintLines(result);

            if (!File.Exists(args[1]))
                File.Create(args[1]);

            File.WriteAllLines(args[1], contentLines);
        }

        private static void PrintLines(string[] lines)
        {
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }

            Console.WriteLine(Environment.NewLine);
        }
    }
}
