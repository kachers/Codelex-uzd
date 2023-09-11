namespace Exercise6;

internal class Zebra : Mammal
{
    public Zebra(string animalType, string animalName, double animalWeight, string livingRegion) : base(
        animalType, animalName, animalWeight, livingRegion)
    {
    }

    public override void MakeSound()
    {
        Console.WriteLine("Im am a Zebra!");
    }

    public override void EatFood(Food food)
    {
        if (food is Vegetable vegetable)
        {
            FoodEaten += food.Quantity;
            Console.WriteLine($"{vegetable.GetType().Name} {food.Quantity}");
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