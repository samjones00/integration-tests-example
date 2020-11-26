using System;
using System.Collections.Generic;
using Api;
using Api.Interfaces;

namespace IntegrationTests.Mocks
{
    public class MockRepository : IRepository
    {
        public IList<WeatherForecast> Get()
        {
            var data = new List<WeatherForecast>
            {
                new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(2),
                    Summary = "Freezing",
                    TemperatureC = -10,
                },
                new WeatherForecast
                {
                    Date = DateTime.Now.AddDays(5),
                    Summary = "Mild",
                    TemperatureC = 50,
                }
            };

            return data;
        }
    }
}
