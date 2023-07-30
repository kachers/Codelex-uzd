using System;

namespace VariablesAndNames
{
    class Program
    {
        private static void Main(string[] args)
        {
            int cars = 100;              
            int drivers = 28; 
            int passengers = 90;
            int carsNotDriven; 
            int carsDriven;        
            
            double seatsInCar = 4.0;         
            double carpoolCapacity = carsDriven * seatsInCar;
            double averagePassengersPerCar = Math.Round((double)passengers / carsDriven, 2);

            carsNotDriven = cars - drivers;
            carsDriven = drivers;


            Console.WriteLine("There are " + cars + " cars available.");
            Console.WriteLine("There are only " + drivers + " drivers available.");
            Console.WriteLine("There will be " + carsNotDriven + " empty cars today.");
            Console.WriteLine("We can transport " + carpoolCapacity + " people today.");
            Console.WriteLine("We have " + passengers + " to carpool today.");
            Console.WriteLine("We need to put about " + averagePassengersPerCar + " in each car.");
            Console.ReadKey();
        }
    }
}