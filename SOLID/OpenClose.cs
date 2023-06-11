using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.SOLID
{
    public class OpenClose
    {
        public enum Color
        {
            Red, Blue, Green
        }

        public enum Size
        {
            Small, Medium, Large
        }

        public class Product
        {
            public string Name { get; set; }
            public Color Color { get; set; }
            public Size Size { get; set; }
            public Product() { }
            public Product(string name, Color color)
            {
                Name = name;
                Color = color;
            }


            public Product(string name, Color color, Size size) : this(name, color)
            {
                Size = size;
            }
        }

        /// <summary>
        /// old way
        /// </summary>

        public class ProductFilter
        {
            public IEnumerable<Product> FilterBySize(IEnumerable<Product> products, Size size)
            {
                foreach (var product in products)
                {
                    if (product.Size == size)
                        yield return product;
                }
            }

            public IEnumerable<Product> FilterByColor(IEnumerable<Product> products, Color color)
            {
                foreach (var product in products)
                {
                    if (product.Color == color)
                        yield return product;
                }
            }
        }

        public static void Main(string[] args)
        {
            var apple = new Product("apple", Color.Green, Size.Small);
            var tree = new Product("tree", Color.Green, Size.Small);
            var car = new Product("car", Color.Red, Size.Large);

            var pf = new ProductFilter();
            Product[] products = new Product[] { apple, tree, car };

            foreach (var p in pf.FilterBySize(products, Size.Small))
            {
                Console.WriteLine($"Green products {p.Name}");
            }
        }
    }

}

