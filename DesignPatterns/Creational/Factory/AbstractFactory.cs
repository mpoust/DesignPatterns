using DesignPatterns.Creational.Factory.Shared;

namespace DesignPatterns.Creational.Factory
{
    internal class Tea : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("\nThis tea is nice, but I would prefer it with sugar");
        }
    }

    internal class Coffee : IHotDrink
    {
        public void Consume()
        {
            Console.WriteLine("\nThis coffee is excellent!");
        }
    }

    internal class TeaFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"\nPut in a tea bag, boil water, pour {amount} ml, add lemon, enjoy!");
            return new Tea();
        }
    }

    internal class CoffeeFactory : IHotDrinkFactory
    {
        public IHotDrink Prepare(int amount)
        {
            Console.WriteLine($"\nGrind beans, boil water, pour {amount} ml, add cream and sugar, enjoy!");
            return new Coffee();
        }
    }

    public class HotDrinkMachine
    {
        public enum AvailableDrink
        {
            Coffee, Tea
        }

        private Dictionary<AvailableDrink, IHotDrinkFactory> factories =
            new Dictionary<AvailableDrink, IHotDrinkFactory>();

        public HotDrinkMachine()
        {
            foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
            {
#pragma warning disable CS8600
                var factory = (IHotDrinkFactory)Activator.CreateInstance(
                    Type.GetType("DesignPatterns.Creational.Factory." + Enum.GetName(typeof(AvailableDrink), drink) +
                                 "Factory")!);
#pragma warning restore CS8600
                factories.Add(drink, factory);
            }
        }

        public IHotDrink MakeDrink(AvailableDrink drink, int amount)
        {
            return factories[drink].Prepare(amount);
        }
    }

    public class AbstractFactory
    {
        public static void RunDemonstration()
        {
            Console.WriteLine("\nAbstract Factory Demonstration - Making Coffee and Tea");
            var machine = new HotDrinkMachine();

            var tea = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 100);
            tea.Consume();

            var coffee = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Coffee, 75);
            coffee.Consume();
        }
    }
}
