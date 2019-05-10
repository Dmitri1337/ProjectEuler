using System;
using FluentAssertions;
using NUnit.Framework;
using ProjectEuler.Math;

namespace ProjectEuler.Tests.Math
{
    [TestFixture]
    public class PalindromesTests
    {
        [TestFixture]
        public class WhenGettingReversedNumber
        {
            [TestFixture]
            public class AndArgumentIsNegative
            {
                [Test]
                public void ShouldThrow()
                {
                    Func<int> f = () => Palindromes.GetReversed(-1);

                    f.Should().Throw<ArgumentOutOfRangeException>();
                }
            }

            [TestFixture]
            public class AndArgumentIsPositive
            {
                [Test]
                public void ShouldSucceed()
                {
                    Palindromes.GetReversed(0).Should().Be(0);
                    Palindromes.GetReversed(7).Should().Be(7);
                    Palindromes.GetReversed(13).Should().Be(31);
                    Palindromes.GetReversed(314).Should().Be(413);
                }
            }
        }

        [TestFixture]
        public class WhenCheckingIfPalindrome
        {
            [TestFixture]
            public class AndArgumentIsNegative
            {
                [Test]
                public void ShouldThrow()
                {
                    Func<bool> f = () => Palindromes.IsPalindrome(-1);

                    f.Should().Throw<ArgumentOutOfRangeException>();
                }
            }

            [TestFixture]
            public class AndArgumentIsPositive
            {
                [Test]
                public void ShouldSucceed()
                {
                    Palindromes.IsPalindrome(0).Should().BeTrue();
                    Palindromes.IsPalindrome(7).Should().BeTrue();
                    Palindromes.IsPalindrome(13).Should().BeFalse();
                    Palindromes.IsPalindrome(33).Should().BeTrue();
                    Palindromes.IsPalindrome(777).Should().BeTrue();
                    Palindromes.IsPalindrome(70707).Should().BeTrue();
                    Palindromes.IsPalindrome(70737).Should().BeFalse();
                }
            }
        }
    }
}