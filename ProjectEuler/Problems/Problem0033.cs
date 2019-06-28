using System.Collections.Generic;
using System.Linq;
using ProjectEuler.Math;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Digit cancelling fractions
    /// </summary>
    public class Problem0033
    {
        public object GetResult()
        {
            Fraction[] fractions = GetFractions()
                .Where(x => x < 1)
                .Where(x => x.Numerator >= 10 && x.Denominator >= 10)
                .Where(x => x.Numerator % 10 != 0 || x.Denominator % 10 != 0)
                .ToArray();

            Fraction result = 1;

            foreach (Fraction fraction in fractions)
            {
                int numeratorDigit1 = fraction.Numerator / 10;
                int numeratorDigit2 = fraction.Numerator % 10;

                int denominatorDigit1 = fraction.Denominator / 10;
                int denominatorDigit2 = fraction.Denominator % 10;

                Fraction simplifiedFraction = Fraction.Zero;

                if (numeratorDigit1 == denominatorDigit1 && denominatorDigit2 != 0)
                    simplifiedFraction = new Fraction(numeratorDigit2, denominatorDigit2);
                else if (numeratorDigit1 == denominatorDigit2)
                    simplifiedFraction = new Fraction(numeratorDigit2, denominatorDigit1);
                if (numeratorDigit2 == denominatorDigit1 && denominatorDigit2 != 0)
                    simplifiedFraction = new Fraction(numeratorDigit1, denominatorDigit2);
                else if (numeratorDigit2 == denominatorDigit2)
                    simplifiedFraction = new Fraction(numeratorDigit1, denominatorDigit1);

                if (fraction == simplifiedFraction)
                    result *= simplifiedFraction;
            }

            return result.Simplify().Denominator;
        }

        private static IEnumerable<Fraction> GetFractions()
        {
            for (int denominator = 1; denominator <= 99; denominator++)
            for (int numerator = 1; numerator < 99; numerator++)
                yield return new Fraction(numerator, denominator);
        }
    }
}