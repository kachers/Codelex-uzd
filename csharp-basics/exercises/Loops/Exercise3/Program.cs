namespace Exercise3;

internal class Program
{
    private static void Main(string[] args)
    {
        int userChoice;
        var randomNumbers = new List<int>();
        var random = new Random();
        for (var i = 0; i < 20; i++)
        {
            randomNumbers.Add(random.Next(1, 1000));
            Console.WriteLine($"{randomNumbers[i]} with index - {i}");
        }

        while (true)
        {
            Console.WriteLine("Enter the position of the number you want to know: ");
            var input = Console.ReadLine();
            if (int.TryParse(input, out userChoice))
            {
                if (userChoice >= 1 && userChoice <= randomNumbers.Count)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid position.");
                }
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
            }
        }

        Console.WriteLine(
            $"You chose position Nr {userChoice}\n In this position is located number: {randomNumbers[userChoice - 1]}");
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}