namespace Exercise11;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(ReverseCase("Happy Birthday"));
    }

    private static string ReverseCase(string str)
    {
        var result = string.Empty;
        var inputArray = str.ToCharArray();

        foreach (var c in inputArray)
        {
            if (char.IsLower(c)) result += c.ToString().ToUpper();
            else if (char.IsUpper(c)) result += c.ToString().ToLower();
            else result += c.ToString();
        }

        return result;
    }
}