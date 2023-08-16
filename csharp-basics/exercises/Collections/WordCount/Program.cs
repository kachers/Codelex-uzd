using System;
using System.IO;
using System.Linq;

namespace WordCount;

public class Program
{
    private static void Main(string[] args)
    {
        var filePath = "C:/Users/john/source/repos/Codelex-uzd/csharp-basics/exercises/Collections/WordCount/lear.txt";

        if (File.Exists(filePath))
        {
            var lines = File.ReadAllLines(filePath);
            var lineCount = lines.Length;
            var wordCount = lines
                .SelectMany(line => line.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries))
                .Count(word => word.All(char.IsLetterOrDigit));
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