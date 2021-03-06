﻿namespace ProjectEuler.Math.Sequences
{
    public class QuadraticSequence
    {
        private readonly long _a;
        private readonly long _b;
        private readonly long _c;

        /// <summary>
        ///     Initializes a new instance of <see cref="QuadraticSequence" /> class. The n-th term of the sequence is
        ///     <paramref name="a" />*n^2 + <paramref name="b" />*n + <paramref name="c" />.
        /// </summary>
        public QuadraticSequence(long a, long b, long c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        public long GetTerm(int x)
        {
            return _a * x * x + _b * x + _c;
        }

        public long GetSum(int x)
        {
            long a = _a * x * (x + 1) * (2 * x + 1) / 6;
            long b = _b * x * (x + 1) / 2;
            long c = _c * x;

            return a + b + c;
        }
    }
}