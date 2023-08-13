namespace Exercise14
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(WeekdayInDutch(1970, 9, 21));
            Console.WriteLine(WeekdayInDutch(1945, 9, 2));
            Console.WriteLine(WeekdayInDutch(2001, 9, 11));
        }

        public static string WeekdayInDutch(int year, int month, int day)
        {
            DateTime date = new DateTime(year, month, day);
            var dutch = new System.Globalization.CultureInfo("nl-NL");
            string dutchDay = dutch.DateTimeFormat.GetDayName(date.DayOfWeek);
            return dutchDay;
        }
    }
}