namespace Exercise6
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            int[] tenInt = new int[10];
            int[] tenIntCopy = new int[10];
            for (int i=0; i<tenInt.Length; i++) { 
                Random random = new();
                tenInt[i] = random.Next(1,100);
            }

            for (int i = 0; i < tenInt.Length; i++)
            {
                tenIntCopy[i] = tenInt[i];
            }

            tenInt[tenInt.Length-1] = -7;
            Console.WriteLine(string.Join(" ", tenInt));
            Console.WriteLine(string.Join(" ", tenIntCopy));
        }
    }
}