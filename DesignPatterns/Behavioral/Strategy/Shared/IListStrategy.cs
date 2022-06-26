using System.Text;

namespace DesignPatterns.Behavioral.Strategy.Shared
{
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
}
