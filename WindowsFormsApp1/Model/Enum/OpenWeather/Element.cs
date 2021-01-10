using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_sun_weather.Infra.Core.Model.Enum.OpenWeather
{
    public enum Element
    {
        [Description("天氣現象")]
        Wx = 1,

        [Description("最高溫度")]
        MaxT = 2,

        [Description("最低溫度")]
        MinT = 3,

        [Description("舒適度")]
        CI = 4,

        [Description("降雨機率")]
        PoP = 5
    }
}
