namespace ProjectEuler.Math.Sequences
{
    public class QuadraticSequence
    {
        private readonly decimal _a;
        private readonly decimal _b;
        private readonly decimal _c;

        /// <summary>
        ///     Initializes a new instance of <see cref="QuadraticSequence" /> class. The n-th term of the sequence is
        ///     <paramref name="a" />*n^2 + <paramref name="b" />*n + <paramref name="c" />.
        /// </summary>
        public QuadraticSequence(decimal a, decimal b, decimal c)
        {
            _a = a;
            _b = b;
            _c = c;
        }

        public decimal GetTerm(int x)
        {
            return _a * x * x + _b * x + _c;
        }

        public decimal GetSum(int x)
        {
            decimal a = _a * x * (x + 1) * (2 * x + 1) / 6;
            decimal b = _b * x * (x + 1) / 2;
            decimal c = _c * x;

            return a + b + c;
        }
    }
}