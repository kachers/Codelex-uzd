namespace Exercise4;

internal class Program
{
    private static void Main(string[] args)
    {
        List<string> names = new();
        var userInput = string.Empty;

        while (true)
        {
            Console.WriteLine("Enter name:");
            userInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userInput)) break;

            names.Add(userInput);
        }

        List<string> filteredNames = new();
        foreach (var name in names.Where(name => !filteredNames.Contains(name))) filteredNames.Add(name);

        Console.WriteLine("Unique name list contains:" + string.Join(" ", filteredNames));
    }
}