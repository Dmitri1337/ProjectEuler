using System;
using System.Collections;

namespace ProjectEuler.Math.Primes
{
    internal class EratosthenesSieve
    {
        private readonly BitArray _sieve;
        private readonly int _sieveCapacity;

        private int _sieveSize;

        public EratosthenesSieve(int sieveCapacity)
        {
            if (sieveCapacity <= 0)
                throw new ArgumentNullException(nameof(sieveCapacity), "Must be greater than zero.");

            _sieveCapacity = sieveCapacity;
            _sieve = new BitArray(sieveCapacity, true) { [0] = false, [1] = false };
            _sieveSize = 2;
        }

        public bool IsPrime(int x)
        {
            if (x < 0)
                x = -x;

            if (x >= _sieveCapacity)
                throw new ArgumentOutOfRangeException(nameof(x),
                    $"Must be less than the specified sieve capacity ({_sieveCapacity})");

            if (x >= _sieveSize)
                ExpandSieve(x);

            return _sieve[x];
        }

        private void ExpandSieve(int newSieveSize)
        {
            while (_sieveSize < newSieveSize)
            {
                if (_sieve[_sieveSize])
                    for (int i = _sieveSize * 2; i < _sieveCapacity; i += _sieveSize)
                        _sieve[i] = false;

                _sieveSize++;
            }
        }
    }
}