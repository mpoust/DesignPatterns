/*
 *  Show additional benefits of factories - regarding Object Tracking and Bulk Replacement
 *
 */

namespace DesignPatterns.Creational.Factory.Shared
{
    public interface ITheme
    {
        string TextColor { get; }
        string BgrColor { get; }
    }

    public class LightTheme : ITheme
    {
        public string TextColor => "black";
        public string BgrColor => "white";
    }

    public class DarkTheme : ITheme
    {
        public string TextColor => "white";
        public string BgrColor => "dark gray";
    }

    public class TrackingThemeFactory
    {
        private readonly List<WeakReference<ITheme>> themes = new();

        public ITheme CreateTheme(bool dark)
        {
            ITheme theme = dark ? new DarkTheme() : new LightTheme();
            themes.Add(new WeakReference<ITheme>(theme));
            return theme;
        }

        public string Info
        {
            get
            {
                var sb = new StringBuilder();
                foreach (var reference in themes)
                {
                    if (reference.TryGetTarget(out var theme))
                    {
                        bool dark = theme is DarkTheme;
                        sb.Append(dark ? "Dark" : "Light")
                            .AppendLine(" theme");
                    }
                }
                return sb.ToString();
            }
        }
    }

    // returning tracked themes as a reference instead
    public class ReplaceableThemeFactory
    {
        private readonly List<WeakReference<Ref<ITheme>>> themes 
            = new();

        private ITheme createThemeImpl(bool dark)
        {
            return dark ? new DarkTheme() : new LightTheme();
        }

        public Ref<ITheme> CreateTheme(bool dark)
        {
            var r = new Ref<ITheme>(createThemeImpl(dark));
            themes.Add(new(r));
            return r;
        }

        /// <summary>
        ///     this allows us to go through the reference to every theme given out by
        ///     the factory and adjust it
        ///
        ///     however, we are requiring developers to wrap their theme in a reference and now store the value of
        ///     the theme itself - the could do this by unwrapping the reference
        /// </summary>
        /// <param name="dark"></param>
        public void ReplaceTheme(bool dark)
        {
            foreach (var wr in themes)
            {
                if (wr.TryGetTarget(out var reference))
                {
                    reference.Value = createThemeImpl(dark);
                }
            }
        }
    }

    public class Ref<T> where T : class
    {
        public T Value;

        public Ref(T value)
        {
            Value=value;
        }
    }

    public class FactoryBenefits
    {
        public static void Demonstration()
        {
            Console.WriteLine("\nObject Tracking with Factory");
            var factory = new TrackingThemeFactory();
            var theme1 = factory.CreateTheme(false);
            var theme2 = factory.CreateTheme(true);
            Console.Write(factory.Info);

            Console.WriteLine("\nBulk Replacement with Factory");
            var factory2 = new ReplaceableThemeFactory();
            var magicTheme = factory2.CreateTheme(true);
            Console.WriteLine($"Theme Color: {magicTheme.Value.BgrColor}");
            factory2.ReplaceTheme(false);
            Console.WriteLine($"Theme Color After Replacement: {magicTheme.Value.BgrColor}");
        }
    }
}
