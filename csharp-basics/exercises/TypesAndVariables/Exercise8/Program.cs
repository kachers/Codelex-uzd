namespace Exercise8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ievadi minutes");
            int minutes = int.Parse(Console.ReadLine());
            int minutesInYear = 365 * 24 * 60;
            int miutesInDay = 24 * 60;

            int years = minutes / minutesInYear;
            int minutesToDays = minutes % minutesInYear;
            int days = minutesToDays / miutesInDay;

            Console.WriteLine($"it's {years} years and {days} days");

            Console.ReadKey();
        }
    }
}