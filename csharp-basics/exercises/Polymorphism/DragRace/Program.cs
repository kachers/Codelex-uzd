using System;
using System.Collections.Generic;
using System.Linq;

namespace DragRace;

internal class Program
{
    private static void Main(string[] args)
    {
        var lexus = new Lexus();
        var bmw = new Bmw();
        var tesla = new Tesla();
        var audi = new Audi();
        var mercedes = new Mercedes();
        var opel = new Opel();

        var cars = new List<Car>
        {
            lexus,
            bmw,
            tesla,
            audi,
            opel,
            mercedes
        };

        for (var i = 1; i < 11; i++)
            foreach (var car in cars)
            {
                if (i == 1) car.StartEngine();

                if (i % 3 == 0 && car is IBoostable boostableCar)
                {
                    Console.WriteLine($"It's lap {i} {car.GetType().Name} is using Boost!");
                    boostableCar.UseNitrousOxideEngine();
                }

                car.SpeedUp();
            }

        var winner = cars.First();
        foreach (var car in cars)
            if (int.Parse(car.ShowCurrentSpeed()) > int.Parse(winner.ShowCurrentSpeed()))
                winner = car;

        Console.WriteLine("Race finished, winner is:");
        Console.WriteLine($"{winner.GetType().Name} {winner.ShowCurrentSpeed()}");
    }
}