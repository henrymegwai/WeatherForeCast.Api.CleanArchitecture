using Domain.WeatherForecasts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
