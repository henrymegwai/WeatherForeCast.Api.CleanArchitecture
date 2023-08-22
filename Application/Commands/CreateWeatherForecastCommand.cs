using Application.Dtos;
using Domain.WeatherForecasts;
using MediatR;

namespace Application.Commands
{
    public record CreateWeatherForecastCommand(
        DateTime date, 
        int temperatureInCentrigrade, 
        string summary) : IRequest<WeatherForecastResponse>;

}
