using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Design_Patterns.Factories.AbstractFactoryDemo;

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

        class VehicleClient
        {
            IVehicleFactory _vehicleFactory;
            IVehicle _vehicle;
            public VehicleClient(IVehicleFactory vehicleFactory)
            {
                _vehicleFactory = vehicleFactory;
            }

            public void DriveVehicle()
            {
                _vehicle = _vehicleFactory.CreateVehicle();
                _vehicle.Drive();
            }
        }

        static void Main(string[] args)
        {
            var vehicleClient = new VehicleClient(new MotorcycleFactory());
            vehicleClient.DriveVehicle();
        }
    }
}
