using FluentAssertions;
using NUnit.Framework;
using ProjectEuler.Problems;

namespace ProjectEuler.Tests.Problems
{
    [TestFixture]
    public class Problem0024Tests
    {
        [TestFixture]
        public class WhenGettingResult
        {
            [Test]
            public void ShouldReturnCorrectResult()
            {
                var problem = new Problem0024();
                object result = problem.GetResult();

                result.Should().Be(2783915460);
            }
        }
    }
}