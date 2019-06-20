using FluentAssertions;
using NUnit.Framework;
using ProjectEuler.Math.Sequences;

namespace ProjectEuler.Tests.Math
{
    [TestFixture]
    public class ArithmeticSequenceTests
    {
        [TestFixture]
        public class WhenGettingTerm
        {
            [TestFixture]
            public class AndTermIndexIsOne
            {
                [Test]
                public void ShouldReturnInitialTerm()
                {
                    var progression = new ArithmeticSequence(42, 3.14M);
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
                    var progression = new ArithmeticSequence(42, 3.14M);
                    decimal term42 = progression.GetTerm(42);

                    term42.Should().Be(42 + 3.14M * 41);
                }
            }
        }

        [TestFixture]
        public class WhenGettingSum
        {
            [TestFixture]
            public class AndTermIndexIsOne
            {
                [Test]
                public void ShouldReturnInitialTerm()
                {
                    var progression = new ArithmeticSequence(42, 3.14M);
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
                    var progression = new ArithmeticSequence(1, 1);
                    decimal term42 = progression.GetTerm(42);

                    term42.Should().Be(42);
                }
            }
        }
    }
}