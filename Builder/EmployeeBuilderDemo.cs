using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Design_Patterns.Builder.FunctionalBuilderProgram;

namespace Design_Patterns.Builder
{
    internal class EmployeeBuilderDemo
    {
        class Employee
        {
            private string firstName = string.Empty;
            private string lastName = string.Empty;
            private int age = 0;
            private string department = string.Empty;

            public string FirstName { get => firstName; set => firstName = value; }
            public string LastName { get => lastName; set => lastName = value; }
            public int Age { get => age; set => age = value; }
            public string Department { get => department; set => department = value; }

            public void Display()
            {
                Console.WriteLine($"First name : {firstName}\n" +
                    $"Last name : {lastName}\n" +
                    $"Age : {age} \n" +
                    $"Department : {department} \n"
                    );
            }

        }

        class EmployeeBuilder : GenericFunctionalBuilder<Employee, EmployeeBuilder>
        {
            public EmployeeBuilder FirstName(string firstName)
            {
                return Do(e => e.FirstName = firstName);
            }

            public EmployeeBuilder LastName(string lastName)
            {
                return Do(e => e.LastName = lastName);
            }

            public EmployeeBuilder Age(int age)
            {
                return Do(e => e.Age = age);
            }

            public EmployeeBuilder Department(string department)
            {
                return Do(e => e.Department = department);
            }
        }

        public static void Main(string[] args)
        {
            var employee = new EmployeeBuilder()
                                 .FirstName("John")
                                 .LastName("Smith")
                                 .Age(33)
                                 .Department("Engineering")
                                 .Build();
            employee.Display();
        }
    }
}
