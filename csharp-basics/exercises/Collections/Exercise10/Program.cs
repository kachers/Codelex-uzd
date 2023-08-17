namespace Exercise10;

internal class Program
{
    private static void Main(string[] args)
    {
        var stringSet = new HashSet<string>();

        stringSet.Add("apple");
        stringSet.Add("banana");
        stringSet.Add("cherry");
        stringSet.Add("peach");
        stringSet.Add("grape");

        Console.WriteLine("Items in the HashSet:");
        Console.WriteLine(string.Join("\n", stringSet));

        stringSet.Clear();

        Console.WriteLine("\nCheck if it is possible to add duplicated values");
        Console.WriteLine($"Apple added to HashSet - {stringSet.Add("apple")}");
        Console.WriteLine($"Banana added to HashSet - {stringSet.Add("banana")}");
        Console.WriteLine($"Cherry added to HashSet - {stringSet.Add("cherry")}");
        Console.WriteLine($"Banana added to HashSet - {stringSet.Add("banana")}");
        Console.WriteLine($"Grape added to HashSet - {stringSet.Add("grape")}");

        Console.WriteLine("\nAfter clearing and adding again:");
        Console.WriteLine(string.Join("\n", stringSet));
    }
}