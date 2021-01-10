using e_sun_weather.Infra.Core.Componets.HttpClientTool;
using e_sun_weather.Infra.Core.Model.Response.OpenWeather;
using MediatR;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace e_sun_weather.Application.Command.OpenWeatherDataCommand
{
    public class GetPrediction36HoursCommandHandler : IRequestHandler<GetPrediction36HoursCommand, WeatherPrediction>
    {
        private readonly InfraHttpClient httpClient;

        public GetPrediction36HoursCommandHandler(InfraHttpClient httpClient)
        {
            this.httpClient = httpClient;
        }

        public async Task<WeatherPrediction> Handle(GetPrediction36HoursCommand request, CancellationToken cancellationToken)
        {
            // 串 Open Weather Data 參數
            var authorization = ConfigurationManager.AppSettings["OWDAuthorization"];
            var domain = ConfigurationManager.AppSettings["OWDDomain"];
            var path = $"F-C0032-001";
            var url = $"{domain}{path}?Authorization={authorization}&locationName={request.Location.ToString()}";

            // 取得資料
            var result = await httpClient.Get<WeatherPrediction>(url);

            return result;
        }
    }
}
