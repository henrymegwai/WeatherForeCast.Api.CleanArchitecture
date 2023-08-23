﻿using Domain.WeatherForecasts;
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

    public class WeatherForecastFilterQueryResponse 
    { 
        public int temperatureInCentrigrade { get; set; }
        public string Summary { get; set; } = string.Empty;
        public string date { get; set; } = string.Empty;
    }
}
