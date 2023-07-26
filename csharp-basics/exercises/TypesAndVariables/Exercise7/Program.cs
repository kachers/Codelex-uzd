namespace Exercise7
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ievadi tekstu");
            string input = Console.ReadLine();
            int result = 0;

            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsUpper(input[i]))
                {
                    result++;
                }            
            }
            Console.WriteLine($"{result}");
            Console.ReadKey();
        }

    }
}