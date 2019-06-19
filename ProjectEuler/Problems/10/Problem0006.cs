namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Sum square difference
    /// </summary>
    public class Problem0006
    {
        public object GetResult()
        {
            int sumOfSquares = 0;
            int sum = 0;

            for (int n = 1; n <= 100; n++)
            {
                sum += n;
                sumOfSquares += n * n;
            }

            int squareOfSum = sum * sum;

            return squareOfSum - sumOfSquares;
        }
    }
}