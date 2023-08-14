using System;
using System.Collections.Generic;

namespace ListExercise7;

internal class Program
{
    private static void Main(string[] args)
    {
        var colors = new List<string>
        {
            "Red",
            "Green",
            "Orange",
            "White",
            "Black"
        };

        Console.WriteLine(colors.Contains("White"));
    }
}