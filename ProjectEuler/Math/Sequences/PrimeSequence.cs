using System;
using System.Collections;
using System.Collections.Generic;
using ProjectEuler.Math.Primes;

namespace ProjectEuler.Math.Sequences
{
    public class PrimeSequence : IEnumerable<int>
    {
        public IEnumerator<int> GetEnumerator()
        {
            return new PrimeSequenceEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        private class PrimeSequenceEnumerator : IEnumerator<int>
        {
            //private readonly IEnumerator<int> _smallPrimesEnumerator = PrimeExtensions.SmallPrimes.GetEnumerator();

            public bool MoveNext()
            {
                //if (_smallPrimesEnumerator.MoveNext())
                //{
                //    Current = _smallPrimesEnumerator.Current;
                //    return true;
                //}

                Current++;
                while (!Current.IsPrime())
                    Current++;

                return true;
            }

            public void Reset()
            {
                Current = 2;
            }

            public int Current { get; private set; } = 1;

            object IEnumerator.Current => Current;

            public void Dispose()
            {
                //_smallPrimesEnumerator.Dispose();
            }
        }
    }
}