

using Domain.WeatherForecasts;

namespace Domain.IRepositories
{
    public interface IWeatherForecastRepository
    {
        Task Add(WeatherForecast weatherForecast);
        Task<WeatherForecast> GetByIdAsync(Guid id);
        Task<IReadOnlyList<WeatherForecast>> GetAsync();
    }
}
