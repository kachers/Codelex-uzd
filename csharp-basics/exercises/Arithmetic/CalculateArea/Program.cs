using System;

namespace CalculateArea;

internal class Program
{
    private static void Main(string[] args)
    {
        var userChoice = 0;
        while (userChoice != 4)
        {
            userChoice = GetMenu();
            switch (userChoice)
            {
                case 1:
                    CalculateCircleArea();
                    break;
                case 2:
                    CalculateRectangleArea();
                    break;
                case 3:
                    CalculateTriangleArea();
                    break;
            }
        }
    }

    public static int GetMenu()
    {
        Console.WriteLine("Geometry Calculator\n");
        Console.WriteLine("1. Calculate the Area of a Circle");
        Console.WriteLine("2. Calculate the Area of a Rectangle");
        Console.WriteLine("3. Calculate the Area of a Triangle");
        Console.WriteLine("4. Quit\n");
        Console.WriteLine("Enter your choice (1-4) : ");
        var keyboard = Console.ReadKey();
        var userChoice = 0;


        if (!char.IsDigit(keyboard.KeyChar) || keyboard.KeyChar <= 4)
        {
            Console.WriteLine("\nInvalid input. Please enter a valid integer.");
            GetMenu();
        }
        else
        {
            userChoice = int.Parse(keyboard.KeyChar.ToString());
        }

        return userChoice;
    }

    public static void CalculateCircleArea()
    {
        decimal radius;
        while (true)
        {
            Console.WriteLine("\nWhat is the circle's radius? ");
            var input = Console.ReadLine();

            if (decimal.TryParse(input, out radius))
                break;
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }

        Console.WriteLine("The circle's area is "
                          + Geometry.AreaOfCircle(radius));
    }

    public static void CalculateRectangleArea()
    {
        decimal length, width;
        while (true)
        {
            Console.WriteLine("Enter length: ");
            var lengthInput = Console.ReadLine();

            if (decimal.TryParse(lengthInput, out length))
                break;
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }

        while (true)
        {
            Console.WriteLine("Enter width: ");
            var widthInput = Console.ReadLine();

            if (decimal.TryParse(widthInput, out width))
                break;
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }

        Console.WriteLine("The rectangle's area is "
                          + Geometry.AreaOfRectangle(length, width));
    }

    public static void CalculateTriangleArea()
    {
        decimal ground, height;
        while (true)
        {
            Console.WriteLine("Enter length of the triangle's base? ");
            var groundInput = Console.ReadLine();

            if (decimal.TryParse(groundInput, out ground))
                break;
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }

        while (true)
        {
            Console.WriteLine("Enter triangle's height? ");
            var heightInput = Console.ReadLine();

            if (decimal.TryParse(heightInput, out height))
                break;
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }

        Console.WriteLine("The triangle's area is "
                          + Geometry.AreaOfTriangle(ground, height));
    }
}