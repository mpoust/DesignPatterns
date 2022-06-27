/*
 * Exercise for Section 21 - Strategy Coding Exercise
 *
 * Quadratic equation.
 *
 * Consider the discriminant b^2-4*a*c. Provide an API with two different ways to calculate the discriminant.
 *
 * 1.   In OrdinaryDiscriminantStrategy, if the discriminant is negative, we return it as-is. This is Ok, since our
 *      primary API returns Complex numbers anyway.
 *
 * 2.   In RealDiscriminantStrategy, if the discriminant is negative, the return value is NaN.
 *      NaN propagates throughout the calculation, so the equation solver gives two NaN values.
 *
 */

using System.Numerics;

namespace DesignPatterns.Behavioral
{
    public interface IDiscriminantStrategy
    {
        double CalculateDiscriminant(double a, double b, double c);
    }

    public class OrdinaryDiscriminantStrategy : IDiscriminantStrategy
    {
        public double CalculateDiscriminant(double a, double b, double c)
        {
            return b * b - 4 * a * c;
        }
    }

    public class RealDiscriminantStrategy : IDiscriminantStrategy
    {
        public double CalculateDiscriminant(double a, double b, double c)
        {
            var result = b * b - 4 * a * c;
            return result >= 0 ? result : double.NaN;
        }
    }

    public class QuadraticEquationSolver
    {
        private readonly IDiscriminantStrategy strategy;

        public QuadraticEquationSolver(IDiscriminantStrategy strategy)
        {
            this.strategy = strategy;
        }

        public Tuple<Complex, Complex> Solve(double a, double b, double c)
        {
            var disc = new Complex(strategy.CalculateDiscriminant(a, b, c), 0);
            var rootDisc = Complex.Sqrt(disc);
            return Tuple.Create(
                (-b + rootDisc) / (2 * a),
                (-b - rootDisc) / (2 * a)
            );
        }
    }

    public class Exercise21_Strategy_Quadratic
    {
    }
}