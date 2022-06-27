using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DesignPatterns.Creational.Factory.Shared;

namespace DesignPatterns.Creational.Factory
{
    /// <summary>
    ///     Showing the Factory Method design pattern with an example of points
    /// </summary>
    public class FactoryMethod
    {
        /// <summary>
        ///     Show the demonstration creating different types of points with the factory method constructors
        /// </summary>
        public static void RunDemonstration()
        {
            Console.WriteLine("\nPolar Point:");
            var polar = Point.NewPolarPoint(1.0, Math.PI / 2);
            Console.WriteLine(polar);

            Console.WriteLine("\nCartesian Point:");
            var cartesian = Point.NewCartesianPoint(5.0, 15.5);
            Console.WriteLine(cartesian);
        }
    }
}
