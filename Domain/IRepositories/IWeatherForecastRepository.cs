using Domain.WeatherForecasts;
using Domain.Weathers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.IRepositories
{
    public interface IWeatherForecastRepository
    {
        Task Add(WeatherForecast weatherForecast);
        Task<WeatherForecast> GetByIdAsync(Guid id);
        Task<IReadOnlyList<WeatherForecast>> GetAsync();
    }
}
