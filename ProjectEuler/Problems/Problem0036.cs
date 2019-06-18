using System.Linq;
using ProjectEuler.Math;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Double-base palindromes
    /// </summary>
    public class Problem0036
    {
        public object GetResult()
        {
            const int max = 100000000;

            return Enumerable.Range(0, max)
                .Where(x => Palindromes.IsPalindrome(x, 2) && Palindromes.IsPalindrome(x))
                .Sum();
        }
    }
}