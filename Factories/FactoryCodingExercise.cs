using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Design_Patterns.Factories.FactoryCodingExercise;

namespace Design_Patterns.Factories
{
    internal class FactoryCodingExercise
    {
        public class Person : IPerson
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public static PersonFactory Factory = new PersonFactory();

            private Person(int id, string name)
            {
                Id = id;
                Name = name;
            }

            public class PersonFactory
            {
                private int Id { get; set; } = 0;

                public PersonFactory() { }

                public Person CreatePerson(string y)
                {
                    return new Person(Id++, y);
                }
            }
        }

        

        //static void Main(string[] args)
        //{
        //    var john = Person.Factory.CreatePerson("John");
        //    var alex = Person.Factory.CreatePerson("Alex");
        //    Console.WriteLine(john.Id);
        //    Console.WriteLine(alex.Id);

        //}
    }

    public interface IPerson
    {
    }
}
