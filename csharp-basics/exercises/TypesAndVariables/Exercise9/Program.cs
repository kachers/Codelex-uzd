﻿using System.Diagnostics.Metrics;
using System.Numerics;

namespace Exercise9
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Please provide distance in meters");
            int distance = int.Parse(Console.ReadLine());
            Console.WriteLine("Please provide hours");
            int hours = int.Parse(Console.ReadLine());           
            Console.WriteLine("Please provide minutes");
            int minutes = int.Parse(Console.ReadLine());
            Console.WriteLine("Please provide seconds");
            int seconds = int.Parse(Console.ReadLine());
            Console.WriteLine($"{hours}/3600 + {minutes}60 + {seconds}");          
            int totalSeconds = hours*3600 + minutes*60 + seconds;
            decimal speedMs = (decimal)distance / totalSeconds;
            decimal speedKmh = speedMs * 3600 / 1000;
            decimal speedMph = speedKmh * (decimal)0.621371192;




            Console.WriteLine($"Your speed in meters/second is{speedMs}");
            Console.WriteLine($"Your speed in km/h is {speedKmh}");
            Console.WriteLine($"Your speed in miles/h is {speedMph}");
            Console.ReadKey();
        }
    }
}