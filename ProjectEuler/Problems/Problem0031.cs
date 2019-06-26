using ProjectEuler.Math;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Coin sums
    /// </summary>
    public class Problem0031
    {
        public object GetResult()
        {
            return new LinearDiophantineEquation(new[] { 200, 100, 50, 20, 10, 5, 2, 1 }, 200)
                .GetIntegerSolutionsCount();
        }
    }
}