using System;
using System.Collections.Generic;

namespace WorkingWithSerialization
{
    public class Person
    {
    public Person() { }//constructor must exist so the xml can call it to instantiate new person instances during the deserialization process

    public Person(decimal initialSalary)
        {
            Salary = initialSalary;
        }

        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public HashSet<Person>? Children { get; set; }
        protected decimal Salary { get; set; }
    }

}
