namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Coin sums
    /// </summary>
    public class Problem0031
    {
        public object GetResult()
        {
            int result = 1;

            for (int d100 = 0; d100 <= 200; d100 += 100)
            for (int d050 = 0; d100 + d050 <= 200; d050 += 50)
            for (int d020 = 0; d100 + d050 + d020 <= 200; d020 += 20)
            for (int d010 = 0; d100 + d050 + d020 + d010 <= 200; d010 += 10)
            for (int d005 = 0; d100 + d050 + d020 + d010 + d005 <= 200; d005 += 5)
            for (int d002 = 0; d100 + d050 + d020 + d010 + d005 + d002 <= 200; d002 += 2)
                result++;

            return result;
        }
    }
}