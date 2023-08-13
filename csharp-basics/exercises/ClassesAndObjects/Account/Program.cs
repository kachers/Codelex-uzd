using System;

namespace Account;

internal class Program
{
    private static void Main(string[] args)
    {
        var bartosAccount = new Account("Barto's account", 100.00);
        var bartosSwissAccount = new Account("Barto's account in Switzerland", 1000000.00);

        Console.WriteLine("Initial state");
        Console.WriteLine(bartosAccount);
        Console.WriteLine(bartosSwissAccount);

        bartosAccount.Withdrawal(20);
        Console.WriteLine("Barto's account balance is now: " + bartosAccount.Balance());
        bartosSwissAccount.Deposit(200);
        Console.WriteLine("Barto's Swiss account balance is now: " + bartosSwissAccount.Balance());

        Console.WriteLine("Final state");
        Console.WriteLine(bartosAccount);
        Console.WriteLine(bartosSwissAccount);

        MoneyTransfer();

        var A = new Account("A", 100);
        var B = new Account("B", 0);
        var C = new Account("C", 0);
        Transfer(A, B, 50);
        Transfer(B, C, 25);
        Console.WriteLine(A);
        Console.WriteLine(B);
        Console.WriteLine(C);
    }

    public static void MoneyTransfer()
    {
        var mattsAccount = new Account("Matt's  account", 1000.00);
        var myAccount = new Account("My account  account", 0);
        mattsAccount.Withdrawal(100);
        myAccount.Deposit(100);
        Console.WriteLine(mattsAccount);
        Console.WriteLine(myAccount);
    }

    public static void Transfer(Account from, Account to, double howMuch)
    {
        from.Withdrawal(howMuch);
        to.Deposit(howMuch);
    }
}