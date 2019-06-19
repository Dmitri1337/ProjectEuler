using System.Collections.Generic;

namespace ProjectEuler.Problems
{
    /// <summary>
    ///     Longest Collatz sequence
    /// </summary>
    public class Problem0014
    {
        private readonly IDictionary<long, long> _collatzSequenceLengths = new SortedDictionary<long, long>();

        public object GetResult()
        {
            _collatzSequenceLengths.Add(1, 1);
            long maxCollatzSequenceLength = 1;
            long maxCollatzSequenceStartingNumber = 1;

            for (long n = 2; n < 1000000; n++)
            {
                long collatzSequenceLength = GetCollatzSequenceLength(n);

                if (collatzSequenceLength <= maxCollatzSequenceLength)
                    continue;

                maxCollatzSequenceLength = collatzSequenceLength;
                maxCollatzSequenceStartingNumber = n;
            }

            return maxCollatzSequenceStartingNumber;
        }

        private long GetCollatzSequenceLength(long collatzSequenceStartingNumber)
        {
            if (_collatzSequenceLengths.TryGetValue(collatzSequenceStartingNumber, out long collatzSequenceLength))
                return collatzSequenceLength;

            long nextCollatzSequenceNumber = collatzSequenceStartingNumber % 2 == 0
                ? collatzSequenceStartingNumber / 2
                : collatzSequenceStartingNumber * 3 + 1;

            collatzSequenceLength = 1 + GetCollatzSequenceLength(nextCollatzSequenceNumber);
            _collatzSequenceLengths.Add(collatzSequenceStartingNumber, collatzSequenceLength);

            return collatzSequenceLength;
        }
    }
}