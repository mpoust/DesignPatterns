/*
 *  Example of a Dynamic Strategy Pattern
 *
 *  Where the strategy can be swapped at runtime
 */

using System.Text;
using DesignPatterns.Behavioral.Strategy.Shared;

namespace DesignPatterns.Behavioral.Strategy
{
    public class TextProcessor
    {
        private StringBuilder sb = new StringBuilder();
        private IListStrategy listStrategy;

        public void SetOutputFormat(OutputFormat format)
        {
            listStrategy = format switch
            {
                OutputFormat.Markdown => new MarkdownListStrategy(),
                OutputFormat.Html => new HtmlListStrategy(),
                _ => throw new ArgumentOutOfRangeException(nameof(format), format, null)
            };
        }

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

    public class DynamicStrategy
    {
        /// <summary>
        ///     Show the dynamic strategy for the provided output format, with a default
        ///     of Markdown if no format provided
        /// </summary>
        /// <param name="format"></param>
        public static void RunStrategy(OutputFormat format = OutputFormat.Markdown)
        {
            var tp = new TextProcessor();
            tp.SetOutputFormat(format);
            tp.AppendList(new[] { "foo", "bar", "baz" });
            Console.WriteLine(tp);
            tp.Clear();
        }
    }
}