using System;
using System.Collections.Generic;

namespace ListExercise9;

internal class Program
{
    private static void Main(string[] args)
    {
        var firstList = new List<string>
        {
            "Red",
            "Green",
            "Black",
            "White",
            "Pink"
        };

        Console.WriteLine(string.Join(",", firstList));

        var secondList = new List<string>
        {
            "Red",
            "Green",
            "Black",
            "White",
            "Pink"
        };

        Console.WriteLine(string.Join(",", secondList));
        var combinedList = new List<string>(firstList);
        combinedList.AddRange(secondList);
        Console.WriteLine(string.Join(",", combinedList));
    }
}