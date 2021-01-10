using e_sun_weather.Infra.Core.Model.Enum;
using e_sun_weather.Infra.Core.Model.VO.OpenWeather;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace e_sun_weather.Application.Predicition
{
    public interface IPredictionApp
    {
        Task<List<PredictionFuture36HoursVO>> GetFeature36Hours(Location location);
    }
}
