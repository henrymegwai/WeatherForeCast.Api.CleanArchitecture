
namespace Domain.Exceptions
{
    public class WeatherForecastNotFoundException : Exception
    {
        public WeatherForecastNotFoundException(Guid id)
           : base($"The WeatherForecast with the ID = {id} was not found")
        {
        }
    }
}
