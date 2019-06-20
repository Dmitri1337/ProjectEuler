using ProjectEuler.Math.Sequences;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Number spiral diagonals
    /// </summary>
    public class Problem0028
    {
        public object GetResult()
        {
            const int squareSize = 1001;
            const int numberOfInnerSquares = squareSize / 2;

            return new QuadraticSequence(16, 4, 4).GetSum(numberOfInnerSquares) + 1;
        }
    }
}