namespace Exercise6;

internal class Dog
{
    public Dog father;
    public Dog mother;
    public string name;
    public string sex;

    public Dog(string name, string sex)
    {
        this.name = name;
        this.sex = sex;
    }

    public string FathersName()
    {
        return father == null ? "Unknown" : father.name;
    }

    public bool HasSameMotherAs(Dog otherDog)
    {
        return mother == otherDog.mother ? true : false;
    }
}