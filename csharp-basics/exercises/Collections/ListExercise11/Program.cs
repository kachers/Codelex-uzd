using System;
using System.Collections.Generic;

namespace ListExercise11;

internal class Program
{
    private static void Main(string[] args)
    {
        List<string> myList = new();
        string[] elements =
        {
            "apple", "banana", "orange", "grape", "kiwi",
            "melon", "strawberry", "blueberry", "pineapple", "cherry"
        };

        myList.AddRange(elements);
        myList.Insert(4, "cherry");
        var last = myList.Count - 1;
        myList[last] = "last";
        myList.Sort();
        myList.Contains("Foobar");
        for (var i = 0; i < myList.Count; i++) Console.WriteLine(myList[i]);
    }
}