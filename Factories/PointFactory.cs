using static Design_Patterns.Factories.NotOptimalPointClass;

namespace Design_Patterns.Factories
{
    internal static class PointFactory
    {

        public static Point CreateNewCartesian(double x, double y) { return new Point(x, y); }
        public static Point CreateNewPolar(double rho, double theta) { return new Point(rho * Math.Cos(theta), rho * Math.Sin(theta)); }
    }
}