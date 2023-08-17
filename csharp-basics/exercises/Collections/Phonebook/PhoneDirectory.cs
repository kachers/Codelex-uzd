using System;
using System.Collections.Generic;

namespace PhoneBook;

public class PhoneDirectory
{
    private readonly SortedDictionary<string, string> _data;

    public PhoneDirectory()
    {
        _data = new SortedDictionary<string, string>();
    }

    private bool Find(string name)
    {
        return _data.ContainsKey(name);
    }

    public string GetNumber(string name)
    {
        return Find(name) ? _data[name] : "Doesn't exist.";
    }

    public void PutNumber(string name, string number)
    {
        if (name == null || number == null) throw new Exception("name and number cannot be null");

        if (Find(name)) _data[name] = number;
        else _data.Add(name, number);
    }
}