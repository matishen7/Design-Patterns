using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Factories
{
    internal class AbstractFactoryDemo
    {
        internal interface IHotDrink
        {
            public void Consume();
        }

        internal class Tea : IHotDrink
        {
            public void Consume()
            {
                Console.WriteLine("This tea is awesome!");
            }
        }

        internal class Coffee: IHotDrink
        {
            public void Consume()
            {
                Console.WriteLine("This coffee is amazing!");
            }
        }

        internal interface IHotDrinkFactory
        {
            public IHotDrink Prepare(int amount);
        }

        internal class TeaFactory : IHotDrinkFactory
        {
            public IHotDrink Prepare(int amount)
            {
                Console.WriteLine($"Put tea bag, boil water, pour water and enjoy!");
                return new Tea();
            }
        }

        internal class CoffeeFactory : IHotDrinkFactory
        {
            public IHotDrink Prepare(int amount)
            {
                Console.WriteLine($"Grind beans, boil water, pour water, add milk and enjoy!");
                return new Coffee();
            }
        }

    }
}
