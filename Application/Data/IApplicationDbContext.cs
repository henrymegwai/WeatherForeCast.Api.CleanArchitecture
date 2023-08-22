
using Domain.WeatherForecasts;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Application.Data;

public interface IApplicationDbContext
{
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }

    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
}
