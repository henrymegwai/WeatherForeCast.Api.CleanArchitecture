using Application.Dtos;
using Domain.Weathers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
