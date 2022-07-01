using DesignPatterns.Structural;

namespace DesignPatterns.Exercises.Tests
{
    [TestFixture]
    public class StructuralTests
    {
        #region Exercise 5 - Adapter Tests

        [Test]
        public void Test()
        {
            var sq = new Square { Side = 11 };
            var adapter = new SquareToRectangleAdapter(sq);
            Assert.That(adapter.Area(), Is.EqualTo(121));
        }

        #endregion

    }
}
