namespace Exercise6;

internal class Cat : Mammal
{
    public string Breed;

    public Cat(string animalType, string animalName, double animalWeight, string livingRegion,
        string breed) :
        base(animalType, animalName, animalWeight, livingRegion)
    {
        Breed = breed;
    }

    public override void MakeSound()
    {
        Console.WriteLine("Meowwww");
    }

    public override void EatFood(Food food)
    {
        FoodEaten += food.Quantity;
        Console.WriteLine($"{food.GetType().Name} {food.Quantity}");
    }

    public override string ToString()
    {
        return $"{AnimalType}[{AnimalName},{Breed}, {Math.Round(AnimalWeight, 2)}, {LivingRegion}, {FoodEaten}]";
    }
}