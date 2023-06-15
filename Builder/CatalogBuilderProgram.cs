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
    internal class CatalogBuilderProgram
    {
        public class CatalogItem
        {
            public string? Name { get; set; }
            public string? Description { get; set; }
        }

        public class Category : CatalogItem
        {
            public List<Category>? Categories { get; set; }
            public List<Product>? Products { get; set; }

            public void Display()
            {
                Console.WriteLine("Categories :");
                foreach (var c in Categories)
                {
                    Console.WriteLine(c.Name);
                    Console.WriteLine(c.Description);
                }

                Console.WriteLine("Products :");
                foreach (var c in Products)
                {
                    Console.WriteLine(c.Name);
                    Console.WriteLine(c.Description);
                }
            }
        }

        public class Product : CatalogItem
        {
            public double Price { get; set; }
            public bool Availability { get; set; }

            public void Display()
            {
                Console.WriteLine($"Price {Price}");
                Console.WriteLine($"Name {Name}");
                Console.WriteLine($"Description {Description}");
                Console.WriteLine($"Availability {Availability}");
            }
        }

        public class CatalogItemBuilder<T> where T : CatalogItem, new()
        {
            protected T? catalofItem;

            public CatalogItemBuilder()
            {
                catalofItem = new T();
            }

            public CatalogItemBuilder<T> SetName(string name)
            {
                catalofItem.Name = name;
                return this;
            }

            public CatalogItemBuilder<T> SetDescription(string desc)
            {
                catalofItem.Description = desc;
                return this;
            }

            public T Build()
            {
                return catalofItem;
            }
        }

        public class ProductBuilder : CatalogItemBuilder<Product>
        {
            public ProductBuilder SetPrice(double price)
            {
                catalofItem.Price = price;
                return this;
            }

            public ProductBuilder SetAvailability(bool available)
            {
                catalofItem.Availability = available;
                return this;
            }

            
        }

        public class CategoryBuilder : CatalogItemBuilder<Category>
        {
            public CategoryBuilder AddCategory(Category category)
            {
                catalofItem.Categories.Add(category);
                return this;
            }

            public CategoryBuilder AddProducts(Product product)
            {
                catalofItem.Products.Add(product);
                return this;
            }
        }

        public static void Main(string[] args)
        {
            var productBuilder = new ProductBuilder();
            Product product = productBuilder
                .SetPrice(99.9)
                .SetAvailability(true)
                .SetName("Sports Shoes")
                .SetDescription("Durable and comfortable athletic shoes for men.")
                .Build();

            var categoryBuilder = new CategoryBuilder();
            var category = categoryBuilder
                .AddProducts(product)
                .SetDescription (product.Description)
                .SetName (product.Name)
                .Build();


            product.Display();
            category.Display();
        }
    }


}
