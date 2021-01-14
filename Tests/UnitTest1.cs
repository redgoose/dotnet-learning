using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;
using TodoApi;
using WireMock.RequestBuilders;
using WireMock.ResponseBuilders;
using WireMock.Server;
using WireMock.Settings;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        private static WireMockServer _wireMockServer;

        [ClassInitialize]
        public static void StartMockServer(TestContext context)
        {
            _wireMockServer = WireMockServer.Start();
        }

        [ClassCleanup]
        public static void Cleanup()
        {
            _wireMockServer.Stop();
        }

        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(true);
        }

        [TestMethod]
        public async Task TestAPIFoo()
        {
            // Arrange
            TestServer _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            HttpClient _client = _server.CreateClient();

            // Act
            var response = await _client.GetAsync("/api/learning/foo");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.AreEqual("foo", responseString);
        }

        [TestMethod]
        public async Task TestAPIBaz()
        {
            // Arrange
            TestServer _server = new TestServer(new WebHostBuilder()
                .UseStartup<Startup>());
            HttpClient _client = _server.CreateClient();

            _wireMockServer
                //.Given(Request.Create().WithPath("https://api.ipify.org?format=json").UsingGet())
                .Given(Request.Create().WithPath("?format=json").UsingGet())
                .RespondWith(
                Response.Create()
                    .WithStatusCode(200)
                    .WithBody(@"{ ""msg"": ""Hello world!"" }")
                );

            // Act
            var response = await _client.GetAsync("/api/learning/baz");
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();

            // Assert
            Assert.AreEqual(@"{ ""msg"": ""Hello world!"" }", responseString);
        }

    }
}
