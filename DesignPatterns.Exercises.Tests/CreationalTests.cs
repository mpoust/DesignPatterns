using System.Numerics;
using Autofac;
using DesignPatterns.Creational;
using DesignPatterns.Creational.Singleton;

namespace DesignPatterns.Exercises.Tests
{
    [TestFixture]
    public class CreationalTests
    {
        #region Exercise 2 - Factory Tests

        [Test]
        public void Test()
        {
            var pf = new PersonFactory();

            var p1 = pf.CreatePerson("Chris");
            Assert.That(p1.Name, Is.EqualTo("Chris"));
            Assert.That(p1.Id, Is.EqualTo(0));

            var p2 = pf.CreatePerson("Sarah");
            Assert.That(p2.Id, Is.EqualTo(1));
        }

        #endregion

        #region Singleton - Testability Issues

        // Demonstration of testability issues with first implementation of the singleton pattern
        [Test]
        public void IsSingletonTest()
        {
            var db = SingletonDatabase.Instance;
            var db2 = SingletonDatabase.Instance;
            Assert.That(db, Is.SameAs(db2));
            Assert.That(SingletonDatabase.Count, Is.EqualTo(1));
        }

        [Test]
        public void SingletonTotalPopulationTest()
        {
            // this shows the problem with singleton - hardcoded reference
            var rf = new SingletonRecordFinder();
            var names = new[] { "Seoul", "Mexico City" };
            int tp = rf.GetTotalPopulation(names);
            Assert.That(tp, Is.EqualTo(17500000 + 17400000));
        }

        [Test]
        public void ConfigurableTotalPopulationTest()
        {
            var rf = new ConfigurableRecordFinder(new DummyDatabase());
            var names = new[] { "alpha", "gamma" };
            int tp = rf.GetTotalPopulation(names);
            Assert.That(tp, Is.EqualTo(4));
        }

        [Test]
        public void DependencyInjectionPopulationTest()
        {
            var cb = new ContainerBuilder();
            //cb.RegisterType<OrdinaryDatabase>().As<IDatabase>()
            //    .SingleInstance();
            cb.RegisterType<DummyDatabase>().As<IDatabase>()
                .SingleInstance();
            cb.RegisterType<ConfigurableRecordFinder>();

            using (var c = cb.Build())
            {
                var rf = c.Resolve<ConfigurableRecordFinder>();
                var names = new[] { "alpha", "gamma" };
                int tp = rf.GetTotalPopulation(names);
                Assert.That(tp, Is.EqualTo(4));
            }

        }

        #region Setup

        public class DummyDatabase : IDatabase
        {
            public int GetPopulation(string name)
            {
                return new Dictionary<string, int>
                {
                    ["alpha"] = 1,
                    ["beta"] = 2,
                    ["gamma"] = 3
                }[name];
            }
        }

        #endregion

        #endregion
    }
}
