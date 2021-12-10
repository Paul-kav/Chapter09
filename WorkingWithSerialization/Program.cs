using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;//XmlSerializer
//using Packt.Shared; //person
using static System.Console;
using static System.Environment;
using static System.IO.Path;

namespace WorkingWithSerialization
{
    class Program
    {
        static void Main(string[] args)
        {
            //create an object graph of person instances
            List<Person> people = new()
            {
                new(30000M)
                {
                    FirstName = "Alice",
                    LastName = "Smith",
                    DateOfBirth = new(1974, 3, 14)
                },
                new(40000M)
                {
                    FirstName = "Bob",
                    LastName = "Jones",
                    DateOfBirth = new(1969, 11, 23)
                },
                new(20000M)
                {
                    FirstName = "Charlie",
                    LastName = "Cox",
                    DateOfBirth = new(1984, 5, 4),
                    Children = new()
                    {
                        new(0M)
                        {
                            FirstName = "Sally",
                            LastName = "Cox",
                            DateOfBirth = new(2000, 7, 12)
                        }
                    }
                }
            };

            //create object that will format a list of person as xml
            XmlSerializer xs = new(people.GetType());

            //create a file to write to
            string path = Combine(CurrentDirectory, "people.xml");

            using (FileStream stream = File.Create(path))
            {
                //serialize the object graph to the stream
                xs.Serialize(stream, people);
            }

            WriteLine("Written {0:NO} bytes of XML to {1}",
                arg0: new FileInfo(path).Length,
                arg1: path);
            WriteLine();

            //display the serialized object graph
            WriteLine(File.ReadAllText(path));
            
        }
    }

}
