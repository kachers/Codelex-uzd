namespace Exercise13;

internal class Program
{
    private static void Main(string[] args)
    {
        var s1 = new Smoothie(new List<string> { "Banana" });
        Console.WriteLine($"Ingredients: {string.Join(", ", s1.Ingredients)}");
        Console.WriteLine($"Cost: {s1.GetCost():C2}");
        Console.WriteLine($"Price: {s1.GetPrice():C2}");
        Console.WriteLine($"Name: {s1.GetName()}");

        var s2 = new Smoothie(new List<string> { "Raspberries", "Strawberries", "Blueberries" });
        Console.WriteLine($"Ingredients: {string.Join(", ", s2.Ingredients)}");
        Console.WriteLine($"Cost: {s2.GetCost():C2}");
        Console.WriteLine($"Price: {s2.GetPrice():C2}");
        Console.WriteLine($"Name: {s2.GetName()}");
    }
}