using ProjectEuler.Math;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Digit factorials
    /// </summary>
    public class Problem0034
    {
        public object GetResult()
        {
            int nineFactorial = (int)9.GetFactorial();

            int maxNumber = 9;
            int maxNumberFactorial = nineFactorial;

            while (maxNumber < maxNumberFactorial)
            {
                maxNumber = maxNumber * 10 + 9;
                maxNumberFactorial += nineFactorial;
            }

            int result = 0;

            for (int i = 3; i <= maxNumber; i++)
            {
                int iDigitFactorial = 0;

                int iCopy = i;
                while (iCopy > 0)
                {
                    int digit = iCopy % 10;
                    iDigitFactorial += (int)digit.GetFactorial();

                    iCopy /= 10;
                }

                if (i == iDigitFactorial)
                    result += i;
            }

            return result;
        }
    }
}