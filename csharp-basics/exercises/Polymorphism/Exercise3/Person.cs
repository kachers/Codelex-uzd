namespace Exercise3;

public class Person
{
    public Person()
    {
        FirstName = string.Empty;
        LastName = string.Empty;
        Address = string.Empty;
        Id = 0;
    }

    public Person(string firstName, string lastName, string address, int id)
    {
        FirstName = firstName;
        LastName = lastName;
        Address = address;
        Id = id;
    }

    public string FirstName { get; }
    public string LastName { get; }
    public string Address { get; }
    public int Id { get; }

    public virtual void Display(Person person1)
    {
        Console.WriteLine($"First name: {person1.FirstName}\nLast name: {person1.LastName}\nAddress: {person1.Address}\nID: {person1.Id}");
    }
}