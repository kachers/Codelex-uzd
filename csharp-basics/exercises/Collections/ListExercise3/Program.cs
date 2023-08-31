using System;
using System.Collections.Generic;

namespace ListExercise3;

internal class Program
{
    private static void Main(string[] args)
    {
        var colors = new List<string>();
        colors.Add("Red");
        colors.Add("Green");
        colors.Add("Orange");
        colors.Add("White");
        colors.Add("Black");
        Console.WriteLine(string.Join(",", colors));

        colors.Insert(0, "Blue");
        colors.Insert(2, "Yellow");
        Console.WriteLine(string.Join(",", colors));
    }
}