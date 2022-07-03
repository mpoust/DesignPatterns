using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MoreLinq;
using static System.Console;

namespace DesignPatterns.Creational.Singleton
{
    public interface IDatabase
    {
        int GetPopulation(string name);
    }

    public class SingletonDatabase : IDatabase
    {
        private Dictionary<string, int> capitals;
        private static int instanceCount;
        public static int Count => instanceCount;

        private SingletonDatabase()
        {
            instanceCount++;
            WriteLine("Initializing In-Memory database");

            capitals = File.ReadAllLines(
                    Path.Combine(
                        new FileInfo(typeof(IDatabase).Assembly.Location).DirectoryName, "Creational/Singleton/Shared/capitals.txt")
                    )
                .Batch(2)
                .ToDictionary(
                    list => list.ElementAt(0).Trim(),
                    list => int.Parse(list.ElementAt(1))
                );
        }

        public int GetPopulation(string name)
        {
            return capitals[name];
        }

        private static Lazy<SingletonDatabase> instance = new(() => new SingletonDatabase());

        public static SingletonDatabase Instance => instance.Value;
    }

    public class SingletonRecordFinder
    {
        // this shows the problem with singleton - we have a hardcoded reference to the database
        // so we cannot fake it in testing 

        public int GetTotalPopulation(IEnumerable<string> names)
        {
            int result = 0;
            foreach (var name in names)
            {
                result += SingletonDatabase.Instance.GetPopulation(name);
            }

            return result;
        }
    }

    public class SingletonImplementation
    {
        public static void RunDemo()
        {
            var db = SingletonDatabase.Instance;
            var city = "Tokyo";
            WriteLine($"{city} has population {db.GetPopulation(city)}");
        }
    }
}
