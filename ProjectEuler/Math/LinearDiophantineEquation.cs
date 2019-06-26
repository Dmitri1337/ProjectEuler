using System;

namespace ProjectEuler.Math
{
    public class LinearDiophantineEquation
    {
        private readonly int[] _a;
        private readonly int _d;

        /// <summary>
        ///     Initializes a new instance of <see cref="LinearDiophantineEquation" /> of the form <paramref name="a[0]" />*x[0] +
        ///     <paramref name="a[1]" />*x[1] + ... + <paramref name="a[n]" /> * x[n] = <paramref name="d" />.
        /// </summary>
        public LinearDiophantineEquation(int[] a, int d)
        {
            _a = a ?? throw new ArgumentNullException(nameof(a));
            _d = d;
        }

        /// <summary>
        ///     Counts the number of integer solutions.
        /// </summary>
        public int GetIntegerSolutionsCount()
        {
            var counts = new int[_d + 1];
            counts[0] = 1;

            foreach (int coefficient in _a)
                for (int countsIndex = coefficient; countsIndex <= _d; countsIndex++)
                    counts[countsIndex] = counts[countsIndex] + counts[countsIndex - coefficient];

            return counts[_d];
        }
    }
}