using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using FluentAssertions;
using NUnit.Framework;
using ProjectEuler.Math;

namespace ProjectEuler.Tests.Math
{
    [TestFixture]
    public class FactorialTests
    {
        [TestFixture]
        public class WhenCalculatingFactorial
        {
            [TestFixture]
            public class AndNumberIsNegative
            {
                [Test]
                public void ShouldThrow()
                {
                    Func<BigInteger> f = () => (-1).GetFactorial();
                    f.Should().Throw<ArgumentOutOfRangeException>();
                }
            }

            [TestFixture]
            public class AndNumberIsZero
            {
                [Test]
                public void ShouldReturnOne()
                {
                    0.GetFactorial().Should().Be(1);
                }
            }

            [TestFixture]
            public class AndNumberIsPositive
            {
                [Test]
                public void ShouldReturnCorrectResult()
                {
                    1.GetFactorial().Should().Be(1);
                    2.GetFactorial().Should().Be(2);
                    3.GetFactorial().Should().Be(6);
                    4.GetFactorial().Should().Be(24);
                    5.GetFactorial().Should().Be(120);
                }
            }
        }

        [TestFixture]
        public class WhenTransformingToFactorialNumberSystem
        {
            [TestFixture]
            public class AndNumberIsNegative
            {
                [Test]
                public void ShouldThrow()
                {
                    Func<IEnumerable<int>> f = () => (-1).GetFactoradicDigits();
                    f.Should().Throw<ArgumentOutOfRangeException>();
                }
            }

            [TestFixture]
            public class AndNumberIsZero
            {
                [Test]
                public void ShouldReturnSingleZeroElement()
                {
                    IReadOnlyList<int> digits = 0.GetFactoradicDigits();

                    digits.Should().HaveCount(1);
                    digits.Single().Should().Be(0);
                }
            }

            [TestFixture]
            public class AndNumberIsPositive
            {
                [Test]
                public void ShouldReturnCorrectResult()
                {
                    1.GetFactoradicDigits().Should().BeEquivalentTo(new[] { 1, 0 });
                    2.GetFactoradicDigits().Should().BeEquivalentTo(new[] { 1, 0, 0 });
                    3.GetFactoradicDigits().Should().BeEquivalentTo(new[] { 1, 1, 0 });
                    4.GetFactoradicDigits().Should().BeEquivalentTo(new[] { 2, 0, 0 });
                    5.GetFactoradicDigits().Should().BeEquivalentTo(new[] { 2, 1, 0 });
                    6.GetFactoradicDigits().Should().BeEquivalentTo(new[] { 1, 0, 0, 0 });
                    7.GetFactoradicDigits().Should().BeEquivalentTo(new[] { 1, 0, 1, 0 });
                    8.GetFactoradicDigits().Should().BeEquivalentTo(new[] { 1, 1, 0, 0 });
                    9.GetFactoradicDigits().Should().BeEquivalentTo(new[] { 1, 1, 1, 0 });
                    10.GetFactoradicDigits().Should().BeEquivalentTo(new[] { 1, 2, 0, 0 });
                    14.GetFactoradicDigits().Should().BeEquivalentTo(new[] { 2, 1, 0, 0 });
                    349.GetFactoradicDigits().Should().BeEquivalentTo(new[] { 2, 4, 2, 0, 1, 0 });
                }
            }
        }
    }
}