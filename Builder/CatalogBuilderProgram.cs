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
            public string Name { get; set; }
            public string Description { get; set; }
        }

        public class Category : CatalogItem
        {
            public List<Category> Categories { get; set; }
            public List<Product> Products { get; set; }
        }

        public class Product : CatalogItem
        {
            public double Price { get; set; }
            public bool Availability { get; set; }
        }
    }

    
}
