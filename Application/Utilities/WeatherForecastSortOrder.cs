using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Utilities
{
    public enum WeatherForecastSortOrder
    {
        [Description("Date Ascending")]
        date_asc = 1,
        [Description("Date Descending")]
        date_desc = 2
    }
}
