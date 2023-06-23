using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Factories
{
    internal class PointDemo
    {
        class Point
        {
            private double x { get; set; }
            private double y { get; set; }

            private Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public override string ToString()
            {
                return $"{nameof(x)} = {x}, {nameof(y)} = {y}";
            }

            public static Point Origin => new Point(0.0, 0.0);
            //public static Point Origin = new Point(0.0, 0.0); // better

            public static class Factory
            {

                public static Point CreateNewCartesian(double x, double y) { return new Point(x, y); }
                public static Point CreateNewPolar(double rho, double theta) { return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta)); }
            }
        }

        public static void Main(string[] args)
        {
            var p = Point.Factory.CreateNewCartesian(1.0, 1.0);
            var p2 = Point.Factory.CreateNewPolar(1.0, 1.0);
            var origin = Point.Origin;
            Console.WriteLine(p.ToString());
            Console.WriteLine(p2.ToString());
            Console.WriteLine(origin);
        }
    }
}
