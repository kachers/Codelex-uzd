namespace Exercise6;

internal class Tiger : Felime
{
    public Tiger(string animalType, string animalName, double animalWeight, string livingRegion) :
        base(animalType, animalName, animalWeight, livingRegion)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("ROAAR!!!");
    }

    public override void EatFood(Food food)
    {
        if (food is Meat meat)
        {
            FoodEaten += food.Quantity;
            Console.WriteLine($"{meat.GetType().Name} {food.Quantity}");
        }
        else
        {
            Console.WriteLine($"{AnimalType}s are not eating that type of food!");
        }
    }

    public override string ToString()
    {
        return $"{AnimalType}[{AnimalName}, {Math.Round(AnimalWeight, 2)}, {LivingRegion}, {FoodEaten}]";
    }
}