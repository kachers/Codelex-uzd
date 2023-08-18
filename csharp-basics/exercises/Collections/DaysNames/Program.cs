using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DaysNames
{ class Program
    { private static void Main(string[] args)
        {
            Console.WriteLine("Enter year ");
            int year = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter month ");
            int month = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter day");
            int day = int.Parse(Console.ReadLine());

            DateTime dt = new DateTime(year, month, day);
            var LV = new System.Globalization.CultureInfo("lv-LV");
            string diena = LV.DateTimeFormat.GetDayName(dt.DayOfWeek);
            Console.WriteLine($"The day of the {day}/{month}/{year} was: {diena}");
        }
    }
}



