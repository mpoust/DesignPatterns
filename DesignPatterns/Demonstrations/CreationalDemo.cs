
using DesignPatterns.Creational.Factory;
using DesignPatterns.Creational.Singleton;

namespace DesignPatterns.Demonstrations
{
    /// <summary>
    ///     Class to demonstrate the Creational Design Patterns
    /// </summary>
    public class CreationalDemo
    {
        /// <summary>
        ///     Run the demonstration for the Factory Pattern
        /// </summary>
        public static async Task RunFactoryDemo()
        {
            Console.WriteLine("******** Factory Method Pattern ********");
            FactoryDemo.RunFactoryMethodDemonstration();

            Console.WriteLine("\n******** Async Factory Method Pattern ********");
            await FactoryDemo.RunAsyncDemonstration();

            Console.WriteLine("\n******** External Factory Pattern ********");
            FactoryDemo.RunExternalFactoryDemonstration();

            Console.WriteLine("\n******** Benefits of Factory Pattern - Object Tracking and Bulk Replacement ********");
            FactoryDemo.RunFactoryBenefitDemonstration();

            Console.WriteLine("\n******** Abstract Factory Pattern ********");
            FactoryDemo.RunAbstractFactoryDemonstration();

            Console.WriteLine("\n******** Singleton Pattern with in-memory Capitals database ********");
            SingletonImplementation.RunDemo();
        }
    }
}
