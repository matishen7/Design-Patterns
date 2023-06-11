using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.SOLID
{
    public class LiskovSubstitution
    {
        internal abstract class Shape
        {
           // public abstract double CalculateArea();
           public virtual double CalculateArea()
            {
                return 0.0;
            }

            public Shape() { }
        }

        internal class Rectangle : Shape
        {
            public int Width;
            public int Height;
            public override double CalculateArea()
            {
                return Width * Height;
            }

            public Rectangle(int width, int height)
            {
                Width = width;
                Height = height;
            }
        }

        internal class Circle : Shape
        {
            public int radius;
            public override double CalculateArea()
            {
                return Math.PI * radius * radius;
            }

            public Circle(int radius)
            {
                this.radius = radius;
            }
        }

        public static void Main(string[] args)
        {
            var rc = new Rectangle(3,4);
            Console.WriteLine(rc.CalculateArea());
            var circle = new Circle(9);
            Console.WriteLine(circle.CalculateArea());
        }
    }
}
