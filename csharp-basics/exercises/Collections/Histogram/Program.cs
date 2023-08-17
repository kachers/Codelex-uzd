using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Histogram;

internal class Program
{
    private const string Path =
        "C:/Users/john/source/repos/Codelex-uzd/csharp-basics/exercises/Collections/Histogram/midtermscores.txt";

    private static void Main(string[] args)
    {
        var readText = File.ReadAllText(Path);
        var numbers = readText.Split(" ");

        var range = new SortedDictionary<int, int>();
        List<string> charList = new();
        for (var i = 0; i <= 100; i += 10)
        {
            range.Add(i, i + 9);
            charList.Add("");
        }

        foreach (var s in numbers)
        {
            var number = Convert.ToInt32(s);
            foreach (var kvp in range.Where(kvp => number >= kvp.Key && number < kvp.Value))
            { 
                charList[kvp.Key / 10] += "*";
            }
        }

        foreach (var kvp in range)
        {
            var formattedKey = kvp.Key < 100 ? $"{kvp.Key:D2}-{kvp.Key + 9:D2}" : $"  {kvp.Key}";
            Console.WriteLine($"{formattedKey}: {charList[kvp.Key / 10]}");
        }
    }
}