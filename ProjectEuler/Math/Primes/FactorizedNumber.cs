using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Math.Primes
{
    public class FactorizedNumber : IEnumerable<PrimeFactor>, IEquatable<FactorizedNumber>
    {
        private readonly IList<PrimeFactor> _primeFactors;

        public FactorizedNumber(IEnumerable<PrimeFactor> primeFactors)
        {
            _primeFactors = new List<PrimeFactor>(primeFactors.OrderBy(x => x.Prime));
        }

        public IEnumerator<PrimeFactor> GetEnumerator()
        {
            return _primeFactors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public bool Equals(FactorizedNumber other)
        {
            if (other is null)
                return false;

            if (ReferenceEquals(this, other))
                return true;

            if (_primeFactors.Count != other._primeFactors.Count)
                return false;

            for (int i = 0; i < _primeFactors.Count; i++)
                if (_primeFactors[i] != other._primeFactors[i])
                    return false;

            return true;
        }

        public FactorizedNumber Power(int power)
        {
            IEnumerable<PrimeFactor> newPrimeFactors =
                _primeFactors.Select(x => new PrimeFactor(x.Prime, x.Exponent * power));

            return new FactorizedNumber(newPrimeFactors);
        }

        public override bool Equals(object obj)
        {
            if (obj is null)
                return false;

            if (ReferenceEquals(this, obj))
                return true;

            if (obj.GetType() != GetType())
                return false;

            return Equals((FactorizedNumber)obj);
        }

        public override int GetHashCode()
        {
            return _primeFactors != null ? _primeFactors.GetHashCode() : 0;
        }
    }
}