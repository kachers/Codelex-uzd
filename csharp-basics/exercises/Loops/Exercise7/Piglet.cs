namespace Exercise7;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Welcome to Piglet!");
        var random = new Random();
        var points = 0;
        char userChoice;

        do
        {
            var roll = random.Next(1, 7);
            if (roll == 1)
            {
                points = 0;
                Console.WriteLine("\nYou rolled a 1!");
                break;
            }

            Console.WriteLine($"\nYou rolled a {roll}!");
            points += roll;

            while (true)
            {
                Console.WriteLine("\nRoll again? y/n ");
                userChoice = char.ToLower(Console.ReadKey().KeyChar);

                if (userChoice == 'y' || userChoice == 'n') break;
                Console.WriteLine("\nInvalid choice. Please enter y or n.");
            }

        } while (userChoice == 'y');

        Console.WriteLine($"\nYou got {points} points.");
        Console.WriteLine("Game Over");
    }
}