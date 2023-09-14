namespace Exercise3;

internal class Employee : Person
{
    public Employee(string firstName, string lastName, string address, int id, string jobTitle) : base(firstName,
        lastName, address, id)
    {
        JobTitle = jobTitle;
    }

    public string JobTitle { get; }

    public override void Display(Person employee1)
    {
        if (employee1 is Employee employee)
        {
            Console.WriteLine($"First name: {employee.FirstName}\nLast name: {employee.LastName}\nAddress: {employee.Address}\nID: {employee.Id}\nJobTitle: {employee.JobTitle}");
        }
        else
        {
            Console.WriteLine("Person is not an employee");
        }
    }
}