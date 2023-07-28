using System.Security.Cryptography.X509Certificates;

namespace Exercise8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"Employee 1 {TotalPay(7.50,35)}");
            Console.WriteLine($"Employee 2 {TotalPay(8.20, 47)}");
            Console.WriteLine($"Employee 3 {TotalPay(10, 73)}");
        }

        public static double TotalPay(double basePay, int hours)
        {
            if(basePay <= 8.00||hours > 60)
            {
                Console.WriteLine("error >> base pay lower than $8.00 or number of hours is greater than 60.");
                return 0;
            }

            var regularPay = hours * basePay;
            var overTimePay = (hours - 40) * basePay * 1.5;
            var totalPay = regularPay+ overTimePay;
            return totalPay;
        }
    }
}