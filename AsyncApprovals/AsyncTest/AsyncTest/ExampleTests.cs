namespace AsyncTest
{
    using System;
    using System.Diagnostics;
    using System.Net;
    using System.Net.Http;
    using System.Threading;
    using System.Threading.Tasks;

    using ApprovalTests;
    using ApprovalTests.Reporters;
    using ApprovalTests.Writers;

    using Xunit;

    public class ExampleTests
    {
        private static readonly Uri RequestUri = new Uri("https://avatars2.githubusercontent.com/u/36907?s=140");

        private static readonly TimeSpan TimeSpan = new TimeSpan(0, 0, 0, 1);

        private bool sideEffect = false;

        [Fact]
        public async Task TypicalAsyncTest()
        {
            var httpClient = new HttpClient();
            var response = await httpClient.GetAsync(RequestUri);
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public void JustObserveTheResult()
        {
            var httpClient = new HttpClient();
            var message = httpClient.GetAsync(RequestUri);
            var response = message.Result;
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void ObserveAndApprove()
        {
            var httpClient = new HttpClient();
            var message = httpClient.GetAsync(RequestUri);
            var response = message.Result;
            var result = response.Content.ReadAsStreamAsync().Result;
            Approvals.Verify(new ApprovalBinaryWriter(result, "png"));
        }

        [Fact]
        public async Task TypicalPromise()
        {
            await this.AsynchronousSideEffect();
            Assert.True(this.sideEffect, "Observe a side effect");
        }

        [Fact]
        public void JustWaitForPromise()
        {
            var task = this.AsynchronousSideEffect();
            task.Wait();
            Assert.True(this.sideEffect, "Observe a side effect");
        }

        [Fact]
        [UseReporter(typeof(DiffReporter))]
        public void WaitAndApprove()
        {
            var task = this.AsynchronousSideEffect();
            task.Wait();
            Approvals.Verify("Observed a side effect: " + this.sideEffect);
        }

        private Task AsynchronousSideEffect()
        {
            this.sideEffect = true;
            return Task.Delay(TimeSpan);
        }
    }
}