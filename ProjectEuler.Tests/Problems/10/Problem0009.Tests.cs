using FluentAssertions;
using NUnit.Framework;
using ProjectEuler.Problems;

namespace ProjectEuler.Tests.Problems
{
    [TestFixture]
    public class Problem0009Tests
    {
        [TestFixture]
        public class WhenGettingResult
        {
            [Test]
            public void ShouldReturnCorrectResult()
            {
                var problem = new Problem0009();
                object result = problem.GetResult();

                result.Should().Be(31875000);
            }
        }
    }
}