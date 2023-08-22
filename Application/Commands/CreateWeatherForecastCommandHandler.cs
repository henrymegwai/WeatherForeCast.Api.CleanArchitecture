using Application.Data;
using Application.Dtos;
using Application.Mapper;
using Domain.Exceptions;
using Domain.IRepositories;
using Domain.WeatherForecasts;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Commands
{

    public class CreateWeatherForecastCommandHandler : IRequestHandler<CreateWeatherForecastCommand, WeatherForecastResponse>
    {
        private const int MinimumTemperature = -60;
        private const int MaximumTemperature = 60;
        private readonly ILogger<CreateWeatherForecastCommandHandler> _logger;
        private readonly IWeatherForecastRepository _weatherForecastRepository;
        private readonly IUnitOfWork _unitOfWork;
        public CreateWeatherForecastCommandHandler(ILogger<CreateWeatherForecastCommandHandler> logger,
            IWeatherForecastRepository weatherForecastRepository, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _weatherForecastRepository = weatherForecastRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task<WeatherForecastResponse> Handle(CreateWeatherForecastCommand request, CancellationToken cancellationToken)
        {
            if (request.temperatureInCentrigrade < MinimumTemperature)
            {
                throw new TemperatureTooLowException(request.temperatureInCentrigrade);
            }
            if (request.temperatureInCentrigrade > MaximumTemperature)
            {
                throw new TemperatureTooHighException(request.temperatureInCentrigrade);
            }
            if (request.date < DateTime.Now)
            {
                throw new WeatherForecastDateException(request.date);
            }

            var newWeatherforecast = new WeatherForecast(
                Guid.NewGuid(), request.date,
                request.temperatureInCentrigrade, request.summary);

            await _weatherForecastRepository.Add(newWeatherforecast);

            await _unitOfWork.SaveChangesAsync(cancellationToken);
            _logger.LogInformation($"WeatherForecast with was created successfully");
            return newWeatherforecast.Map();
        }
    }


}
