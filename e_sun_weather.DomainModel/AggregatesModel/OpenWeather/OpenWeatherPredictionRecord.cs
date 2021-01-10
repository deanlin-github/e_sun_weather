using e_sun_weather.DomainModel.Repository;
using e_sun_weather.Infra.Core.Model.Enum;
using e_sun_weather.Infra.Core.Model.Enum.OpenWeather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_sun_weather.DomainModel.AggregatesModel.OpenWeather
{
    public class OpenWeatherPredictionRecord : IAggregate
    {
        public long ID { get; set; }

        public string ResourceID { get; set; }

        public string DataDescription { get; set; }

        public Location Location { get; set; }

        public Element Element { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
        public string ParameterName { get; set; }
        public string ParameterValue { get; set; }
        public string ParameterUnit { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
