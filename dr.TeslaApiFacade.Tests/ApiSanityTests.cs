using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;

namespace dr.TeslaApiFacade.Tests
{
    [TestFixture]
    public class ApiSanityTests
    {
        private WebApplicationFactory<Startup>? _appFactory;

        private HttpClient Client => _appFactory!.CreateClient();
        
        [OneTimeSetUp]
        public void BeforeAll()
        {
            _appFactory = new WebApplicationFactory<Startup>();
        }

        [OneTimeTearDown]
        public void AfterAll()
        {
            _appFactory?.Dispose();
        }

        [Test]
        public async Task CanStartupAndInvokeSimpleApiEndpoint()
        {
            var response= await Client.GetAsync("api/ping");
            
            Assert.That(response.IsSuccessStatusCode);
        }
    }
}