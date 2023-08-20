namespace Exercise6;

internal class Dog
{
    public Dog Father;
    public Dog Mother;
    public string Name;
    public string Sex;

    public Dog(string name, string sex)
    {
        Name = name;
        Sex = sex;
    }

    public string FathersName()
    {
        return Father == null ? "Unknown" : Father.Name;
    }

    public bool HasSameMotherAs(Dog otherDog)
    {
        return Mother == otherDog.Mother;
    }
}