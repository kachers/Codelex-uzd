using System;

namespace GetTheCentury
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(GetTheCentury());
        }

        private static string GetTheCentury()
        {
            Console.WriteLine("Enter year");
            int userYear;
            var century = "";

            while (!int.TryParse(Console.ReadLine(), out userYear) || userYear > 2010 || userYear < 1000)
                Console.WriteLine("\nInvalid input. Please provide any year between 1000 and 2010.");
            if (userYear <= 1000 && userYear > 900) century = "10th";
            if (userYear <= 1100 && userYear > 1000) century = "11th";
            if (userYear <= 1200 && userYear > 1100) century = "12th";
            if (userYear <= 1300 && userYear > 1200) century = "13th";
            if (userYear <= 1400 && userYear > 1300) century = "14th";
            if (userYear <= 1500 && userYear > 1400) century = "15th";
            if (userYear <= 1600 && userYear > 1500) century = "16th";
            if (userYear <= 1700 && userYear > 1600) century = "17th";
            if (userYear <= 1800 && userYear > 1700) century = "18th";
            if (userYear <= 1900 && userYear > 1800) century = "19th";
            if (userYear <= 2000 && userYear > 1900) century = "20th";
            if (userYear > 2000) century = "21th";
            var result = string.Concat(century, " century");
            return result;
        }
    }
}