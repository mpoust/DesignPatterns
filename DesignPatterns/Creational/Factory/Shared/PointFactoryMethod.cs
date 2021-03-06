
namespace DesignPatterns.Creational.Factory.Shared
{
    public class PointFactoryMethod
    {
        public double X, Y;

        /*
         * Scenario: We have this class with the constructor below then come across the use case of creating a Point
         *           with polar coordinates of rho and theta like this:
         *
         *           public Point(double rho, double theta){ }
         *
         *           This would generate a compiler error because we cannot have multiple constructors with the same type arguments, even
         *           with different names.
         *
         *           To get around this, we would end up creating an enum with Cartesian and Polar, passing into constructor, switching based
         *           on the enum value, and leading to optional parameter and constructor hell.
         */

        private PointFactoryMethod(double x, double y)
        {
            X = x;
            Y = y;
        }

        // this is a factory method (constructor)
        public static PointFactoryMethod NewCartesianPoint(double x, double y)
        {
            return new PointFactoryMethod(x, y);
        }

        // this is a factory method (constructor)
        public static PointFactoryMethod NewPolarPoint(double rho, double theta)
        {
            return new PointFactoryMethod(rho * Math.Cos(theta), rho * Math.Sin(theta));
        }

        public override string ToString()
        {
            return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }

        
    }
}
