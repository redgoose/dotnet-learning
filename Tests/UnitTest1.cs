using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;
using System.Threading.Tasks;
using TodoApi;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
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
    }
}
