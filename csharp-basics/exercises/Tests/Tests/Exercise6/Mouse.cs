namespace Exercise6;

public class Mouse : Mammal
{
    public Mouse(string animalType, string animalName, double animalWeight, string livingRegion) : base(
        animalType, animalName, animalWeight, livingRegion)
    {
    }

    public override string MakeSound()
    {
        return $"Im am a mouse!";
    }

    public override void EatFood(Food food)
    {
        if (food is not Vegetable vegetable) throw new WrongFoodException();

        FoodEaten += food.Quantity;
        Console.WriteLine($"{vegetable.GetType().Name} {food.Quantity}");
    }
    public override string ToString()
    {
        return $"{AnimalType}[{AnimalName}, {Math.Round(AnimalWeight, 2)}, {LivingRegion}, {FoodEaten}";
    }
}