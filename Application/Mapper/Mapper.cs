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
    }
}
