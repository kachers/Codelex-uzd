using System;

namespace FuelConsumptionCalculator;

internal class Program
{
    private static void Main(string[] args)
    {
        TestCar1();
        TestCar2();
        TestFillingUp();
    }

    private static void TestCar1()
    {
        var startOdo = ReadDoubleInput("Please enter starting odometer reading:");
        var endingOdo = ReadDoubleInput("Please enter ending odometer reading:");
        var liters = ReadDoubleInput("Please enter liters spent:");
        var car1 = new Car(startOdo, endingOdo, liters);
        Console.WriteLine($"On average car1 used {car1.CalculateConsumption()} liters of fuel per 100km.");
        Console.WriteLine(car1.IsGasHog() ? "Car1 is a Gas Hog!" : "Car1 is not a Gas Hog!");
        Console.WriteLine(car1.IsEconomyCar() ? "Car1 is an Economy car!" : "Car1 is not an Economy car!");
    }

    private static void TestCar2()
    {
        var startOdo2 = ReadDoubleInput("Please enter starting odometer reading for car2:");
        var endingOdo2 = ReadDoubleInput("Please enter ending odometer reading for car2:");
        var liters2 = ReadDoubleInput("Please enter liters spent:");
        var car2 = new Car(startOdo2, endingOdo2, liters2);
        Console.WriteLine($"On average car2 used {car2.CalculateConsumption()} liters of fuel per 100km.\n");
        Console.WriteLine(car2.IsGasHog() ? "Car2 is a Gas Hog!" : "Car2 is not a Gas Hog!");
        Console.WriteLine(car2.IsEconomyCar() ? "Car2 is an Economy car!" : "Car2 is not an Economy car!");
    }

    private static void TestFillingUp()
    {
        var startOdo3 = ReadDoubleInput("Please enter starting odometer reading for car3:");
        var car3 = new Car(startOdo3);

        for (var i = 1; i < 4; i++)
        {
            Console.WriteLine("\nFilling up Car 3:");
            var mileage3 = (int)ReadDoubleInput("Enter current odometer reading for car3: ");
            var litersFilled3 = ReadDoubleInput("Enter liters filled: ");
            car3.FillUp(mileage3, litersFilled3);
            Console.WriteLine($"\nCar 3 consumption after {i} fill-ups: " + car3.CalculateConsumption() +
                              " liters per 100 km");
            if (i == 3) Console.WriteLine("That's all, no more filling up!");
        }

        Console.WriteLine("Press any key to exit.");
        Console.ReadKey();
    }

    private static double ReadDoubleInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out var value)) return value;
            Console.WriteLine("Invalid input. Please enter a valid number.");
        }
    }
}
