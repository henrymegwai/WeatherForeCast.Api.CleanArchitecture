using Domain.WeatherForecasts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public class WeatherForecastDateException : Exception
    {
        public WeatherForecastDateException(DateTime date)
           : base($"Input Date {date.ToString()} for the WeatherForecast cannot be in the past.")
        {
        }
    }
}
