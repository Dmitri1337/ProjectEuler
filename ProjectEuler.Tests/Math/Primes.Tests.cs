﻿using System;
using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using NUnit.Framework;
using ProjectEuler.Math.Primes;

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
                    11619.IsPrime().Should().BeFalse();
                    11621.IsPrime().Should().BeTrue();
                    4004177.IsPrime().Should().BeFalse();
                    4008203.IsPrime().Should().BeTrue();
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
                public void ShouldCheckAbsoluteValue()
                {
                    const int n = 120;
                    (-n).Factorize().Should().BeEquivalentTo(n.Factorize());
                }
            }

            [TestFixture]
            public class AndNumberIsZero
            {
                [Test]
                public void ShouldThrow()
                {
                    Func<IEnumerable<PrimeFactor>> f = () => 0.Factorize();
                    f.Should().Throw<ArgumentOutOfRangeException>();
                }
            }

            [TestFixture]
            public class AndNumberIsOne
            {
                [Test]
                public void ShouldReturnEmptyCollection()
                {
                    1.Factorize().Should().BeEmpty();
                }
            }

            [TestFixture]
            public class AndNumberIsPrime
            {
                [Test]
                public void ShouldReturnWithPowerOne()
                {
                    PrimeFactor[] primePowers = 13.Factorize().ToArray();

                    primePowers.Length.Should().Be(1);
                    primePowers[0].Prime.Should().Be(13);
                    primePowers[0].Exponent.Should().Be(1);
                }
            }

            [TestFixture]
            public class AndNumberIsNonPrime
            {
                [Test]
                public void ShouldReturnPrimePowerCollection()
                {
                    PrimeFactor[] primePowers = 369.Factorize().ToArray();

                    primePowers.Length.Should().Be(2);

                    primePowers[0].Prime.Should().Be(3);
                    primePowers[0].Exponent.Should().Be(2);

                    primePowers[1].Prime.Should().Be(41);
                    primePowers[1].Exponent.Should().Be(1);
                }
            }

            [TestFixture]
            public class AndNumberIsOneMillion
            {
                [Test]
                public void ShouldSucceed()
                {
                    1000000.Factorize().Should().NotBeEmpty();
                }
            }
        }
    }
}