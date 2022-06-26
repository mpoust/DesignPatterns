// See https://aka.ms/new-console-template for more information

using DesignPatterns.Patterns.Behavioral.Strategy;

Console.WriteLine("**************** BEHAVIORAL STRATEGIES ****************");

Console.WriteLine("******** Dynamic Strategy Pattern ********");

DynamicStrategy.RunStrategy(OutputFormat.Markdown);
DynamicStrategy.RunStrategy(OutputFormat.Html);