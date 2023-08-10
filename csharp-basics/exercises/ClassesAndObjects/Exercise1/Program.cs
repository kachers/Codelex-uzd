namespace Exercise1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product mouse = new Product("Logitech mouse", 70.00, 14);
            Product phone = new Product("Iphone 5s", 999.99, 3);
            Product printer = new Product("Epson EB-U05", 440.46, 1);

            mouse.PrintProduct();
            phone.PrintProduct();
            printer.PrintProduct();

            printer.ChangePrice(420.20);
            printer.ChangeAmount(2);
            Console.WriteLine("\nProduct - printer after changes");
            printer.PrintProduct();
        }
    }
}