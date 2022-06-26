/*
 *  Show using strategies for comparision
 *
 *  Can do a similar process for equality by implementing IEquatable 
 *
 *
 *  This shows how the .NET framework using the strategy pattern for comparision and equality 
 */

namespace DesignPatterns.Behavioral.Strategy
{
    public class Person : IComparable<Person>, IComparable
    {
        public int Id;

        public string Name;

        public int Age;

        public static IComparer<Person> NameComparer { get; } 
            = new NameRelationalComparer();

        public Person(int id, string name, int age)
        {
            Id=id;
            Name=name;
            Age=age;
        }

        private sealed class NameRelationalComparer 
            : IComparer<Person>
        {
            public int Compare(Person x, Person y)
            {
                if (ReferenceEquals(x, y)) return 0;
                if (ReferenceEquals(null, y)) return 1;
                if (ReferenceEquals(null, x)) return -1;
                return string.Compare(x.Name, y.Name, StringComparison.Ordinal);
            }
        }

        public int CompareTo(Person? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (ReferenceEquals(null, other)) return 1;
            return Id.CompareTo(other.Id);
        }

        public int CompareTo(object? obj)
        {
            if (ReferenceEquals(null, obj)) return 1;
            if (ReferenceEquals(this, obj)) return 0;
            return obj is Person other ? CompareTo(other) 
                : throw new ArgumentException($"Object must be of type {nameof(Person)}");
        }

        public static bool operator <(Person? left, Person? right)
        {
            return Comparer<Person>.Default.Compare(left, right) < 0;
        }

        public static bool operator >(Person? left, Person? right)
        {
            return Comparer<Person>.Default.Compare(left, right) > 0;
        }

        public static bool operator <=(Person? left, Person? right)
        {
            return Comparer<Person>.Default.Compare(left, right) <= 0;
        }

        public static bool operator >=(Person? left, Person? right)
        {
            return Comparer<Person>.Default.Compare(left, right) >= 0;
        }

        public override string ToString()
        {
            return $"{Id} {Name} {Age}";
        }
    }

    public class EqualityAndComparison
    {
        public static void RunStrategy()
        {
            var people = new List<Person>()
            {
                new(2, "Zack", 30),
                new(1, "Steve", 35),
                new(4, "Alice", 30),
                new(3, "Bob", 25)
            };

            // default strategy to compare with relational operators - defined above by implementing IComparable
            Console.WriteLine("Default - By ID:");
            people.Sort();
            people.ForEach(p => Console.WriteLine(p));

            // this is the sort that is built into the list type by sorting from a defined lambda expression, not the LINQ sort
            Console.WriteLine("\nExplicit List Sort by name:");
            people.Sort((x,y) => x.Name.CompareTo(y.Name));
            people.ForEach(p => Console.WriteLine(p));

            // by implementing the NameRelationalComparer we can do the following instead of the line above
            Console.WriteLine("\nNameRelationalComparer Method:");
            people.Sort(Person.NameComparer);
            people.ForEach(p => Console.WriteLine(p));
        }
    }
}
