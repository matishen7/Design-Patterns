using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Builder
{
    internal class PizzaBuilderProgram
    {
        //public static void Main(string[] args)
        //{
        //    var pizzaBuilder = new PizzaBuilder();
        //    Pizza pizza = pizzaBuilder
        //        .SetSize(Size.Medium)
        //        .SetCrustType("Thin Crust")
        //        .SetSauceType("Tomato Sauce")
        //        .AddToppings("Cheese")
        //        .Build();

        //    pizza.Display();
        //}
    }

    class Pizza
    {
        public Size Size;
        public string CrustType;
        public string SauceType;
        public string Toppings;
        public Pizza() { }
        public Pizza(Size size, string crustType, string sauceType, string toppings)
        {
            Size = size;
            CrustType = crustType;
            SauceType = sauceType;
            Toppings = toppings;
        }

        public void Display()
        {
            Console.WriteLine($"Size: {Size}");
            Console.WriteLine($"Crust Type: {CrustType}");
            Console.WriteLine($"Sauce Type: {SauceType}");
            Console.WriteLine($"Toppings: {Toppings}");
        }
    }

    enum Size
    {
        Small,
        Medium,
        Large,
        ExtraLarge
    }

    class PizzaBuilder
    {
        private Size size;
        private string crustType;
        private string sauceType;
        private string toppings;

        public PizzaBuilder SetSize(Size size)
        {
            this.size = size;
            return this;
        }

        public PizzaBuilder SetCrustType(string crustType)
        {
            this.crustType = crustType;
            return this;
        }

        public PizzaBuilder SetSauceType(string sauceType)
        {
            this.sauceType = sauceType;
            return this;
        }

        public PizzaBuilder AddToppings(string toppings)
        {
            this.toppings = toppings;
            return this;
        }

        public Pizza Build()
        {
            return new Pizza(size, crustType, sauceType, toppings);
        }
    }


}
