namespace Exercise8;

internal class Program
{
    private static void Main(string[] args)
    {
        var userChoice = 0;
        while (userChoice != 1)
        {
            userChoice = GetMenu();
            switch (userChoice)
            {
                case 0:
                    Calculator();
                    break;
                default:
                    Console.WriteLine("\nBye Bye");
                    break;
            }
        }
    }

    private static int GetMenu()
    {
        Console.WriteLine("\nCalculator\n");
        Console.WriteLine("0. Calculate some numbers");
        Console.WriteLine("1. Quit\n");
        Console.WriteLine("Enter your choice (0-1) : ");
        int userChoice;
        while (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out userChoice) || userChoice < 0 || userChoice > 1)
            Console.WriteLine("\nInvalid input. Please choose a valid action (0 to 1):");
        return userChoice;
    }

    private static void Calculator()
    {
        Console.WriteLine("\nProvide first number");
        int firstNum;
        while (!int.TryParse(Console.ReadLine(), out firstNum))
            Console.WriteLine("Invalid input. Please enter a valid integer for the first number:");

        Console.WriteLine("Provide second number");
        int secondNum;
        while (!int.TryParse(Console.ReadLine(), out secondNum))
            Console.WriteLine("Invalid input. Please enter a valid integer for the second number:");

        Console.WriteLine(" Choose action:");
        Console.WriteLine(" 1 = Add(+)");
        Console.WriteLine(" 2 = Subtract(-)");
        Console.WriteLine(" 3 = Multiply(*)");
        Console.WriteLine(" 4 = Divide(/)");

        int userAction;
        while (!int.TryParse(Console.ReadKey().KeyChar.ToString(), out userAction) || userAction < 1 || userAction > 4)
            Console.WriteLine("\nInvalid input. Please choose a valid action (1 to 4):");

        var result = 0;
        switch (userAction)
        {
            case 1:
                result = firstNum + secondNum;
                break;
            case 2:
                result = firstNum - secondNum;
                break;
            case 3:
                result = firstNum * secondNum;
                break;
            case 4:
                result = firstNum / secondNum;
                break;
        }

        Console.WriteLine($"\nResult is {result}\n");
    }
}