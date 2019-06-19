using System.Linq;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Lexicographic permutations
    /// </summary>
    public class Problem0024
    {
        private readonly int[] _number = new int[10];
        private int _counter;

        public object GetResult()
        {
            LoopDigit(0);

            long result = 0;
            foreach (int digit in _number)
                result = result * 10 + digit;

            return result;
        }

        private void LoopDigit(int level)
        {
            for (int i = 0; i < 10; i++)
            {
                if (_counter == 1000000)
                    break;
                
                if (_number.Take(level).Contains(i))
                    continue;

                _number[level] = i;

                if (level < 9)
                    LoopDigit(level + 1);
                else
                    _counter++;
            }
        }
    }
}