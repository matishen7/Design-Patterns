using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Design_Patterns.Factories.FactoryCodingExercise;

namespace Design_Patterns.Prototypes
{
    internal class CopyConstructorDemo
    {
        class Person
        {
            public string[] Names { get; set; }
            public Address Address { get; set; }

            public Person()
            {

            }

            public Person(Person other)
            {
                this.Names = other.Names;
                this.Address = other.Address;
            }
        }

        public class Address
        {
            public string[] StreetName { get; set; }
            public int Number;

            public Address()
            {

            }

            public Address(Address other)
            {
                this.Number = other.Number;
                this.StreetName = other.StreetName;
            }
        }


        static void Main(string[] args)
        {
            var john = new Person() { Names = new string[] { "John", "Smith" }, Address = new Address() { StreetName = new string[] { "London street" }, Number = 123 } };
            var john = new Person() { Names = new string[] { "John", "Smith" }, Address = new Address() { StreetName = new string[] { "London street" }, Number = 123 } };

        }
    }
}
