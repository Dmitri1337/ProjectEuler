using ProjectEuler.Math.Sequences;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Multiples of 3 and 5
    /// </summary>
    public class Problem0001
    {
        public object GetResult()
        {
            const int max = 1000;

            const int threesCount = (max - 1) / 3;
            const int fivesCount = (max - 1) / 5;
            const int fifteensCount = (max - 1) / (3 * 5);

            var threes = new ArithmeticSequence(3, 3);
            var fives = new ArithmeticSequence(5, 5);
            var fifteens = new ArithmeticSequence(15, 15);

            return (int)(threes.GetSum(threesCount) + fives.GetSum(fivesCount) - fifteens.GetSum(fifteensCount));
        }
    }
}