using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Api;
using Api.Interfaces;
using FluentAssertions;
using IntegrationTests.Mocks;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using NUnit.Framework;

namespace IntegrationTests
{
    public class ApiIntegrationTests
    {
        private HttpClient _client;

        [SetUp]
        public void Setup()
        {
            var appFactory = new WebApplicationFactory<Startup>()
                .WithWebHostBuilder(builder =>
                {
                    builder.ConfigureServices(services =>
                    {
                        services.RemoveAll(typeof(MockRepository));
                        services.AddTransient<IRepository, MockRepository>(); //replace implementation with a mock
                    });
                });

            _client = appFactory.CreateClient();
        }

        [Test]
        public async Task Get_WithWeatherData_ShouldReturnCollection()
        {
            var response = await _client.GetAsync("/WeatherForecast");

            var data = await response.Content.ReadAsAsync<IEnumerable<WeatherForecast>>();

            response.StatusCode.Should().Be(HttpStatusCode.OK);
            response.IsSuccessStatusCode.Should().BeTrue();
            data.Should().HaveCount(2);
            data.ElementAt(0).Summary.Should().Be("Freezing");
            data.ElementAt(1).Summary.Should().Be("Mild");
        }
    }
}