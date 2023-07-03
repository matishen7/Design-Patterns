using System;

public class Employee
{
    public string Name { get; set; }
    public Address Address { get; set; }

    public Employee()
    {

    }

    public Employee(string name, Address address)
    {
        Name = name;
        Address = address;
    }

    // Copy constructor
    public Employee(Employee other)
    {
        Name = other.Name;
        Address = new Address(other.Address);
    }

    public override string ToString()
    {
        return $"Name: {Name}, Address: {Address}";
    }
}

public class Address
{
    public string Street { get; set; }
    public string City { get; set; }

    public Address()
    {

    }

    public Address(string street, string city)
    {
        Street = street;
        City = city;
    }

    // Copy constructor
    public Address(Address other)
    {
        Street = other.Street;
        City = other.City;
    }

    public override string ToString()
    {
        return $"Street: {Street}, City: {City}";
    }
}

public class Program
{
    //public static void Main()
    //{
    //    var johnAddress = new Address("123 Main St", "New York");
    //    var john = new Employee("John Doe", johnAddress);

    //    // Perform a deep copy of John
    //    var jane = new Employee(john);
    //    jane.Name = "Jane Smith";
    //    jane.Address.City = "Los Angeles";

    //    Console.WriteLine(john.ToString());
    //    Console.WriteLine(jane.ToString());
    //}
}
