using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class TemperatureTooLowException : Exception
    {
        public TemperatureTooLowException(int temperature)
        : base($"The WeatherForecast temperature {temperature} must be less that -60 degrees")
        {
        }
    }
}
