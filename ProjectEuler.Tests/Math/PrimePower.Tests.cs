using System;
using FluentAssertions;
using NUnit.Framework;
using ProjectEuler.Math;

namespace ProjectEuler.Tests.Math
{
    [TestFixture]
    public class PrimePowerTests
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
                    Func<PrimePower> f = () => new PrimePower(4, 1);
                    f.Should().Throw<ArgumentOutOfRangeException>();
                }
            }

            [TestFixture]
            public class AndPrimeArgumentIsMoreThanMillion
            {
                [Test]
                public void ShouldThrow()
                {
                    Func<PrimePower> f = () => new PrimePower(15476899, 1);
                    f.Should().Throw<ArgumentOutOfRangeException>();
                }
            }

            [TestFixture]
            public class AndPowerArgumentIsZero
            {
                [Test]
                public void ShouldThrow()
                {
                    Func<PrimePower> f = () => new PrimePower(5, 0);
                    f.Should().Throw<ArgumentOutOfRangeException>();
                }
            }

            [TestFixture]
            public class AndPowerArgumentIsNegative
            {
                [Test]
                public void ShouldThrow()
                {
                    Func<PrimePower> f = () => new PrimePower(5, -3);
                    f.Should().Throw<ArgumentOutOfRangeException>();
                }
            }

            [TestFixture]
            public class AndAllArgumentsCorrect
            {
                [Test]
                public void ShouldSucceed()
                {
                    Func<PrimePower> f = () => new PrimePower(5, 33);
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
                new PrimePower(2, 1).ToLong().Should().Be(2);
                new PrimePower(2, 4).ToLong().Should().Be(16);
                new PrimePower(3, 5).ToLong().Should().Be(3*3*3*3*3);
            }
        }
    }
}