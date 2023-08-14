using System;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            Account Tim = new Account("Tim", 300.145);
            Console.WriteLine(ShowUserNameAndBalance(Tim));
        }

        static string ShowUserNameAndBalance(Account Benben)
        {
            var name = Benben.GetName();
            var balance = Benben.GetBalance();
            return balance < 0 ? $"{name}, -{Math.Abs(balance).ToString("C2")}" : $"{name}, {balance.ToString("C2")}";
        }
    }
}
