namespace Exercise5;

class Program
{
    static void Main(string[] args)
    {
        int[] numbers = new int[] { 1, 2, 3, 4, 5, 6, 7};
        string[] subjects = new string[] {
            "Math", "English", "History", 
            "Sports", "Music", "Biology","Information Tehnology - Begginers"
        };
        string[] teachers = new string[] {
            "Uldis Berzins", "Martins Vanags", "Eižens Eglītis", 
            "Ingrīda Liepa", "Karina Eglītis", "Dace Balodis", "Egils Milzits" 
        };      


        Console.WriteLine("+------------------------------------------------------------+");
        for (int i = 0; i < numbers.Length; i++)
        {        
            Console.WriteLine($"| {numbers[i],-2} | {subjects[i],35} | {teachers[i],-15} |");
        }
        Console.WriteLine("+------------------------------------------------------------+");
        Console.ReadKey();
    }
}
