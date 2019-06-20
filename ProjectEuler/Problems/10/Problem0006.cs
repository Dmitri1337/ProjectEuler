using ProjectEuler.Math;
using ProjectEuler.Math.Sequences;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Sum square difference
    /// </summary>
    public class Problem0006
    {
        public object GetResult()
        {
            const int termCount = 100;

            long sumOfSquares = new QuadraticSequence(1, 0, 0).GetSum(termCount);
            long squareOfSum = new ArithmeticSequence(1, 1).GetSum(termCount).Square();

            long result = squareOfSum - sumOfSquares;

            return result;
        }
    }
}