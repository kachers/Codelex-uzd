using System;

namespace Exercise8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ievadi minutes");
            var minutes = int.Parse(Console.ReadLine());

            var minutesInYear = 365 * 24 * 60;
            var miutesInDay = 24 * 60;

            var years = minutes / minutesInYear;
            var minutesToDays = minutes % minutesInYear;
            var days = minutesToDays / miutesInDay;
            
            Console.WriteLine($"it's {years} years and {days} days");

            Console.ReadKey();
        }
    }
}
