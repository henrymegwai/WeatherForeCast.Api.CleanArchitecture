using Application.Data;
using Application.Dtos;
using Domain.Exceptions;
using Domain.IRepositories;
using FluentAssertions;
using Microsoft.Extensions.Logging;
using Moq;

namespace Application.Commands
{
    public class CreateWeatherForecastCommandHandlerTests 
    {
            private const int MinimumTemperature = -60;
        private const int MaximumTemperature = 60;
        private readonly Mock<ILogger<CreateWeatherForecastCommandHandler>> _loggerMock;
        private readonly Mock<IWeatherForecastRepository> _weatherForecastRepositoryMock;
        private readonly Mock<IUnitOfWork> _unitOfWorkMock;
        public CreateWeatherForecastCommandHandlerTests()
        {
            _loggerMock = new();
            _weatherForecastRepositoryMock = new();
            _unitOfWorkMock = new();
        }

        [Fact]
        public async Task Handle_Should_Not_Create_NewWeatherForecast_But_Throw_TemperatureTooLowException_When_Temperature_Imputed_IsBelow_Minus60()
        {
            //Arrange
            int temperature = -61;
            DateTime date = DateTime.Now.AddHours(6);
            string summary = "Freezing";
            var commandeRequest = new CreateWeatherForecastCommand(date, temperature, summary);

            var handler = new CreateWeatherForecastCommandHandler(_loggerMock.Object,
                                                               _weatherForecastRepositoryMock.Object, 
                                                               _unitOfWorkMock.Object);
            var exception = new TemperatureTooLowException(temperature);

            //Act
            Func<Task> handlerResult = async () => await handler.Handle(commandeRequest, default);

            //Assert
            var exceptionAssertion = await handlerResult.Should().ThrowAsync<TemperatureTooLowException>();
            exceptionAssertion.And.Message.Should().Be($"The WeatherForecast temperature {temperature} must be less that -60 degrees");
            
        }

        [Fact]
        public async Task Handle_Should_Not_Create_NewWeatherForecast_But_Throw_TemperatureTooHighException_When_Temperature_Imputed_IsBelow_Minus60()
        {
            //Arrange
            int temperature = 61;
            DateTime date = DateTime.Now.AddHours(6);
            string summary = "Scorching";
            var commandeRequest = new CreateWeatherForecastCommand(date, temperature, summary);

            var handler = new CreateWeatherForecastCommandHandler(_loggerMock.Object,
                                                               _weatherForecastRepositoryMock.Object,
                                                               _unitOfWorkMock.Object);
            var exception = new TemperatureTooLowException(temperature);

            //Act
            Func<Task> handlerResult = async () => await handler.Handle(commandeRequest, default);

            //Assert
            var exceptionAssertion = await handlerResult.Should().ThrowAsync<TemperatureTooHighException>();
            exceptionAssertion.And.Message.Should().Be($"The WeatherForecast temperature {temperature} cannot be greater than 60 degrees");

        }

        [Fact]
        public async Task Handle_Should_Not_Create_NewWeatherForecast_But_Throw_WeatherForecastDateException_If_Date_Imputed_IsInThePast()
        {
            //Arrange
            int temperature = 60;
            DateTime date = DateTime.Now.AddMinutes(-4);
            string summary = "Scorching";
            var commandeRequest = new CreateWeatherForecastCommand(date, temperature, summary);

            var handler = new CreateWeatherForecastCommandHandler(_loggerMock.Object,
                                                               _weatherForecastRepositoryMock.Object,
                                                               _unitOfWorkMock.Object);
            var exception = new WeatherForecastDateException(date);

            //Act
            Func<Task> handlerResult = async () => await handler.Handle(commandeRequest, default);

            //Assert
            var exceptionAssertion = await handlerResult.Should().ThrowAsync<WeatherForecastDateException>();
            exceptionAssertion.And.Message.Should().Be($"Input Date {date.ToString()} for the WeatherForecast cannot be in the past.");

        }

        [Fact]
        public async Task Handle_Should_Create_New_WeatherForecast_And_Return_WeatherForecastResponse()
        {
            //Arrange
            int temperature = -31;
            DateTime date = DateTime.Now.AddDays(4);
            string summary = "Freezing";
            var commandeRequest = new CreateWeatherForecastCommand(date, temperature, summary);
            
            var handler = new CreateWeatherForecastCommandHandler(_loggerMock.Object,
                                                               _weatherForecastRepositoryMock.Object,
                                                               _unitOfWorkMock.Object);
            //Act
            var handlerResult = await handler.Handle(commandeRequest, default);

            //Assert
            handlerResult.Should().BeOfType<WeatherForecastResponse>();
        }
    }


}
