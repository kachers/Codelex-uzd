namespace Exercise6;

public abstract class Animal
{
    public string AnimalName;
    public string AnimalType;
    public double AnimalWeight;
    public int FoodEaten;

    public Animal(string animalType, string animalName, double animalWeight)
    {
        AnimalName = animalName;
        AnimalType = animalType;
        AnimalWeight = animalWeight;
        FoodEaten = 0;
    }

    public abstract string MakeSound();

    public abstract void EatFood(Food food);
}