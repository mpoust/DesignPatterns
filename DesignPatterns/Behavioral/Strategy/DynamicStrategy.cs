/*
 *  Example of a Dynamic Strategy Pattern
 */

using System.Text;

namespace DesignPatterns.Patterns.Behavioral.Strategy
{
    public enum OutputFormat
    {
        Markdown,
        Html
    }

    /// <summary>
    ///     Strategy interface to implement for anything that needs to output a list
    ///     Can dynamically swap between formats from <see cref="OutputFormat"/> enum.
    /// </summary>
    /// <remarks>
    ///     Html --> <ul><li>foo</li></ul>
    ///     <br/>
    ///     <br/>
    ///     Markdown --> * foo
    /// </remarks>
    public interface IListStrategy
    {
        void Start(StringBuilder sb);
        void End(StringBuilder sb);
        void AddListItem(StringBuilder sb, string item);
    }

    public class HtmlListStrategy : IListStrategy
    {
        public void Start(StringBuilder sb)
        {
            sb.AppendLine("<ul>");
        }

        public void End(StringBuilder sb)
        {
            sb.AppendLine("</ul>");
        }

        public void AddListItem(StringBuilder sb, string item)
        {
            sb.AppendLine($"   <li>{item}</li>");
        }
    }

    public class MarkdownListStrategy : IListStrategy
    {
        public void Start(StringBuilder sb)
        {
            // INTENTIONALLY EMPTY FOR MARKDOWN
        }

        public void End(StringBuilder sb)
        {
            // INTENTIONALLY EMPTY FOR MARKDOWN
        }

        public void AddListItem(StringBuilder sb, string item)
        {
            sb.AppendLine($" * {item}");
        }
    }

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