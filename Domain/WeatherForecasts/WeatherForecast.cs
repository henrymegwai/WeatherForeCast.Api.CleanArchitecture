using Domain.WeatherForecasts;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

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

        public void Update(DateTime date, int temperatureInCentrigrade, string summary)
        {
            Date = date;
            TemperatureC = temperatureInCentrigrade;
            Summary = summary;
        }
    }
}
