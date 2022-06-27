/*
 *  Example of a Static Strategy Pattern
 *
 *  In this instance you would do something like the following in the DI container:
 *      cb.Register<MarkdownListStrategy>().As<IListStrategy>();
 *
 *  In our example we are hard-coding the strategy as a generic argument.
 */

using DesignPatterns.Behavioral.Strategy.Shared;

namespace DesignPatterns.Behavioral.Strategy
{
    internal class TextProcessor<LS> where LS : IListStrategy, new()
    {
        private StringBuilder sb = new StringBuilder();
        private IListStrategy listStrategy = new LS();

        public void AppendList(IEnumerable<string> items)
        {
            listStrategy.Start(sb);
            foreach (var item in items)
            {
                listStrategy.AddListItem(sb, item);
            }
            listStrategy.End(sb);
        }

        public StringBuilder Clear()
        {
            return sb.Clear();
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }

    public class StaticStrategy
    {
        /// <summary>
        ///     Show the static strategy for both Markdown and HTML
        /// </summary>
        public static void RunStrategies()
        {
            var tp = new TextProcessor<MarkdownListStrategy>();
            tp.AppendList(new[] { "foo", "bar", "baz" });
            Console.WriteLine(tp);
            tp.Clear();

            var tp2 = new TextProcessor<HtmlListStrategy>();
            tp2.AppendList(new[] { "foo", "bar", "baz" });
            Console.WriteLine(tp2);
        }
    }
}