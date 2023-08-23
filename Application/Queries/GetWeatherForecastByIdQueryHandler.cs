using Application.Commands;
using Application.Data;
using Application.Dtos;
using Application.Mapper;
using Domain.Exceptions;
using Domain.IRepositories;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Application.Queries
{
    public sealed class GetWeatherForecastByIdQueryHandler : IRequestHandler<GetWeatherForecastByIdQuery, WeatherForecastResponse>
    {
        private readonly IWeatherForecastRepository _weatherForecastRepository;
        private readonly ILogger<GetWeatherForecastByIdQueryHandler> _logger;
        public GetWeatherForecastByIdQueryHandler(IWeatherForecastRepository weatherForecastRepository, ILogger<GetWeatherForecastByIdQueryHandler> logger)
        {
            _weatherForecastRepository = weatherForecastRepository;
            _logger = logger;
        }

        public async Task<WeatherForecastResponse> Handle(GetWeatherForecastByIdQuery request, CancellationToken cancellationToken)
        {
            var weatherForecast = await _weatherForecastRepository.GetByIdAsync(request.WeatherForecastId);

            if (weatherForecast is null)
            {
                throw new WeatherForecastNotFoundException(request.WeatherForecastId);
            }
            _logger.LogInformation($"WeatherForecast with id: {request.WeatherForecastId} was retrieved successfully");
            return weatherForecast.Map();
        }
    }
     
}
