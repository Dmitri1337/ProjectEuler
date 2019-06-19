using System.Numerics;
using FluentAssertions;
using NUnit.Framework;
using ProjectEuler.Problems;

namespace ProjectEuler.Tests.Problems
{
    [TestFixture]
    public class Problem0015Tests
    {
        [TestFixture]
        public class WhenGettingResult
        {
            [Test]
            public void ShouldReturnCorrectResult()
            {
                var problem = new Problem0015();
                object result = problem.GetResult();

                result.Should().Be((BigInteger)137846528820);
            }
        }
    }
}