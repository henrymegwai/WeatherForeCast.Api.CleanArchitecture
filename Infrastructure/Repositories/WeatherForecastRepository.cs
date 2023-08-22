using Domain.IRepositories;
using Domain.WeatherForecasts;
using Infrastructure.DatabaseContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    internal sealed class WeatherForecastRepository : IWeatherForecastRepository
    {
        private readonly ApplicationDbContext _context;
        public WeatherForecastRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(WeatherForecast weatherForecast)
        {
           await _context.WeatherForecasts.AddAsync(weatherForecast);
        }

        public async Task<IReadOnlyList<WeatherForecast>> GetAsync()
        {
           return await _context.WeatherForecasts.ToListAsync();
        }

        public async Task<WeatherForecast> GetByIdAsync(Guid id) => await _context.WeatherForecasts.FirstOrDefaultAsync(w => w.Id == id);
    }
}
