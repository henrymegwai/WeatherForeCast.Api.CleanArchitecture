using Application.Commands;
using Application.Data;
using Domain.Exceptions;
using Domain.IRepositories;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecast.Tests.WeatherForecast.Queries
{
    public  class GetWeatherForecastQueryHandlerTests
    {
        private readonly Mock<ILogger<GetWeatherForecastQueryHandlerTests>> _loggerMock;
        private readonly Mock<IApplicationDbContext> _contextMock; 
        public GetWeatherForecastQueryHandlerTests()
        {
            _loggerMock = new();
            _contextMock = new();
            
        }
         
        [Fact]
        public async Task Handle_Should_Not_Create_NewWeatherForecast_But_Throw_TemperatureTooLowException_When_Temperature_Imputed_IsBelow_Minus60()
        { 

        }
    }
}
