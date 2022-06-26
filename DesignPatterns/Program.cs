// See https://aka.ms/new-console-template for more information

using DesignPatterns.Behavioral.Strategy;
using DesignPatterns.Behavioral.Strategy.Shared;

Console.WriteLine("**************** BEHAVIORAL STRATEGIES ****************");

Console.WriteLine("******** Dynamic Strategy Pattern ********");
DynamicStrategy.RunStrategy(OutputFormat.Markdown);
DynamicStrategy.RunStrategy(OutputFormat.Html);

Console.WriteLine("******** Static Strategy Pattern ********");
StaticStrategy.RunStrategies();