using e_sun_weather.DomainModel.AggregatesModel.OpenWeather;
using e_sun_weather.Infra.Core.Model.Enum;
using e_sun_weather.Infra.Core.Model.Enum.OpenWeather;
using e_sun_weather.Infra.Core.Model.Response.OpenWeather;
using e_sun_weather.Infra.Core.Model.VO.OpenWeather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_sun_weather.Application.MapperFiles.V2V
{
    public static class OpenWeatherProfile
    {
        /// <summary>
        /// WeatherPrediction TO PredictionFuture36HoursVO
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        public static List<PredictionFuture36HoursVO> ConvertToFuture36HoursVO(this WeatherPrediction model)
        {
            var returnVO = new List<PredictionFuture36HoursVO>();

            var datasetDescription = model.records.datasetDescription;
            var locations = model.records.location;
            var forLock = "";

            Parallel.ForEach(locations, location =>
            {
                Parallel.ForEach(location.weatherElement, element =>
                {
                    Parallel.ForEach(element.time, time =>
                    {
                        var vo = new PredictionFuture36HoursVO
                        {
                            DataDescription = datasetDescription,
                            LocationName = location.locationName,
                            ElementName = element.elementName,
                            StartTime = time.startTime,
                            EndTime = time.endTime,
                            ParameterName = time.parameter.parameterName,
                            ParameterUnit = time.parameter.parameterUnit,
                            ParameterValue = time.parameter.parameterValue
                        };

                        lock (forLock)
                            returnVO.Add(vo);
                    });
                });
            });

            return returnVO;
        }

        public static List<OpenWeatherPredictionRecord> ConvertToOpenWeatherPredictionRecord(this WeatherPrediction model)
        {
            var returnVO = new List<OpenWeatherPredictionRecord>();

            var resourceID = model.result.resource_id;
            var datasetDescription = model.records.datasetDescription;
            var locations = model.records.location;
            var forLock = "";

            Parallel.ForEach(locations, location =>
            {
                Parallel.ForEach(location.weatherElement, element =>
                {
                    Parallel.ForEach(element.time, time =>
                    {
                        var vo = new OpenWeatherPredictionRecord
                        {
                            ResourceID = resourceID,
                            DataDescription = datasetDescription,
                            Location = location.locationName,
                            Element = element.elementName,
                            StartTime = time.startTime,
                            EndTime = time.endTime,
                            ParameterName = time.parameter.parameterName,
                            ParameterUnit = time.parameter.parameterUnit,
                            ParameterValue = time.parameter.parameterValue,
                            CreateTime = DateTime.Now
                        };

                        lock (forLock)
                            returnVO.Add(vo);
                    });
                });
            });

            return returnVO;
        }
    }
}
