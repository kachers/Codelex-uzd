namespace Exercise6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ievadi skaitlus.");
            string input = Console.ReadLine();
            char[] number = input.ToCharArray();
            int sum = 0;

            for (int i = 0; i < number.Length; i++)
            {
                sum = sum + int.Parse(number[i].ToString());
            }
            Console.WriteLine(sum);
            Console.ReadKey();
        }
    }
}