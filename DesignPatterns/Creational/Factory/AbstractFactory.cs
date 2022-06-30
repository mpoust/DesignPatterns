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
        //public enum AvailableDrink
        //{
        //    Coffee, Tea
        //}

//        private Dictionary<AvailableDrink, IHotDrinkFactory> factories =
//            new Dictionary<AvailableDrink, IHotDrinkFactory>();

//        public HotDrinkMachine()
//        {
//            foreach (AvailableDrink drink in Enum.GetValues(typeof(AvailableDrink)))
//            {
//#pragma warning disable CS8600
//                var factory = (IHotDrinkFactory)Activator.CreateInstance(
//                    Type.GetType("DesignPatterns.Creational.Factory." + Enum.GetName(typeof(AvailableDrink), drink) +
//                                 "Factory")!);
//#pragma warning restore CS8600
//                factories.Add(drink, factory);
//            }
//        }

//        public IHotDrink MakeDrink(AvailableDrink drink, int amount)
//        {
//            return factories[drink].Prepare(amount);
//        }

/*
 *  The example above violates the Open Closed Principle (OCP)
 *
 *  Example below corrects this with use of reflection (in actual practice we would do this via a DI framework)
 *
 */

        private List<Tuple<string, IHotDrinkFactory>> factories = new();

        public HotDrinkMachine()
        {
            foreach (var t in typeof(HotDrinkMachine).Assembly.GetTypes())
            {
                if (typeof(IHotDrinkFactory).IsAssignableFrom(t) && !t.IsInterface)
                {
#pragma warning disable CS8620
                    factories.Add(Tuple.Create(
                        t.Name.Replace("Factory", string.Empty),
                        (IHotDrinkFactory)Activator.CreateInstance(t)
                        ));
#pragma warning restore CS8620
                } 
            }
        }

        public IHotDrink MakeDrink(string num, string amt)
        {
            Console.WriteLine("Available Drinks:");
            for (var index = 0; index < factories.Count; index++)
            {
                var tuple = factories[index];
                Console.WriteLine($"{index}: {tuple.Item1}");
            }

            while (true)
            {
                string s;
                if ((s = num) != null 
                    && int.TryParse(s, out int i) 
                    && i >= 0 
                    && i < factories.Count)
                {
                    Console.WriteLine("Specify amount: ");
                    s = amt;

                    if (s != null && int.TryParse(s, out int amount) && amount > 0)
                    {
                        return factories[i].Item2.Prepare(amount);
                    }
                }

                Console.WriteLine("Incorrect input, try again");
            }
        }

    }

    public class AbstractFactory
    {
        public static void RunDemonstration()
        {
            Console.WriteLine("\nAbstract Factory Demonstration - Making Coffee and Tea");
            var machine = new HotDrinkMachine();
            var drink = machine.MakeDrink("0", "100");
            var drink2 = machine.MakeDrink("1", "75");

            // below is old example that violates OCP

            //var tea = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Tea, 100);
            //tea.Consume();

            //var coffee = machine.MakeDrink(HotDrinkMachine.AvailableDrink.Coffee, 75);
            //coffee.Consume();
        }
    }
}
