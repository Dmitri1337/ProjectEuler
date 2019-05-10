using ProjectEuler.Math;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Largest palindrome product
    /// </summary>
    public class Problem0004
    {
        public object GetResult()
        {
            int max = 0;

            for (int left = 100; left <= 999; left++)
            for (int right = left; right <= 999; right++)
            {
                int product = left * right;
                if (product > max && Palindromes.IsPalindrome(product))
                    max = product;
            }

            return max;
        }
    }
}