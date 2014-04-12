namespace AsyncTest
{
    using System.Net.Http;

    using Xunit;

    public class ExampleTests
    {
        [Fact]
        public void TypicalAsyncTest()
        {
            var httpClient = new HttpClient();
        }
    }
}