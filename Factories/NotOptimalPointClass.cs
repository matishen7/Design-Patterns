using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Factories
{
    internal class NotOptimalPointClass
    {
        public class Point
        {
            private double x, y;

            protected Point(double x, double y)
            {
                this.x = x;
                this.y = y;
            }

            public Point(double a,
              double b, // names do not communicate intent
              CoordinateSystem cs = CoordinateSystem.Cartesian)
            {
                switch (cs)
                {
                    case CoordinateSystem.Polar:
                        x = a * Math.Cos(b);
                        y = a * Math.Sin(b);
                        break;
                    default:
                        x = a;
                        y = b;
                        break;
                }
            }

            public enum CoordinateSystem
            {
                Cartesian,
                Polar
            }


        }

    }
}
