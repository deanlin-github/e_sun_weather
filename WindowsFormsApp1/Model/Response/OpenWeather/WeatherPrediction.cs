using e_sun_weather.Infra.Core.Model.Enum;
using e_sun_weather.Infra.Core.Model.Enum.OpenWeather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_sun_weather.Infra.Core.Model.Response.OpenWeather
{
    /// <summary>
    /// 一般天氣預報-今明 36 小時天氣預報 Response
    /// </summary>
    public class WeatherPrediction
    {
        public bool success { get; set; }

        public WeatherPredictionResult result { get; set; }

        public WeatherPredictionRecord records { get; set; }
    }

    public class WeatherPredictionResult
    {
        public string resource_id { get; set; }
        public List<Field> fields { get; set; }
    }

    public class Field
    {
        public string id { get; set; }
        public string type { get; set; }
    }

    public class WeatherPredictionRecord
    {
        public string datasetDescription { get; set; }
        
        public List<LocationData> location { get; set; }
    }

    public class LocationData
    {
        public Location locationName { get; set; }
        
        public List<WeatherElement> weatherElement { get; set; }
    }

    public class WeatherElement
    {
        public Element elementName { get; set; }

        public List<Time> time { get; set; }
    }

    public class Time
    {
        public DateTime startTime { get; set; }
        public DateTime endTime { get; set; }
        public Parameter parameter { get; set; }
    }

    public class Parameter
    {
        public string parameterName { get; set; }

        public string parameterValue { get; set; }

        public string parameterUnit { get; set; }
    }
}
