using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static Design_Patterns.Factories.FactoryCodingExercise;

namespace Design_Patterns.Prototypes
{
    internal class CopyConstructorDemo
    {
        interface IPrototype<T>
        {
            public T DeepCopy();
        }

        class Person : IPrototype<Person>
        {
            public string Names { get; set; }
            public Address Address { get; set; }

            public Person()
            {

            }

            public Person(string names, Address address)
            {
                Names = names;
                Address = address;
            }

            public Person(Person other)
            {
                Names = other.Names;
                Address = new Address(other.Address);
            }

            public override string ToString()
            {
                return $"{nameof(Names)}: {Names}, {nameof(Address)}: {Address}";
            }

            public Person DeepCopy()
            {
                return new Person(Names, Address.DeepCopy());
            }
        }

        class Address : IPrototype<Address>
        {
            public Address DeepCopy()
            {
                return new Address(StreetName, Number);
            }
        
            public string StreetName { get; set; }
            public int Number;

            public Address()
            {
                    
            }

            public Address(string streetName,int number)
            {
                StreetName = streetName;
                Number = number;
            }

            public Address(Address other)
            {
                Number = other.Number;
                StreetName = other.StreetName;
            }

            public override string ToString()
            {
                return $"{nameof(StreetName)}: {StreetName}, {nameof(Number)}: {Number}";
            }
        }


        //static void Main(string[] args)
        //{
        //    var john = new Person() { Names = "John" , Address = new Address() { StreetName = "London street" , Number = 123 } };
        //    var jane = new Person(john);
        //    jane.Address.Number = 321;
        //    Console.WriteLine(john.ToString());
        //    Console.WriteLine(jane.ToString());
        //}
    }
}
