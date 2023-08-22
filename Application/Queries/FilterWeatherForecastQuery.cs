using Application.Dtos;
using Application.Utilities;
using MediatR;

namespace Application.Queries
{
    public record FilterWeatherForecastQuery(string searchquery, string currentFilter, string sortBy, int pageNumber, int pageSize) : IRequest<PaginatedList<WeatherForecastResponse>>;
}
