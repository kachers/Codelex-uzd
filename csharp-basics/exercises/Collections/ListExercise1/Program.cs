using System;
using System.Collections.Generic;

namespace ListExercise1;

internal class Program
{
    private static void Main(string[] args)
    {
        List<string> newList = new();
        newList.Add("add");
        string[] elements = { "add", "some", "elements" };
        newList.AddRange(elements);
        Console.WriteLine(string.Join(",", newList));
        string[] colors = { "red", "black", "green", "blue", "white" };
        newList.AddRange(colors);
    }
}