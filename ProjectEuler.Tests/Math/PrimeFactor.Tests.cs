﻿using System;
using FluentAssertions;
using NUnit.Framework;
using ProjectEuler.Math.Primes;

namespace ProjectEuler.Tests.Math
{
    [TestFixture]
    public class PrimeFactorTests
    {
        [TestFixture]
        public class WhenInitializing
        {
            [TestFixture]
            public class AndPrimeArgumentIsNotPrime
            {
                [Test]
                public void ShouldThrow()
                {
                    Func<PrimeFactor> f = () => new PrimeFactor(4, 1);
                    f.Should().Throw<ArgumentOutOfRangeException>();
                }
            }

            [TestFixture]
            public class AndPowerArgumentIsZero
            {
                [Test]
                public void ShouldThrow()
                {
                    Func<PrimeFactor> f = () => new PrimeFactor(5, 0);
                    f.Should().Throw<ArgumentOutOfRangeException>();
                }
            }

            [TestFixture]
            public class AndPowerArgumentIsNegative
            {
                [Test]
                public void ShouldThrow()
                {
                    Func<PrimeFactor> f = () => new PrimeFactor(5, -3);
                    f.Should().Throw<ArgumentOutOfRangeException>();
                }
            }

            [TestFixture]
            public class AndAllArgumentsCorrect
            {
                [Test]
                public void ShouldSucceed()
                {
                    Func<PrimeFactor> f = () => new PrimeFactor(5, 33);
                    f.Should().NotThrow();
                }
            }
        }

        [TestFixture]
        public class WhenConvertingToLong
        {
            [Test]
            public void ShouldSucceed()
            {
                new PrimeFactor(2, 1).ToInt64().Should().Be(2);
                new PrimeFactor(2, 4).ToInt64().Should().Be(16);
                new PrimeFactor(3, 5).ToInt64().Should().Be(3 * 3 * 3 * 3 * 3);
            }
        }
    }
}