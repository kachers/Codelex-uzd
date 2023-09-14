namespace Exercise3;

internal class Program
{
    private static void Main(string[] args)
    {
        var student1 = new Student("Renars", "Kacerovskis", "Zeltritu iela 16-54,Marupe, Lv-2167", 123, 9.9);
        var employee1 = new Employee("Renars", "Kacerovskis", "Zeltritu iela 16-54,Marupe, Lv-2167", 123, "Manager");

        student1.Display(student1);
        employee1.Display(employee1);
    }
}