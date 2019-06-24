using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace ProjectEuler.Math.Primes
{
    public class FactorizedNumber : IReadOnlyList<PrimeFactor>, IEquatable<FactorizedNumber>
    {
        private readonly IList<PrimeFactor> _primeFactors;

        public FactorizedNumber(IEnumerable<PrimeFactor> primeFactors)
        {
            _primeFactors = new List<PrimeFactor>(primeFactors.OrderBy(x => x.Prime));
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

        public IEnumerator<PrimeFactor> GetEnumerator()
        {
            return _primeFactors.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int Count => _primeFactors.Count;

        public PrimeFactor this[int index] => _primeFactors[index];

        public int ToInt32()
        {
            return _primeFactors.Aggregate(1, (current, factor) => current * factor.ToInt32());
        }

        public long ToInt64()
        {
            return _primeFactors.Aggregate(1L, (current, factor) => current * factor.ToInt64());
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