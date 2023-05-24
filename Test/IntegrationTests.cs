using GreenLocator.Controllers;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.VisualStudio.TestPlatform.TestHost;

namespace Test
{
    public class IntegrationTests
    {
        private readonly HttpClient _client;
        public IntegrationTests()
        {
            var appFactory = new WebApplicationFactory<Program>();
            _client = appFactory.CreateClient();
        }
        [Fact]
        public async Task Test1()
        {
            var response = await _client.GetAsync("/api/WebService");
            Assert.True((int)response.StatusCode == 200);
        }
    }
}