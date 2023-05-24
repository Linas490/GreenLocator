using Microsoft.AspNetCore.Mvc.Testing;

namespace IntegrationTesting
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public async void TestMethod1()
        {
            var webAppFactory = new WebApplicationFactory<Program>();
            var httpClient = webAppFactory.CreateDefaultClient();
            var response = await httpClient.GetAsync("");
            Console.WriteLine(response.StatusCode);
            Assert.IsTrue(response.IsSuccessStatusCode);
        }
    }
}