using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Builder
{
    /// <summary>
    /// Fluent builder inheritance with recursive generics
    /// </summary>
    public class VehicleBuilderProgram
    {
        class Vehicle
        {
            public int Year { get; set; }
            public string Model { get; set; }
            public string Make { get; set; }
            //public Vehicle() { }
        }

        class Car : Vehicle
        {
            public int NumOfDoors { get; set; }

            public void Display()
            {
                Console.WriteLine($"Make {Make}");
                Console.WriteLine($"Model {Model}");
                Console.WriteLine($"Year {Year}");
                Console.WriteLine($"Number of doors {NumOfDoors}");
            }
        }

        class VehicleBuilder<T> where T : Vehicle, new()
        {
            protected T vehicle;
            public VehicleBuilder()
            {
                vehicle = new T();
            }

            public VehicleBuilder<T> SetMake(string make)
            {
                vehicle.Make = make;
                return this;
            }

            public VehicleBuilder<T> SetModel(string model)
            {
                vehicle.Model = model;
                return this;
            }

            public VehicleBuilder<T> SetYear(int year)
            {
                vehicle.Year = year;
                return this;
            }

            public T Build()
            {
                return vehicle;
            }
        }

        class CarBuilder : VehicleBuilder<Car>
        {
            public CarBuilder SetNumOfDoors(int numOfDoors)
            {
                vehicle.NumOfDoors = numOfDoors;
                return this;
            }
        }

        //public static void Main(string[] args)
        //{
        //    var carBuilder = new CarBuilder();

        //    Car car = carBuilder
        //        .SetNumOfDoors(4)
        //        .SetModel("Toyota")
        //        .SetYear(2000)
        //        .SetMake("Camry")
        //        .Build();

        //    car.Display();
        //}
    }
}
