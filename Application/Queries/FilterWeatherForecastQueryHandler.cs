using Application.Data;
using Application.Dtos;
using Application.Utilities;
using Domain.Exceptions;
using MediatR;
using Microsoft.Extensions.Logging;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Globalization;
using Application.Mapper;
using Microsoft.EntityFrameworkCore;

namespace Application.Queries
{
    internal class FilterWeatherForecastQueryHandler : IRequestHandler<FilterWeatherForecastQuery, PaginatedList<WeatherForecastResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<FilterWeatherForecastQueryHandler> _logger;
        public FilterWeatherForecastQueryHandler(IApplicationDbContext context, ILogger<FilterWeatherForecastQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<PaginatedList<WeatherForecastResponse>> Handle(FilterWeatherForecastQuery request, CancellationToken cancellationToken)
        {

            var weatherForecasts =  _context.WeatherForecasts.AsQueryable();
            string query = request.searchquery;
            query = string.IsNullOrEmpty(query) ? request.currentFilter : query;

            weatherForecasts = query == request.currentFilter ? weatherForecasts : weatherForecasts.Where(p => p.Summary.Contains(query));

            WeatherForecastSortOrder sortOrder = string.IsNullOrEmpty(request.sortBy) ? WeatherForecastSortOrder.date_asc : request.sortBy.ToEnum<WeatherForecastSortOrder>();
           
            switch (sortOrder)
            { 
                
                case WeatherForecastSortOrder.date_asc:
                    weatherForecasts = weatherForecasts.OrderBy(x => x.Date);
                    break;
                case WeatherForecastSortOrder.date_desc:
                    weatherForecasts = weatherForecasts.OrderByDescending(x => x.Date);
                    break;
            }

            var filteredResult = await weatherForecasts.Select(x => x.Map()).ToListAsync();

            PaginatedList<WeatherForecastResponse> paginatedResults = PaginatedList<WeatherForecastResponse>.CreateAsync(filteredResult, request.pageNumber, request.pageSize);

            return paginatedResults;
        }
    }
}
