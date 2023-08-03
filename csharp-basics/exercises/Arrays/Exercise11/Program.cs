namespace Exercise11;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(FindNemo("Nemo is me"));
    }

    private static string FindNemo(string text)
    {
        var textArr = text.Split(" ");
        for (var i = 0; i < textArr.Length; i++)
            if (textArr[i].Equals("Nemo"))
                return $"I found Nemo at {i + 1}!";

        return "I can't find Nemo :(";
    }
}