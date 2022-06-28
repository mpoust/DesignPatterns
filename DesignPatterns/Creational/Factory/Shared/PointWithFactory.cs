

namespace DesignPatterns.Creational.Factory.Shared
{
    /// <summary>
    ///     Class to show making a Point with an external Factory instead of factory methods
    /// </summary>
    public class PointWithFactory
    {
        public double X, Y;

        public static PointWithFactory Origin => new PointWithFactory(0, 0);

        public static PointWithFactory Origin2 = new PointWithFactory(0, 0); // better because then accessing will be singleton instead of new Point each time

        // at this point we have the constraint of the constructor being public which
        // could lead to problems and improper use

        private PointWithFactory(double x, double y)
        {
            X = x;
            Y = y;
        }

        public override string ToString()
        {
            return $"{nameof(X)}: {X}, {nameof(Y)}: {Y}";
        }

        /*
         *  If we don't want the factory to be static we could create a variable:
         *      public static Factory Factory => new Factory();
         *
         *  Which would then allow us to have a non static Factory class with a static accessor.
         *
         *  However, the best and most simple approach is to leave this as static like below.
         *
         */

        public static class Factory
        {
            // this is a factory method (constructor)
            public static PointWithFactory NewCartesianPoint(double x, double y)
            {
                return new PointWithFactory(x, y);
            }

            // this is a factory method (constructor)
            public static PointWithFactory NewPolarPoint(double rho, double theta)
            {
                return new PointWithFactory(rho * Math.Cos(theta), rho * Math.Sin(theta));
            }
        }
    }
}
