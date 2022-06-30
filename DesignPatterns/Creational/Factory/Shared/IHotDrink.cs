
namespace DesignPatterns.Creational.Factory.Shared
{
    /// <summary>
    ///     Interface to show Abstract Factory methods
    /// </summary>
    public interface IHotDrink
    {
        void Consume();
    }

    /// <summary>
    ///     Interface to show creating an abstract factory
    /// </summary>
    public interface IHotDrinkFactory
    {
        IHotDrink Prepare(int amount);
    }
}
