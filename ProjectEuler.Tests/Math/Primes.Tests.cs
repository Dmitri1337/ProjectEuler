using System;
using FluentAssertions;
using NUnit.Framework;
using ProjectEuler.Math;

namespace ProjectEuler.Tests.Math
{
    [TestFixture]
    public class PrimesTests
    {
        [TestFixture]
        public class WhenCheckingNegativeNumber
        {
            [Test]
            public void ShouldReturnFalse()
            {
                Primes.IsPrime(-3).Should().BeFalse();
            }
        }

        [TestFixture]
        public class WhenCheckingZero
        {
            [Test]
            public void ShouldReturnFalse()
            {
                Primes.IsPrime(0).Should().BeFalse();
            }
        }

        [TestFixture]
        public class WhenCheckingOne
        {
            [Test]
            public void ShouldReturnFalse()
            {
                Primes.IsPrime(1).Should().BeFalse();
            }
        }

        [TestFixture]
        public class WhenCheckingPrime
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
        public class WhenCheckingNonPrime
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
        public class WhenCheckingOneMillion
        {
            [Test]
            public void ShouldReturnFalse()
            {
                Primes.IsPrime(1000000).Should().BeFalse();
            }
        }

        [TestFixture]
        public class WhenCheckingLargerThanOneMillion
        {
            [Test]
            public void ShouldThrow()
            {
                Func<bool> f = () => Primes.IsPrime(1000001);

                f.Should().Throw<ArgumentOutOfRangeException>();
            }
        }
    }
}