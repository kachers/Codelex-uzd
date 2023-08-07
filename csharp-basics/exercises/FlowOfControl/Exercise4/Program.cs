namespace Exercise4;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(PrintDayInWordWithSwitchCase());
        Console.WriteLine(PrintDayInWordWithIf());
    }

    private static string PrintDayInWordWithIf()
    {
        Console.WriteLine("Enter number representing a day");
        var number = int.Parse(Console.ReadLine());
        var day = "";

        if (number < 8 && number != 0)
        {
            if (number == 1) day = "Monday";
            if (number == 2) day = "Tuesday";
            if (number == 3) day = "Wednesday";
            if (number == 4) day = "Thursday";
            if (number == 5) day = "Friday";
            if (number == 6) day = "Saturday";
            if (number == 7) day = "Sunday";
        }
        else
        {
            return "Not a valid day";
        }

        return day;
    }

    private static string PrintDayInWordWithSwitchCase()
    {
        Console.WriteLine("Enter number representing a day");
        var number = int.Parse(Console.ReadLine());

        switch (number)
        {
            case 1:
                return "Monday";
                break;
            case 2:
                return "Tuesday";
                break;
            case 3:
                return "Wednesday";
                break;
            case 4:
                return "Thursday";
                break;
            case 5:
                return "Friday";
                break;
            case 6:
                return "Saturday";
                break;
            case 7:
                return "Sunday";
                break;
            default:
                return "Not a valid day";
                break;
        }
    }
}