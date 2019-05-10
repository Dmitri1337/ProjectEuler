using System;

namespace ProjectEuler.Math
{
    public class ArithmeticProgression
    {
        private readonly decimal _commonDifference;
        private readonly decimal _initialTerm;

        public ArithmeticProgression(decimal initialTerm, decimal commonDifference)
        {
            _commonDifference = commonDifference;
            _initialTerm = initialTerm;
        }

        public decimal GetTerm(int termIndex)
        {
            if (termIndex <= 0)
                throw new ArgumentOutOfRangeException(nameof(termIndex), "Must be greater than zero.");

            return _initialTerm + _commonDifference * (termIndex - 1);
        }

        public decimal GetSum(int termsCount)
        {
            if (termsCount <= 0)
                throw new ArgumentOutOfRangeException(nameof(termsCount), "Must be greater than zero.");

            return termsCount * (_initialTerm + GetTerm(termsCount)) / 2;
        }
    }
}