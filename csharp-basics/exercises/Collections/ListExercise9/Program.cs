using System;
using System.Collections.Generic;

namespace ListExercise9
{
    class Program
    {
        static void Main(string[] args)
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
            //TODO: Write a C# program to join two lists.
            //...
        }
    }
}
