using DesignPatterns.Creational.Factory.Shared;

namespace DesignPatterns.Creational.Factory
{
    /// <summary>
    ///     Class to run all factory pattern demonstrations
    /// </summary>
    public class FactoryDemo
    {
        public static void RunFactoryMethodDemonstration()
        {
            Console.WriteLine("\n Factory Method Demonstration:");

            Console.WriteLine("\nPolar Point:");
            var polar = PointFactoryMethod.NewPolarPoint(1.0, Math.PI / 2);
            Console.WriteLine(polar);

            Console.WriteLine("\nCartesian Point:");
            var cartesian = PointFactoryMethod.NewCartesianPoint(5.0, 15.5);
            Console.WriteLine(cartesian);
        }

        public static async Task RunAsyncDemonstration()
        {
            Console.WriteLine("\nRunning Async Constructor with Factory Method");
            Console.WriteLine($"Demo Started: {DateTime.Now}");
            Foo x = await Foo.CreateAsync();
            Console.WriteLine($"Demo Completed: {DateTime.Now}");
        }

        public static void RunExternalFactoryDemonstration()
        {
            Console.WriteLine("\n External Factory Demonstration:");

            Console.WriteLine("\nPolar Point:");
            var polar = PointFactory.NewPolarPoint(1.0, Math.PI / 2);
            Console.WriteLine(polar);

            Console.WriteLine("\nCartesian Point:");
            var cartesian = PointFactory.NewCartesianPoint(5.0, 15.5);
            Console.WriteLine(cartesian);
        }
    }
}
