using Application.Commands;
using Application.Data;
using Application.Dtos;
using Domain.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Queries
{
    internal sealed class GetWeatherForecastByIdQueryHandler : IRequestHandler<GetWeatherForecastByIdQuery, WeatherForecastResponse>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<GetWeatherForecastByIdQueryHandler> _logger;
        public GetWeatherForecastByIdQueryHandler(IApplicationDbContext context, ILogger<GetWeatherForecastByIdQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<WeatherForecastResponse> Handle(GetWeatherForecastByIdQuery request, CancellationToken cancellationToken)
        {
            var weatherForecast = await _context
                .WeatherForecasts
                .Where(w => w.Id == request.WeatherForecastId)
                .Select(w => new WeatherForecastResponse(
                    w.Id,
                    w.Date,
                    w.TemperatureC, 
                    w.Summary))
                .FirstOrDefaultAsync(cancellationToken);

            if (weatherForecast is null)
            {
                throw new WeatherForecastNotFoundException(request.WeatherForecastId);
            }

            return weatherForecast;
        }
    }
     
}
