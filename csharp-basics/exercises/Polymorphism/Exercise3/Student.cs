namespace Exercise3;

public class Student : Person
{
    public Student(string firstName, string lastName, string address, int id, double gpa) : base(firstName, lastName,
        address, id)
    {
        Gpa = gpa;
    }

    public double Gpa { get; }

    public override void Display(Person student1)
    {
        if (student1 is Student student)
        {
            Console.WriteLine($"First name: {student.FirstName}\nLast name: {student.LastName}\nAddress: {student.Address}\nID: {student.Id}\nJobTitle: {student.Gpa}");
        }
        else
        {
            Console.WriteLine("Person is not a student");
        }
    }
}