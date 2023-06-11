using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.SOLID
{
    public class OpenClose
    {
        public enum Color
        {
            Red, Blue, Black
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
    }
}
