using Application.Dtos;
using Domain.WeatherForecasts;

namespace Application.Mapper
{
    public static class Mapper
    {
        public static WeatherForecastResponse Map(this WeatherForecast model)
        {
            if (model == null)
                return null;
            return new WeatherForecastResponse(model.Id, model.Date, model.TemperatureC, model.Summary);
        } 
        public static WeatherForecastFilterQueryResponse MapFilter(this WeatherForecast model)
        {
            if (model == null)
                return new WeatherForecastFilterQueryResponse { };
            return new WeatherForecastFilterQueryResponse
            {
                temperatureInCentrigrade = model.TemperatureC,
                Summary = model.Summary, 
                date = model.Date.ToString("ddd, dd MMMM yyyy")

            };
        }
    }
}
