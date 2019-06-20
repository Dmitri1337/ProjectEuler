using System.Linq;
using ProjectEuler.Math;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Factorial digit sum
    /// </summary>
    public class Problem0020
    {
        public object GetResult()
        {
            return 100.GetFactorial().ToString().Select(x => x - 48).Sum();
        }
    }
}