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
        public class DecimalPalindromes
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
            public class WhenCheckingIfNumberIsPalindrome
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

        [TestFixture]
        public class BinaryPalindromes
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
                        Palindromes.GetReversed(0, 2).Should().Be(0);
                        Palindromes.GetReversed(0b101, 2).Should().Be(0b101);
                        Palindromes.GetReversed(0b1101, 2).Should().Be(0b1011);
                        Palindromes.GetReversed(0b100111010, 2).Should().Be(0b10111001);
                    }
                }
            }

            [TestFixture]
            public class WhenCheckingIfNumberIsPalindrome
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
                        Palindromes.IsPalindrome(0, 2).Should().BeTrue();
                        Palindromes.IsPalindrome(0b101, 2).Should().BeTrue();
                        Palindromes.IsPalindrome(0b1101, 2).Should().BeFalse();
                        Palindromes.IsPalindrome(0b110011, 2).Should().BeTrue();
                        Palindromes.IsPalindrome(0b1010101, 2).Should().BeTrue();
                        Palindromes.IsPalindrome(0b1111111, 2).Should().BeTrue();
                        Palindromes.IsPalindrome(0b1111011, 2).Should().BeFalse();
                    }
                }
            }
        }
    }
}