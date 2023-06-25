using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Factories
{
    internal class AbstractVehicleFactoryDemo
    {
        internal interface IVehicle
        {
            public void Drive();
        }

        class Car : IVehicle
        {
            public void Drive()
            {
                Console.WriteLine("I am driving a car.");
            }
        }

        class Motorcycle : IVehicle
        {
            public void Drive()
            {
                Console.WriteLine("I am driving a motorbike.");
            }
        }

        class Bicycle : IVehicle
        {
            public void Drive()
            {
                Console.WriteLine("I am driving a bicycle.");
            }
        }

        interface IVehicleFactory
        {
            public IVehicle CreateVehicle();
        }

        class CarFactory : IVehicleFactory
        {
            public IVehicle CreateVehicle()
            {
                return new Car();
            }
        }

        class MotorcycleFactory : IVehicleFactory
        {
            public IVehicle CreateVehicle()
            {
                return new Motorcycle();
            }
        }

        class BicycleFactory : IVehicleFactory
        {
            public IVehicle CreateVehicle()
            {
                return new Bicycle();
            }
        }
    }
}
