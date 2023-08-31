using System.Globalization;

namespace DaysNames;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Enter year ");
        var year = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter month ");
        var month = int.Parse(Console.ReadLine());
        Console.WriteLine("Enter day");
        var day = int.Parse(Console.ReadLine());

        var dt = new DateTime(year, month, day);
        var LV = new CultureInfo("lv-LV");
        var diena = LV.DateTimeFormat.GetDayName(dt.DayOfWeek);
        Console.WriteLine($"The day of the {day}/{month}/{year} was: {diena}");
    }
}