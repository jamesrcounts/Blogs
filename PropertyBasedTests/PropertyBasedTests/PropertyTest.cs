namespace PropertyBasedTests
{
    using System.Collections.Generic;
    using System.Linq;

    using Ploeh.AutoFixture;

    using Xunit;
    using Xunit.Extensions;

    public class PropertyTest
    {
        private static readonly Fixture Fixture = new Fixture();

        public static IEnumerable<object[]> EvenNumbers
        {
            get
            {
                return Numbers().Take(100).Select(n => new object[] { n });
            }
        }

        [Theory]
        [PropertyData("EvenNumbers")]
        public void EvenOddTheory(int n)
        {
            Assert.True((n + 1) % 2 == 1, n + " + 1 is odd");
        }

        private static IEnumerable<int> Numbers()
        {
            while (true)
            {
                var i = Fixture.Create<int>();
                if (i % 2 == 0)
                {
                    yield return i;
                }
            }
        }
    }
}