using System;

namespace BankAccount;

public class Account
{
    public Account(string name, double balance)
    {
        Name = name;
        Balance = balance;
    }

    protected string Name { get; }
    protected double Balance { get; }

    public static string ShowUserNameAndBalance(Account benben)
    {
        var name = benben.Name;
        var balance = benben.Balance;
        return balance < 0 ? $"{name}, -{Math.Abs(balance):C2}" : $"{name}, {balance:C2}";
    }
}