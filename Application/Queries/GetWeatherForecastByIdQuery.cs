using Application.Dtos;
using MediatR; 

namespace Application.Queries
{
    public record GetWeatherForecastByIdQuery(Guid WeatherForecastId): IRequest<WeatherForecastResponse>;
    
}
