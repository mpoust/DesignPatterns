using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesignPatterns.Creational.Factory.Shared
{
    public class PointFactory
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

    /// <summary>
    ///     Class to show making a Point with an external Factory instead of factory methods
    /// </summary>
    public class PointWithFactory
    {
        public double X, Y;

        // at this point we have the constraint of the constructor being public which
        // could lead to problems and improper use

        public PointWithFactory(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
