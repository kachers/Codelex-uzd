using System;
using System.IO;

namespace Histogram
{
    class Program
    {
        private const string Path = "../Histogram/midtermscores.txt";

        private static void Main(string[] args)
        {
            var readText = File.ReadAllLines(Path);
            foreach (var s in readText)
            {
                Console.WriteLine(s);
            }
        }
    }
}
