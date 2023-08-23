using Application.Commands;
using Application.Data;
using Application.Dtos;
using Application.Queries;
using Domain.IRepositories;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace WeatherForecast.Tests.WeatherForecast.Queries
{
    public  class GetWeatherForecastQueryHandlerTests
    {
        private readonly Mock<ILogger<GetWeatherForecastByIdQueryHandler>> _queryloggerMock;
        private readonly Mock<ILogger<CreateWeatherForecastCommandHandler>> _commandloggerMock;
        private readonly Mock<IWeatherForecastRepository> _weatherForecastRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        public GetWeatherForecastQueryHandlerTests()
        {
            _queryloggerMock = new();
            _commandloggerMock = new();
            _weatherForecastRepositoryMock = new();
            _unitOfWorkMock = new();
        }
         
        [Fact]
        public async Task Handle_Should_Get_WeatherForecast_ById()
        {
            
        }
    }
}
