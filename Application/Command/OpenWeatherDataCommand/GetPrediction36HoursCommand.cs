using e_sun_weather.Infra.Core.Model.Response.OpenWeather;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace e_sun_weather.Application.Command.OpenWeatherDataCommand
{
    public class GetPrediction36HoursCommand : IRequest<WeatherPrediction>
    {
        // TODO：other parameter
        public string City { get; private set; }

        public GetPrediction36HoursCommand(string City)
        {
            this.City = City;
        }
    }
}
