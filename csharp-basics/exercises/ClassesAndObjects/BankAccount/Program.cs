using System;

namespace BankAccount
{
    class Program
    {
        static void Main(string[] args)
        {
            Account tim = new Account("Tim", 300.145);
            Console.WriteLine(Account.ShowUserNameAndBalance(tim));
        }
    }
}
