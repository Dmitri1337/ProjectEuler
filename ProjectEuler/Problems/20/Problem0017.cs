using System.Linq;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Number letter counts
    /// </summary>
    public class Problem0017
    {
        private readonly string[] _word10 =
        {
            "", "", "twenty", "thirty", "forty", "fifty", "sixty", "seventy", "eighty", "ninety"
        };

        private readonly string[] _word19 =
        {
            "", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve",
            "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen"
        };

        public object GetResult()
        {
            return Enumerable.Range(1, 1000)
                .Select(GetNumberLetterCount)
                .Sum();
        }

        private int GetNumberLetterCount(int number)
        {
            string numberInWords = GetNumberInWords(number);

            return numberInWords
                .Replace(" ", "")
                .Replace("-", "")
                .Length;
        }

        private string GetNumberInWords(int number)
        {
            if (number == 1000)
                return "one thousand";

            string hundred = GetHundredString(number);
            string teen = GetTeenString(number);

            string result = hundred;
            if (hundred != "" && teen != "")
                result += " and ";

            if (teen != "")
                result += teen;

            return result;
        }

        private string GetTeenString(int number)
        {
            int teen = number % 100;

            if (teen <= 19)
                return _word19[teen];

            string tens = GetTensString(number);
            string singles = GetSinglesString(number);

            return $"{tens}-{singles}".Trim('-');
        }

        private string GetSinglesString(int number)
        {
            int singles = number % 10;
            return _word19[singles];
        }

        private string GetTensString(int number)
        {
            int tens = number / 10 % 10;
            return _word10[tens];
        }

        private string GetHundredString(int n)
        {
            int hundred = n / 100;
            return hundred > 0 ? _word19[hundred] + " hundred" : "";
        }
    }
}