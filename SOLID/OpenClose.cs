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

            public IEnumerable<Product> FilterBySizeAndColor(IEnumerable<Product> products, Size size, Color color)
            {
                foreach (var product in products)
                {
                    if (product.Color == color && product.Size == size)
                        yield return product;
                }
            }
        }

        public interface ISpecification<T>
        {
            public bool IsSatisfied(T t);
        }

        public interface IFilter<T>
        {
            IEnumerable<T> Filter(IEnumerable<T> items, ISpecification<T> specification);
        }

        public class ColorSpecification : ISpecification<Product>
        {
            private Color color;
            public ColorSpecification(Color color)
            {
                this.color = color;
            }

            public bool IsSatisfied(Product product)
            {
                return product.Color == color;
            }
        }

        public class SizeSpecification : ISpecification<Product>
        {
            private Size size;
            public SizeSpecification(Size size)
            {
                this.size = size;
            }

            public bool IsSatisfied(Product product)
            {
                return product.Size == size;
            }
        }

        public class AndSpecification<T> : ISpecification<T>
        {
            private ISpecification<T> first, second;

            public AndSpecification(ISpecification<T> first, ISpecification<T> second)
            {
                if (first == null)
                    throw new ArgumentNullException(paramName: nameof(first));
                if (second == null)
                    throw new ArgumentNullException(paramName: nameof(second));

                this.first = first;
                this.second = second;
            }

            public bool IsSatisfied(T item)
            {
                return first.IsSatisfied(item) && second.IsSatisfied(item);
            }

        }


        /// <summary>
        /// new way, implements open close design pattern
        /// </summary>
        public class BetterFilter : IFilter<Product>
        {
            public IEnumerable<Product> Filter(IEnumerable<Product> items, ISpecification<Product> specification)
            {
                foreach (var i in items)
                {
                    if (specification.IsSatisfied(i)) yield return i;
                }
            }
        }

        //public static void Main(string[] args)
        //{
        //    var apple = new Product("apple", Color.Green, Size.Small);
        //    var tree = new Product("tree", Color.Green, Size.Small);
        //    var car = new Product("car", Color.Red, Size.Large);

        //    var pf = new ProductFilter();
        //    Product[] products = new Product[] { apple, tree, car };

        //    foreach (var p in pf.FilterBySize(products, Size.Small))
        //    {
        //        Console.WriteLine($"Green products(old) {p.Name}");
        //    }

        //    foreach (var p in pf.FilterByColor(products, Color.Red))
        //    {
        //        Console.WriteLine($"Red products(old) {p.Name}");
        //    }

        //    var bf = new BetterFilter();
        //    var cs = new ColorSpecification(Color.Green);
        //    foreach (var p in bf.Filter(products, cs))
        //    {
        //        Console.WriteLine($"Green products(new) {p.Name}");
        //    }

        //    foreach (var p in bf.Filter(products,
        //        new AndSpecification<Product>(
        //        new ColorSpecification(Color.Red),
        //        new SizeSpecification(Size.Large)
        //        )))
        //    {
        //        Console.WriteLine($"Color red and large products(new) {p.Name}");
        //    }
        //}
    }

}

