using Application.Dtos;
using Domain.WeatherForecasts;
using MediatR; 

namespace Application.Queries
{
    public record GetWeatherForecastByIdQuery(Guid WeatherForecastId): IRequest<WeatherForecastResponse>;
    
}
