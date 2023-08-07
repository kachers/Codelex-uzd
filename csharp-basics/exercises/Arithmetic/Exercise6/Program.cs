namespace Exercise6;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(CozaLozaWoza(1, 111));
    }

    public static string CozaLozaWoza(int a, int b)
    {
        var result = "";
        var counter = 0;
        for (var i = a; i <= b; i++)
        {
            if (i % 3 == 0 && i % 5 == 0 && i % 7 == 0) result += "CozaLozaWoza";
            else if (i % 3 == 0 && i % 5 == 0) result += "Cozaloza";
            else if (i % 7 == 0) result += "Woza";
            else if (i % 5 == 0) result += "Loza";
            else if (i % 3 == 0) result += "Coza";
            else result += i.ToString();
            result += " ";
            counter++;

            if (counter == 11)
            {
                result += "\n";
                counter = 0;
            }
        }

        return result;
    }
}