namespace Exercise6;

public abstract class Mammal : Animal
{
    protected Mammal(string animalType, string animalName, double animalWeight, string livingRegion) : base(animalType,
        animalName, animalWeight)
    {
        LivingRegion = livingRegion;
    }

    public string LivingRegion;
}