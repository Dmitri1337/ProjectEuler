using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using ProjectEuler.Math;

namespace ProjectEuler.Tests.Math
{
    [TestFixture]
    public class PrimesTests
    {
        [TestFixture]
        public class WhenCheckingForPrimality
        {
            [TestFixture]
            public class AndNumberIsZero
            {
                [Test]
                public void ShouldReturnFalse()
                {
                    0.IsPrime().Should().BeFalse();
                }
            }

            [TestFixture]
            public class AndNumberIsOne
            {
                [Test]
                public void ShouldReturnFalse()
                {
                    1.IsPrime().Should().BeFalse();
                }
            }

            [TestFixture]
            public class AndNumberIsPrime
            {
                [Test]
                public void ShouldReturnTrue()
                {
                    2.IsPrime().Should().BeTrue();
                    3.IsPrime().Should().BeTrue();
                    5.IsPrime().Should().BeTrue();
                    7.IsPrime().Should().BeTrue();
                    11.IsPrime().Should().BeTrue();
                    13.IsPrime().Should().BeTrue();
                    17.IsPrime().Should().BeTrue();
                }
            }

            [TestFixture]
            public class AndNumberIsNonPrime
            {
                [Test]
                public void ShouldReturnFalse()
                {
                    4.IsPrime().Should().BeFalse();
                    6.IsPrime().Should().BeFalse();
                    8.IsPrime().Should().BeFalse();
                    9.IsPrime().Should().BeFalse();
                    10.IsPrime().Should().BeFalse();
                    12.IsPrime().Should().BeFalse();
                    14.IsPrime().Should().BeFalse();
                }
            }

            [TestFixture]
            public class AndNumberIsOneMillion
            {
                [Test]
                public void ShouldReturnFalse()
                {
                    1000000.IsPrime().Should().BeFalse();
                }
            }

            [TestFixture]
            public class AndNumberIsLargerThanTwoMillion
            {
                [Test]
                public void ShouldThrow()
                {
                    Func<bool> f = () => 2000001.IsPrime();

                    f.Should().Throw<ArgumentOutOfRangeException>();
                }
            }
        }

        [TestFixture]
        public class WhenFactorizing
        {
            [TestFixture]
            public class AndNumberIsNegative
            {
                [Test]
                public void ShouldThrow()
                {
                    Func<IEnumerable<PrimePower>> f = () => Primes.Factorize(-3);
                    f.Should().Throw<ArgumentOutOfRangeException>();
                }
            }

            [TestFixture]
            public class AndNumberIsZero
            {
                [Test]
                public void ShouldThrow()
                {
                    Func<IEnumerable<PrimePower>> f = () => Primes.Factorize(0);
                    f.Should().Throw<ArgumentOutOfRangeException>();
                }
            }

            [TestFixture]
            public class AndNumberIsOne
            {
                [Test]
                public void ShouldThrow()
                {
                    Func<IEnumerable<PrimePower>> f = () => Primes.Factorize(1);
                    f.Should().Throw<ArgumentOutOfRangeException>();
                }
            }

            [TestFixture]
            public class AndNumberIsPrime
            {
                [Test]
                public void ShouldReturnWithPowerOne()
                {
                    PrimePower[] primePowers = Primes.Factorize(13).ToArray();

                    primePowers.Length.Should().Be(1);
                    primePowers[0].Prime.Should().Be(13);
                    primePowers[0].Power.Should().Be(1);
                }
            }

            [TestFixture]
            public class AndNumberIsNonPrime
            {
                [Test]
                public void ShouldReturnPrimePowerCollection()
                {
                    PrimePower[] primePowers = Primes.Factorize(369).ToArray();

                    primePowers.Length.Should().Be(2);

                    primePowers[0].Prime.Should().Be(3);
                    primePowers[0].Power.Should().Be(2);

                    primePowers[1].Prime.Should().Be(41);
                    primePowers[1].Power.Should().Be(1);
                }
            }

            [TestFixture]
            public class AndNumberIsOneMillion
            {
                [Test]
                public void ShouldSucceed()
                {
                    Primes.Factorize(1000000).Should().NotBeEmpty();
                }
            }
        }
    }
}