using e_sun_weather.Infra.Core.Model.Enum;
using e_sun_weather.Infra.Core.Model.Enum.OpenWeather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_sun_weather.Infra.Core.Model.VO.OpenWeather
{
    public class PredictionFuture36HoursVO
    {
        public string DataDescription { get; set; }

        public Location LocationName { get; set; }

        public Element ElementName { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }

        public string ParameterName { get; set; }

        public string ParameterValue { get; set; }

        public string ParameterUnit { get; set; }
    }
}
