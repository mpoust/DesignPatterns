
using DesignPatterns.Behavioral.Strategy;
using DesignPatterns.Behavioral.Strategy.Shared;

namespace DesignPatterns.Demonstrations
{
    /// <summary>
    ///     Class to demonstrate the Behavioral Design Patterns
    /// </summary>
    public class BehavioralDemo
    {
        /// <summary>
        ///     Run the demonstration for the Strategy Pattern
        /// </summary>
        public static void RunStrategyDemo()
        {
            Console.WriteLine("******** Dynamic Strategy Pattern ********");
            DynamicStrategy.RunStrategy(OutputFormat.Markdown);
            DynamicStrategy.RunStrategy(OutputFormat.Html);

            Console.WriteLine("******** Static Strategy Pattern ********");
            StaticStrategy.RunStrategies();

            Console.WriteLine("******** Comparison Example with .NET Framework Strategy ********");
            EqualityAndComparison.RunStrategy();
        }
    }
}
