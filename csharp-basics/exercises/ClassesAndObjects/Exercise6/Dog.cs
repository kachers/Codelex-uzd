namespace Exercise6;

internal class Dog
{
    public Dog Father;
    public Dog Mother;
    private string _name;
    private string _sex;

    public Dog(string name, string sex)
    {
        _name = name;
        _sex = sex;
    }

    public string FathersName()
    {
        return Father == null ? "Unknown" : Father._name;
    }

    public bool HasSameMotherAs(Dog otherDog)
    {
        return Mother == otherDog.Mother;
    }
}