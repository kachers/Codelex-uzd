using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks.Dataflow;

namespace FlightPlanner
{
    class Program
    {
        private const string Path = "C:/Users/john/source/repos/Codelex-uzd/csharp-basics/exercises/Collections/FlightPlanner/flights.txt";

        private static void Main(string[] args)
        {
            List<string> userRoute = new();
            
            while (true)
            {
                var userChoice = GetMenu();
                switch (userChoice)
                {
                    case "q":
                        return;
                    case "1":
                        var cityList = FormatCityList(Path);
                        Console.WriteLine("\nChoose origin city - enter respective number:");
                        var origin = ChooseCity(cityList);
                        
                        Console.WriteLine($"\nYour origin will be - {origin}");
                        userRoute.Add(origin);
                        
                        var destination = string.Empty;
                        do
                        {
                            var destinationList = string.IsNullOrEmpty(destination) ? FligthDestinations(origin) : FligthDestinations(destination);

                            Console.WriteLine("\nChoose your destination - enter respective number:");
                            destination = ChooseCity(destinationList);
                            Console.WriteLine($"\nYour next destination will be - {destination}");
                            userRoute.Add(destination);

                        } while (destination != origin);

                        Console.WriteLine($"Your route will be : {string.Join(" -> ", userRoute)}");
                        break;
                }
            }
        }

        public static List<string> FligthDestinations(string origin)
        {
            var readText = File.ReadAllLines(Path);
            List<string> posibleDestinations = new List<string>();

            foreach (string line in readText)
            {
                string[] cityArr = line.Split("->");
                if (cityArr[0].Contains(origin))
                {
                    posibleDestinations.Add(cityArr[1].Trim());
                }
            }

            return posibleDestinations;
        }

        private static string ChooseCity(List<string> cityList)
        {
            Dictionary<int, string> cityPositionDict = new Dictionary<int, string>();
            
            for (var i = 0; i < cityList.Count; i++)
            {
                cityPositionDict[i + 1] = cityList[i];
                Console.WriteLine($"{i + 1}: {cityList[i]}");
            }

            while (true)
            {
                var keyboard = Console.ReadKey();
                if (!char.IsDigit(keyboard.KeyChar))
                {
                    Console.WriteLine("\nInvalid input. Please enter a valid integer.");
                }
                else
                {
                    var cityChoice = int.Parse(keyboard.KeyChar.ToString());
                    if (cityChoice < 1 || cityChoice > cityList.Count)
                    {
                        Console.WriteLine($"\nInvalid choice, please use number 1-{cityList.Count}.");
                    }
                    else
                    {
                        var retrievedCity = cityList[cityChoice-1];
                        return retrievedCity;
                    }
                }
            }
        }

        private static string GetMenu()
        {
            Console.WriteLine("\nWhat would you like to do: ");
            Console.WriteLine("To display list of the cities press 1");
            Console.WriteLine("To exit program press q");

            var keyboard = Console.ReadKey();
            while (keyboard.KeyChar != '1' && keyboard.KeyChar != 'q')
            {
                Console.WriteLine("\nInvalid choice, please enter 1 or q.");
                keyboard = Console.ReadKey();
            }

            return keyboard.KeyChar.ToString();
        }

        public static List<string> FormatCityList(string Path)
        {
            List<string> cities = new();
            List<string> filteredCities = new();
            var readText = File.ReadAllLines(Path);

            foreach (var s in readText)
            {
                string[] cityArr = s.Split("->");
                string[] cityArrTrimed = new string[cityArr.Length];
                for (var i = 0; i < cityArr.Length; i++) { cityArrTrimed[i] = cityArr[i].Trim(); }
                cities.AddRange(cityArrTrimed);
            }
            
            foreach (var city in cities.Where(name => !filteredCities.Contains(name))) filteredCities.Add(city);

            return filteredCities;
        }
    }
}
