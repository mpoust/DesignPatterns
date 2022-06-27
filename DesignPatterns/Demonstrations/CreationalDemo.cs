
using DesignPatterns.Creational.Factory;

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
            FactoryMethod.RunDemonstration();

            Console.WriteLine("\n******** Async Factory Method Pattern ********");
            await AsyncFactory.RunDemonstration();
        }
    }
}
