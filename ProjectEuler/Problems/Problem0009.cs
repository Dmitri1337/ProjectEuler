namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Special Pythagorean triplet
    /// </summary>
    public class Problem0009
    {
        public object GetResult()
        {
            // the result can also be calculated using Wolfram Alpha:
            // https://www.wolframalpha.com/input/?i=a%5E2+%2B+b%5E2+%3D+c%5E2;+a%2Bb%2Bc+%3D+1000;+a%3E0;+b%3E0;+c%3E0;+a+%3C+b+%3Cc

            for (int a = 1; a <= 500; a++)
            {
                int dividend = 1000 * (a - 500);
                int divider = a - 1000;

                if (dividend % divider != 0)
                    continue;

                int b = dividend / divider;
                if (b <= 0 || a >= b)
                    continue;

                int c = 1000 - a - b;
                if (c <= 0 || c <= a || c <= b)
                    continue;

                if (a * a + b * b == c * c)
                    return a * b * c;
            }

            return "Fail to find value.";
        }
    }
}