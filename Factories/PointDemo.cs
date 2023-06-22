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

            public static Point CreateNewCartesian(double x, double y) { return new Point(x, y); }
            public static Point CreateNewPolar(double rho, double theta) { return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta)); }
        }
    }
}
