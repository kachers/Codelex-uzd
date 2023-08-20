using System;

namespace BankAccount;

public class Account
{
    public Account(string name, double balance)
    {
        _name = name;
        _balance = balance;
    }

    private readonly string _name;
    private readonly double _balance;

    public static string ShowUserNameAndBalance(Account benben)
    {
        var name = benben._name;
        var balance = benben._balance;
        return balance < 0 ? $"{name}, -{Math.Abs(balance):C2}" : $"{name}, {balance:C2}";
    }
}