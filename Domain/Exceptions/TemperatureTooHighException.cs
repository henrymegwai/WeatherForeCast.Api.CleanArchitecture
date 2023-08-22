using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Exceptions
{
    public sealed class TemperatureTooHighException : Exception
    {
        public TemperatureTooHighException(int temperature)
        : base($"The WeatherForecast temperature {temperature} cannot be greater than 60 degrees")
        {
        }
    }
}
