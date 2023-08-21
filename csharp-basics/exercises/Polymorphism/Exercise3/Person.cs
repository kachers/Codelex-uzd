using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exercise3
{
    public class Person
    {
        public string FirstName { get; }
        public string LastName { get; }
        public string Address { get; }
        public int Id { get; }

        public Person()
        {
            FirstName = "";
            LastName = "";
            Address = "";
            Id = 0;
        }
        public Person(string firstName, string lastName, string address, int id)
        {
            FirstName = firstName;
            LastName = lastName;
            Address = address;
            Id = id;
        }

        public virtual void Display(Person person1)
        {

            Console.WriteLine($"First name: {person1.FirstName}\nLast name: {person1.LastName}\nAddress: {person1.Address}\nID: {person1.Id}");
        }
    }
}
