using Application.Dtos;
using Application.Utilities;
using MediatR;

namespace Application.Queries
{
    public record FilterWeatherForecastQuery(int filterInWeeks, int pageNumber, int pageSize) : IRequest<PaginatedList<WeatherForecastFilterQueryResponse>>;
}
