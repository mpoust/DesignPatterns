
namespace DesignPatterns.Creational.Factory.Shared
{
    public class Foo
    {
        // constructor
        private Foo()
        {
            // blank constructor that is private and cannot be used
        }

        // example of making a method to do an async operation - this makes things complicated
        // because then when using this class you must always remember to call this InitAsync method after initializing the class
        //
        //  var foo = new Foo();
        //  await foo.InitAsync(); 
        //
        //  if you forget this second line it would be problematic and not a good design
        //  to get around this, we can use a factory method that would prohibit use of the constructor
        //  and ensure initialization is happening correctly 
        private async Task<Foo> InitAsync()
        {
            await Task.Delay(1000);
            return this;
        }

        /// <summary>
        ///     Example factory method ensuring async operations are completed when this class is initialized 
        /// </summary>
        /// <returns></returns>
        public static Task<Foo> CreateAsync()
        {
            var result = new Foo();
            return result.InitAsync();
        }
    }
}
