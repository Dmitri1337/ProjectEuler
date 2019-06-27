using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Pandigital products
    /// </summary>
    public class Problem0032
    {
        public object GetResult()
        {
            var results = new List<long>();

            for (int a = 1; a <= 9876; a++)
            {
                string aStr = a.ToString();
                if (aStr.Contains('0'))
                    continue;

                for (int b = 1; b <= 9876; b++)
                {
                    string bStr = b.ToString();
                    if (bStr.Contains('0'))
                        continue;

                    int mul = a * b;
                    string mulStr = mul.ToString();
                    if (mulStr.Contains('0'))
                        continue;

                    string s = $"{aStr}{bStr}{mulStr}";
                    if (s.Length != 9)
                        continue;

                    if (s.Distinct().Count() == 9)
                        results.Add(mul);
                }
            }

            return results.Distinct().Sum();
        }
    }
}