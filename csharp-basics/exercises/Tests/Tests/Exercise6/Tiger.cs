namespace Exercise6;

public class Tiger : Felime
{
    public Tiger(string animalType, string animalName, double animalWeight, string livingRegion) :
        base(animalType, animalName, animalWeight, livingRegion)
    {
    }

    public override string MakeSound()
    {
        return $"ROAAR!!!";
    }

    public override void EatFood(Food food)
    {
        if (food is not Meat meat) throw new WrongFoodException();

        FoodEaten += food.Quantity;
        Console.WriteLine($"{meat.GetType().Name} {food.Quantity}");
    }

    public override string ToString()
    {
        return $"{AnimalType}[{AnimalName}, {Math.Round(AnimalWeight, 2)}, {LivingRegion}, {FoodEaten}]";
    }
}