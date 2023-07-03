using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Design_Patterns.Prototypes
{
    public class Point : IPrototype<Point>
    {
        public int X, Y;

        public Point()
        {

        }

        public Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public Point DeepCopy()
        {
            return new Point(X,Y);
        }

        public static void Main()
        {
            var point1 = new Point(0, 1);
            var point2 = new Point(3, 1);

            var line1 = new Line(point1, point2);
            var line2 = line1.DeepCopy();
        }
    }
    public class Line : IPrototype<Line>
    {
        public Point Start, End;

        public Line()
        {

        }

        public Line(Point start, Point end)
        {
            this.Start = start;
            this.End = end;
        }

        public Line DeepCopy()
        {
            return new Line(Start, End);
        }
    }

    interface IPrototype<T>
    {
        public T DeepCopy();
    }

    
}
