using System;

namespace ProjectEuler.Math
{
    public struct Fraction : IComparable<Fraction>
    {
        public static Fraction Zero { get; } = new Fraction(0, 1);
        public static Fraction One { get; } = new Fraction(1, 1);

        public bool Equals(Fraction other)
        {
            return CompareTo(other) == 0;
        }

        public override bool Equals(object obj)
        {
            return obj is Fraction other && Equals(other);
        }

        public override int GetHashCode()
        {
            unchecked
            {
                return (Numerator * 397) ^ Denominator;
            }
        }

        public int Numerator { get; }
        public int Denominator { get; }

        public Fraction(int numerator, int denominator)
        {
            if (denominator == 0)
                throw new ArgumentOutOfRangeException(nameof(denominator), "Cannot be zero.");

            Numerator = numerator;
            Denominator = denominator;
        }

        public Fraction Simplify()
        {
            int n = Numerator;
            int d = Denominator;

            if (n == 0)
                return new Fraction(0, 1);

            if (d < 0)
            {
                d = -d;
                n = -n;
            }

            while (true)
            {
                int gcd = XXMath.GreatestCommonDivisor(n, d);
                if (gcd == 1)
                    break;

                n /= gcd;
                d /= gcd;
            }

            return new Fraction(n, d);
        }

        public int CompareTo(Fraction other)
        {
            if (Denominator > 0 && Denominator == other.Denominator)
                return Numerator.CompareTo(other.Numerator);

            if (Denominator < 0 && Denominator == other.Denominator)
                return -Numerator.CompareTo(other.Numerator);

            long leftDenominatorSign = Denominator < 0 ? -1 : 1;
            long rightDenominatorSign = other.Denominator < 0 ? -1 : 1;
            long sign = leftDenominatorSign * rightDenominatorSign;

            long leftNumerator = sign * Numerator * other.Denominator;
            long rightNumerator = sign * other.Numerator * Denominator;

            return leftNumerator.CompareTo(rightNumerator);
        }

        public override string ToString()
        {
            return $"({Numerator} / {Denominator})";
        }

        public static implicit operator Fraction(int number)
        {
            return new Fraction(number, 1);
        }

        public static Fraction operator *(Fraction a, Fraction b)
        {
            return new Fraction(a.Numerator * b.Numerator, a.Denominator * b.Denominator).Simplify();
        }

        #region Comparing Fraction with other Fraction

        public static bool operator <(Fraction left, Fraction right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Fraction left, Fraction right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator ==(Fraction left, Fraction right)
        {
            return left.CompareTo(right) == 0;
        }

        public static bool operator !=(Fraction left, Fraction right)
        {
            return left.CompareTo(right) != 0;
        }

        #endregion // Comparing Fraction with other Fraction

        #region Compare Fraction with Int32

        public static bool operator <(Fraction left, int right)
        {
            return left.CompareTo(right) < 0;
        }

        public static bool operator >(Fraction left, int right)
        {
            return left.CompareTo(right) > 0;
        }

        public static bool operator ==(Fraction left, int right)
        {
            return left.CompareTo(right) == 0;
        }

        public static bool operator !=(Fraction left, int right)
        {
            return left.CompareTo(right) != 0;
        }

        #endregion Compare Fraction with Int32
    }
}