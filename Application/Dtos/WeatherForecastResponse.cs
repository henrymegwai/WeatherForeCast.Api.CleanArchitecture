using Domain.WeatherForecasts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Dtos
{
    public record WeatherForecastResponse(
        Guid Id, 
        DateTime date, 
        int temperatureInCentrigrade, 
        string summary);
    
}
