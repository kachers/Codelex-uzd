using System;
using PhoneBook;

namespace Phonebook;

internal class Program
{
    private static void Main(string[] args)
    {
        var directory = new PhoneDirectory();
        directory.PutNumber("TestName", "112");
        Console.WriteLine($"TestName number is - {directory.GetNumber("TestName")}");
        directory.PutNumber("TestName", "911119");
        Console.WriteLine($"TestName number after adding duplicate name is - {directory.GetNumber("TestName")}");
        Console.WriteLine($"TestName1234 number is - {directory.GetNumber("TestName1234")}");
    }
}