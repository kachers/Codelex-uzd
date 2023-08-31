using System;
using System.IO;
using System.Linq;

namespace WordCount;

public class Program
{
    private static void Main(string[] args)
    {
        var filePath = "../../../lear.txt";

        if (File.Exists(filePath))
        {
            var lines = File.ReadAllLines(filePath);
            var lineCount = lines.Length;
            var wordCount = lines.SelectMany(line => line
                    .Split(' ', '\''))
                .Count(word => word.Length > 0);

            var charCount = lines.Sum(line => line.Length);

            Console.WriteLine($"Lines = {lineCount}");
            Console.WriteLine($"Words = {wordCount}");
            Console.WriteLine($"Chars = {charCount}");
        }
        else
        {
            Console.WriteLine("File not found.");
        }
    }
}