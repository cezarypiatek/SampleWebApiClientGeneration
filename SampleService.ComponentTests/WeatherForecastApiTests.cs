using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using NUnit.Framework;
using SampleService.ApiClient;

namespace SampleService.ComponentTests
{
    public class WeatherForecastApiTests
    {
        [Test]
        public async Task should_be_able_to_get_forecast_for_week()
        {
            //Arrange
            using var applicationFactory = new WebApplicationFactory<Program>();
            var httpClient = applicationFactory.CreateClient();
            var weatherForecastClient = new WeatherForecastClient(httpClient);

            //Act
            var result = await weatherForecastClient.GetForNextWeekAsync();

            //Assert
            Assert.AreEqual(7, result?.Count);
        }
        
        [Test]
        public async Task should_be_able_to_get_forecast_for_today()
        {
            //Arrange
            using var applicationFactory = new WebApplicationFactory<Program>();
            var httpClient = applicationFactory.CreateClient();
            var weatherForecastClient = new WeatherForecastClient(httpClient);

            //Act
            var result = await weatherForecastClient.GetForTodayAsync();

            //Assert
            Assert.AreEqual(1, result?.Count);
            Assert.AreEqual(DateTime.Today, result![0].Date.Date);
        }
    }
}
