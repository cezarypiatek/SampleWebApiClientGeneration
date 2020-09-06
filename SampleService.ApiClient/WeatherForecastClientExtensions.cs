using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace SampleService.ApiClient
{
    public static class WeatherForecastClientExtensions
    {
        public static Task<IReadOnlyList<WeatherForecast>?> GetForTodayAsync(this IWeatherForecastClient client, CancellationToken cancellationToken = default) 
            => client.GetAsync(1, cancellationToken);
        
        public static Task<IReadOnlyList<WeatherForecast>?> GetForNextWeekAsync(this IWeatherForecastClient client, CancellationToken cancellationToken = default) 
            => client.GetAsync(7, cancellationToken);
    }
}
