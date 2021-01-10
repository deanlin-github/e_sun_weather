using e_sun_weather.Application.Command.OpenWeatherDataCommand;
using e_sun_weather.Application.MapperFiles.V2V;
using e_sun_weather.DomainModel.Repository.OpenWeather;
using e_sun_weather.Infra.Core.Model.Enum;
using e_sun_weather.Infra.Core.Model.VO.OpenWeather;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace e_sun_weather.Application.Predicition
{
    public class PredictionApp : IPredictionApp
    {
        private readonly IMediator _mediator;
        private readonly IOpenWeatherPredictionRecordRepository _openWeatherPredictionRep;

        public PredictionApp(IMediator mediator,
            IOpenWeatherPredictionRecordRepository openWeatherPredictionRep)
        {
            _mediator = mediator;
            _openWeatherPredictionRep = openWeatherPredictionRep;
        }

        public async Task<List<PredictionFuture36HoursVO>> GetFeature36Hours(Location location)
        {
            // 去 Open Weather Data 平台取得資料
            var weatherPrediction = await _mediator.Send(new GetPrediction36HoursCommand(location));

            // 轉換城VO
            var future36HoursVOList = weatherPrediction.ConvertToFuture36HoursVO();

            // 轉換成Entity
            var entityList = weatherPrediction.ConvertToOpenWeatherPredictionRecord();

            // TODO：批次新增並放入command handler
            foreach (var entity in entityList)
            {
                await _openWeatherPredictionRep.AddAsync(entity);
            }

            return future36HoursVOList;
        }
    }
}
