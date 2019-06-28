using System;
using FluentAssertions;
using NUnit.Framework;
using ProjectEuler.Math;

namespace ProjectEuler.Tests.Math
{
    [TestFixture]
    public class FractionTests
    {
        [TestFixture]
        public class WhenInitializing
        {
            [TestFixture]
            public class AndDenominatorIsZero
            {
                [Test]
                public void ShouldThrow()
                {
                    Func<Fraction> f = () => new Fraction(1, 0);
                    f.Should().Throw<ArgumentOutOfRangeException>().Where(x => x.ParamName == "denominator");
                }
            }

            [TestFixture]
            public class AndDenominatorIsNonZero
            {
                [Test]
                public void ShouldSucceedWithNoSimplification()
                {
                    var f1 = new Fraction(2, 4);
                    f1.Numerator.Should().Be(2);
                    f1.Denominator.Should().Be(4);

                    var f2 = new Fraction(-2, 4);
                    f2.Numerator.Should().Be(-2);
                    f2.Denominator.Should().Be(4);

                    var f3 = new Fraction(2, -4);
                    f3.Numerator.Should().Be(2);
                    f3.Denominator.Should().Be(-4);

                    var f4 = new Fraction(-2, -4);
                    f4.Numerator.Should().Be(-2);
                    f4.Denominator.Should().Be(-4);

                    var f5 = new Fraction(0, 42);
                    f5.Numerator.Should().Be(0);
                    f5.Denominator.Should().Be(42);

                    var f6 = new Fraction(0, -42);
                    f6.Numerator.Should().Be(0);
                    f6.Denominator.Should().Be(-42);
                }
            }
        }

        [TestFixture]
        public class WhenComparingFractions
        {
            [Test]
            public void ShouldCompareCorrectly()
            {
                // same denominator
                new Fraction(1, 4).Should().BeLessThan(new Fraction(3, 4));
                new Fraction(2, 4).Should().Be(new Fraction(2, 4));
                new Fraction(3, 4).Should().BeGreaterThan(new Fraction(1, 4));
                new Fraction(-1, 4).Should().BeLessThan(new Fraction(0, 4));
                new Fraction(-1, -4).Should().BeGreaterThan(new Fraction(0, -4));

                (new Fraction(1, 4) < new Fraction(2, 4)).Should().BeTrue();
                (new Fraction(3, 4) < new Fraction(2, 4)).Should().BeFalse();
                (new Fraction(3, 4) > new Fraction(2, 4)).Should().BeTrue();
                (new Fraction(1, 4) > new Fraction(2, 4)).Should().BeFalse();

                // same value
                new Fraction(2, 4).Should().Be(new Fraction(4, 8));
                new Fraction(-2, 4).Should().Be(new Fraction(2, -4));
                new Fraction(2, -4).Should().Be(new Fraction(-4, 8));
                new Fraction(-2, -4).Should().Be(new Fraction(-4, -8));
                new Fraction(49, 98).Should().Be(new Fraction(4, 8));

                (new Fraction(2, 4) == new Fraction(4, 8)).Should().BeTrue();
                (new Fraction(2, 4) != new Fraction(5, 8)).Should().BeTrue();

                // different value
                new Fraction(2, 4).Should().BeGreaterThan(new Fraction(3, 7));
                new Fraction(5, 8).Should().BeLessThan(new Fraction(2, 3));
            }
        }

        [TestFixture]
        public class WhenComparingFractionToInt
        {
            [Test]
            public void ShouldCompareCorrectly()
            {
                // all positive
                new Fraction(1, 3).Should().BeLessThan(1);
                new Fraction(14, 7).Should().Be(2);
                new Fraction(17, 5).Should().BeGreaterThan(3);

                (new Fraction(1, 3) < 1).Should().BeTrue();
                (new Fraction(1, 3) > 1).Should().BeFalse();
                (new Fraction(1, 3) == 10).Should().BeFalse();
                (new Fraction(1, 3) != 10).Should().BeTrue();

                // negative numerator
                new Fraction(-1, 3).Should().BeLessThan(0);
                new Fraction(-14, 7).Should().Be(-2);
                new Fraction(-17, 5).Should().BeGreaterThan(-4);

                // negative denominator
                new Fraction(1, -3).Should().BeLessThan(0);
                new Fraction(14, -7).Should().Be(-2);
                new Fraction(17, -5).Should().BeGreaterThan(-4);

                // negative numerator and denominator
                new Fraction(-1, -3).Should().BeLessThan(1);
                new Fraction(-14, -7).Should().Be(2);
                new Fraction(-17, -5).Should().BeGreaterThan(3);
            }
        }

        [TestFixture]
        public class WhenSimplifyingFraction
        {
            [Test]
            public void ShouldCorrectlySimplify()
            {
                Fraction f1 = new Fraction(4, 8).Simplify();
                f1.Numerator.Should().Be(1);
                f1.Denominator.Should().Be(2);

                Fraction f2 = new Fraction(-4, 8).Simplify();
                f2.Numerator.Should().Be(-1);
                f2.Denominator.Should().Be(2);

                Fraction f3 = new Fraction(8, -4).Simplify();
                f3.Numerator.Should().Be(-2);
                f3.Denominator.Should().Be(1);
            }
        }

        [TestFixture]
        public class Constants
        {
            [TestFixture]
            public class Zero
            {
                [Test]
                public void ShouldHaveNumeratorZero()
                {
                    Fraction.Zero.Numerator.Should().Be(0);
                }

                [Test]
                public void ShouldHaveDenominatorOne()
                {
                    Fraction.Zero.Denominator.Should().Be(1);
                }
            }

            [TestFixture]
            public class One
            {
                [Test]
                public void ShouldHaveNumeratorOne()
                {
                    Fraction.One.Numerator.Should().Be(1);
                }

                [Test]
                public void ShouldHaveDenominatorOne()
                {
                    Fraction.One.Denominator.Should().Be(1);
                }
            }
        }

        [TestFixture]
        public class WhenMultiplyingFractions
        {
            [Test]
            public void ShouldMultiplyCorrectly()
            {
                (new Fraction(3, 5) * 0).Should().Be(0);
                (new Fraction(-3, 5) * 0).Should().Be(0);
                (new Fraction(3, -5) * 0).Should().Be(0);

                (new Fraction(3, 5) * 1).Should().Be(new Fraction(3, 5));
                (new Fraction(-3, 5) * 1).Should().Be(new Fraction(-3, 5));
                (new Fraction(3, -5) * 1).Should().Be(new Fraction(-3, 5));

                (new Fraction(3, 5) * new Fraction(5, 3)).Should().Be(1);

                (new Fraction(3, 5) * new Fraction(2, 7)).Should().Be(new Fraction(6, 35));
                (new Fraction(30, 50) * new Fraction(1, 2)).Should().Be(new Fraction(3, 10));
            }
        }
    }
}