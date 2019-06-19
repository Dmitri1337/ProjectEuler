using FluentAssertions;
using NUnit.Framework;
using ProjectEuler.Problems;

namespace ProjectEuler.Tests.Problems
{
    [TestFixture]
    public class Problem0012Tests
    {
        [TestFixture]
        public class WhenGettingResult
        {
            [Test]
            public void ShouldReturnCorrectResult()
            {
                var problem = new Problem0012();
                object result = problem.GetResult();

                result.Should().Be(76576500);
            }
        }
    }
}