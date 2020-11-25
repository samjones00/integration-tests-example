using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Api;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;

namespace IntegrationTests
{
    public class Tests
    {
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            var appFactory = new WebApplicationFactory<Startup>();

            _client = appFactory.CreateClient();
        }

        [Test]
        public async Task Test1()
        {
            var response = await _client.GetAsync("/WeatherForecast");

            Assert.AreEqual(HttpStatusCode.OK,response.StatusCode);
        }
    }
}