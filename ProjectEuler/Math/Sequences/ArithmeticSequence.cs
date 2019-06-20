namespace ProjectEuler.Math.Sequences
{
    public class ArithmeticSequence
    {
        private readonly decimal _commonDifference;
        private readonly decimal _initialTerm;

        public ArithmeticSequence(decimal initialTerm, decimal commonDifference)
        {
            _commonDifference = commonDifference;
            _initialTerm = initialTerm;
        }

        public decimal GetTerm(int termIndex)
        {
            return _initialTerm + _commonDifference * (termIndex - 1);
        }

        public decimal GetSum(int termsCount)
        {
            return termsCount * (_initialTerm + GetTerm(termsCount)) / 2;
        }
    }
}