using System;
using FluentAssertions;
using NUnit.Framework;
using ProjectEuler.Math;

namespace ProjectEuler.Tests.Math
{
    [TestFixture]
    public class ArithmeticProgressionTests
    {
        [TestFixture]
        public class WhenGettingTerm
        {
            [TestFixture]
            public class AndTermIndexIsNegative
            {
                [Test]
                public void ShouldThrow()
                {
                    var progression = new ArithmeticProgression(0, 1);
                    var action = new Action(() => progression.GetTerm(-1));

                    action.Should().Throw<ArgumentOutOfRangeException>();
                }
            }

            [TestFixture]
            public class AndTermIndexIsZero
            {
                [Test]
                public void ShouldThrow()
                {
                    var progression = new ArithmeticProgression(0, 1);
                    var action = new Action(() => progression.GetTerm(0));

                    action.Should().Throw<ArgumentOutOfRangeException>();
                }
            }

            [TestFixture]
            public class AndTermIndexIsOne
            {
                [Test]
                public void ShouldReturnInitialTerm()
                {
                    var progression = new ArithmeticProgression(42, 3.14M);
                    decimal firstTerm = progression.GetTerm(1);
                        
                    firstTerm.Should().Be(42);
                }
            }

            [TestFixture]
            public class AndTermIndexIsPositive
            {
                [Test]
                public void ShouldReturnCorrectTerm()
                {
                    var progression = new ArithmeticProgression(42, 3.14M);
                    decimal term42 = progression.GetTerm(42);

                    term42.Should().Be(42 + 3.14M * 41);
                }
            }
        }

        [TestFixture]
        public class WhenGettingSum
        {
            [TestFixture]
            public class AndTermIndexIsNegative
            {
                [Test]
                public void ShouldThrow()
                {
                    var progression = new ArithmeticProgression(0, 1);
                    var action = new Action(() => progression.GetSum(-1));

                    action.Should().Throw<ArgumentOutOfRangeException>();
                }
            }

            [TestFixture]
            public class AndTermIndexIsZero
            {
                [Test]
                public void ShouldThrow()
                {
                    var progression = new ArithmeticProgression(0, 1);
                    var action = new Action(() => progression.GetSum(0));

                    action.Should().Throw<ArgumentOutOfRangeException>();
                }
            }

            [TestFixture]
            public class AndTermIndexIsOne
            {
                [Test]
                public void ShouldReturnInitialTerm()
                {
                    var progression = new ArithmeticProgression(42, 3.14M);
                    decimal firstTerm = progression.GetSum(1);
                        
                    firstTerm.Should().Be(42);
                }
            }

            [TestFixture]
            public class AndTermIndexIsPositive
            {
                [Test]
                public void ShouldReturnCorrectTerm()
                {
                    var progression = new ArithmeticProgression(1, 1);
                    decimal term42 = progression.GetTerm(42);

                    term42.Should().Be(42);
                }
            }
        }
    }
}