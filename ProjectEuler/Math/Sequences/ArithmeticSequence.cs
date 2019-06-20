namespace ProjectEuler.Math.Sequences
{
    public class ArithmeticSequence
    {
        private readonly long _commonDifference;
        private readonly long _initialTerm;

        public ArithmeticSequence(long initialTerm, long commonDifference)
        {
            _commonDifference = commonDifference;
            _initialTerm = initialTerm;
        }

        public long GetTerm(int termIndex)
        {
            return _initialTerm + _commonDifference * (termIndex - 1);
        }

        public long GetSum(int termsCount)
        {
            return termsCount * (_initialTerm + GetTerm(termsCount)) / 2;
        }
    }
}