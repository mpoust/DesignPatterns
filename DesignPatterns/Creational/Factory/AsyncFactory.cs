
using DesignPatterns.Creational.Factory.Shared;

namespace DesignPatterns.Creational.Factory
{
    /// <summary>
    ///     Showing asynchronous operations in constructor with a factory method
    /// </summary>
    public class AsyncFactory
    {
        public static async Task RunDemonstration()
        {
            Console.WriteLine("\nRunning Async Constructor with Factory Method");
            Console.WriteLine($"Demo Started: {DateTime.Now}");
            Foo x = await Foo.CreateAsync();
            Console.WriteLine($"Demo Completed: {DateTime.Now}");
        }
    }
}
