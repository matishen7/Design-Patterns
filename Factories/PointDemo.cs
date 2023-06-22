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

            public Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public override string ToString()
            {
                return $"{nameof(x)} = {x}, {nameof(y)} = {y}";
            }
        }

        //public static void Main(string[] args)
        //{
        //    var p = Point.CreateNewCartesian(1.0, 1.0);
        //    var p2 = Point.CreateNewPolar(1.0, 1.0);

        //    Console.WriteLine(p.ToString());
        //    Console.WriteLine(p2.ToString());
        //}
    }
}
