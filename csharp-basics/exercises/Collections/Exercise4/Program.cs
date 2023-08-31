namespace Exercise4;

internal class Program
{
    private static void Main(string[] args)
    {
        HashSet<string> names = new();

        while (true)
        {
            Console.WriteLine("Enter name:");
            var userInput = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(userInput)) break;

            names.Add(userInput);
        }

        Console.WriteLine("Unique name list contains:" + string.Join(" ", names));
    }
}