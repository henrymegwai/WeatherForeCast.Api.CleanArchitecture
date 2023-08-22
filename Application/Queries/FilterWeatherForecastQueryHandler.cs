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
    internal class FilterWeatherForecastQueryHandler : IRequestHandler<FilterWeatherForecastQuery, PaginatedList<WeatherForecastFilterQueryResponse>>
    {
        private readonly IApplicationDbContext _context;
        private readonly ILogger<FilterWeatherForecastQueryHandler> _logger;
        public FilterWeatherForecastQueryHandler(IApplicationDbContext context, ILogger<FilterWeatherForecastQueryHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<PaginatedList<WeatherForecastFilterQueryResponse>> Handle(FilterWeatherForecastQuery request, CancellationToken cancellationToken)
        {
            var weatherForecasts =  _context.WeatherForecasts.AsQueryable();
            Weeks filterInWeeks = request.filterInWeeks.ToEnum<Weeks>();
            var date = DateTime.Now;
            switch (filterInWeeks)
            {
                case Weeks.Oneweek:
                    weatherForecasts = weatherForecasts.Where(x=> x.Date >= date && x.Date <= date.AddDays(7));
                    break;
                case Weeks.Twoweeks:
                    weatherForecasts = weatherForecasts.Where(x => x.Date >= date && x.Date <= date.AddDays(14));
                    break;
                case Weeks.Threeweeks:
                    weatherForecasts = weatherForecasts.Where(x => x.Date >= date && x.Date <= date.AddDays(21));
                    break;
                case Weeks.Fourweeks:
                    weatherForecasts = weatherForecasts.Where(x => x.Date >= date && x.Date <= date.AddDays(28));
                    break;
            }
            
            var filteredResults = await weatherForecasts.Select(x => x.MapFilter()).ToListAsync();
           
           var paginatedResults = PaginatedList<WeatherForecastFilterQueryResponse>.CreateAsync(filteredResults, request.pageNumber, request.pageSize);

            return paginatedResults;
        }
    }
}
