
namespace Domain.WeatherForecasts
{
    public class WeatherForecast
    {
        public WeatherForecast(Guid id, DateTime date, int temperatureInCentrigrade, string summary)
        {
            Id = id;
            Date = date;
            TemperatureC = temperatureInCentrigrade;
            Summary = summary;
        }
        private WeatherForecast() 
        {
        }

        public Guid Id { get; private set; }
        public DateTime Date { get; private set; }
        public int TemperatureC { get; private set; }
        public string Summary { get; private set; } = string.Empty;
      
    }
}
