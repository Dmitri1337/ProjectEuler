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
            public class AndNumberIsNegative
            {
                [Test]
                public void ShouldReturnFalse()
                {
                    Primes.IsPrime(-3).Should().BeFalse();
                }
            }

            [TestFixture]
            public class AndNumberIsZero
            {
                [Test]
                public void ShouldReturnFalse()
                {
                    Primes.IsPrime(0).Should().BeFalse();
                }
            }

            [TestFixture]
            public class AndNumberIsOne
            {
                [Test]
                public void ShouldReturnFalse()
                {
                    Primes.IsPrime(1).Should().BeFalse();
                }
            }

            [TestFixture]
            public class AndNumberIsPrime
            {
                [Test]
                public void ShouldReturnTrue()
                {
                    Primes.IsPrime(2).Should().BeTrue();
                    Primes.IsPrime(3).Should().BeTrue();
                    Primes.IsPrime(5).Should().BeTrue();
                    Primes.IsPrime(7).Should().BeTrue();
                    Primes.IsPrime(11).Should().BeTrue();
                    Primes.IsPrime(13).Should().BeTrue();
                    Primes.IsPrime(17).Should().BeTrue();
                }
            }

            [TestFixture]
            public class AndNumberIsNonPrime
            {
                [Test]
                public void ShouldReturnFalse()
                {
                    Primes.IsPrime(4).Should().BeFalse();
                    Primes.IsPrime(6).Should().BeFalse();
                    Primes.IsPrime(8).Should().BeFalse();
                    Primes.IsPrime(9).Should().BeFalse();
                    Primes.IsPrime(10).Should().BeFalse();
                    Primes.IsPrime(12).Should().BeFalse();
                    Primes.IsPrime(14).Should().BeFalse();
                }
            }

            [TestFixture]
            public class AndNumberIsOneMillion
            {
                [Test]
                public void ShouldReturnFalse()
                {
                    Primes.IsPrime(1000000).Should().BeFalse();
                }
            }

            [TestFixture]
            public class AndNumberIsLargerThanTwoMillion
            {
                [Test]
                public void ShouldThrow()
                {
                    Func<bool> f = () => Primes.IsPrime(2000001);

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

            [TestFixture]
            public class AndNumberIsLargerThanTwoMillion
            {
                [Test]
                public void ShouldThrow()
                {
                    Func<IEnumerable<PrimePower>> f = () => Primes.Factorize(2000001);

                    f.Should().Throw<ArgumentOutOfRangeException>();
                }
            }
        }
    }
}