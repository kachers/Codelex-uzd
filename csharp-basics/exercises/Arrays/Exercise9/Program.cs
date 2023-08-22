namespace Exercise9;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine(CapeMe(new[] { "samuel", "MABELLE", "letitia", "meridith" }));
    }

    private static string[] CapeMe(string[] inputArr)
    {
        for (var i = 0; i < inputArr.Length; i++)
        {
            var chars = inputArr[i].ToLower().ToCharArray();
            chars[0] = char.ToUpper(chars[0]);
            inputArr[i] = string.Join("", chars);
        }

        Console.WriteLine(string.Join(",", inputArr));
        return inputArr;
    }
}