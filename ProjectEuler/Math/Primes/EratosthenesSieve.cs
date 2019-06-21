using System;
using System.Collections;

namespace ProjectEuler.Math.Primes
{
    internal class EratosthenesSieve
    {
        private readonly BitArray _sieve;
        private readonly int _sieveCapacity;
        private readonly int _sieveCapacitySquareRoot;

        private int _lastProcessedNumber;
        

        public EratosthenesSieve(int sieveCapacity)
        {
            if (sieveCapacity <= 0)
                throw new ArgumentNullException(nameof(sieveCapacity), "Must be greater than zero.");

            _sieveCapacity = sieveCapacity;
            _sieveCapacitySquareRoot = sieveCapacity.GetIntegerSquareRoot() + 1;

            _sieve = new BitArray(sieveCapacity, true) { [0] = false, [1] = false };
            _lastProcessedNumber = 1;
        }

        public bool IsPrime(int x)
        {
            if (x < 0)
                x = -x;

            if (x >= _sieveCapacity)
                throw new ArgumentOutOfRangeException(nameof(x),
                    $"Must be less than the specified sieve capacity ({_sieveCapacity})");

            if (x > _lastProcessedNumber)
                SieveNumbersUpTo(x);

            return _sieve[x];
        }

        private void SieveNumbersUpTo(int x)
        {
            while (_lastProcessedNumber < x)
            {
                int nextNumber = _lastProcessedNumber + 1;

                if (_sieve[nextNumber])
                    for (int i = nextNumber * 2; i < _sieveCapacity; i += nextNumber)
                        _sieve[i] = false;

                _lastProcessedNumber++;
            }

            if (_lastProcessedNumber >= _sieveCapacitySquareRoot)
                _lastProcessedNumber = _sieveCapacity;
        }
    }
}