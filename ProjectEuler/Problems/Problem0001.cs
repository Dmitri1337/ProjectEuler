using ProjectEuler.Math;

namespace ProjectEuler.Problems
{
    public class Problem0001 : IProblem
    {
        public object GetResult()
        {
            const int max = 1000;

            const int threesCount = (max - 1) / 3;
            const int fivesCount = (max - 1) / 5;
            const int fifteensCount = (max - 1) / (3 * 5);

            var threes = new ArithmeticProgression(3, 3);
            var fives = new ArithmeticProgression(5, 5);
            var fifteens = new ArithmeticProgression(15, 15);

            return (int)(threes.GetSum(threesCount) + fives.GetSum(fivesCount) - fifteens.GetSum(fifteensCount));
        }
    }
}