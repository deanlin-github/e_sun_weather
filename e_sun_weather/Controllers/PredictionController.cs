using e_sun_weather.Application.Predicition;
using e_sun_weather.Infra.Core.Model.Enum;
using e_sun_weather.Infra.Core.Model.VO.OpenWeather;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace e_sun_weather.Controllers
{
    public class PredictionController : BaseController
    {
        private IPredictionApp _predictionApp;

        public PredictionController(IPredictionApp predictionApp)
        {
            _predictionApp = predictionApp;
        }
        // GET: Predicition
        public ActionResult Index()
        {
            return RedirectToAction("PredictionFuture36Hours", Location.臺北市);
        }


        public async Task<ActionResult> PredictionFuture36Hours(Location location = Location.臺北市)
        {
            try
            {
                ViewBag.Location = GetSelectList<Location>(location);
                var list = await _predictionApp.GetFeature36Hours(location);
                return View(list);
            }
            catch (Exception ex)
            {
                return ErrorProcess(ex.Message);
            }
        }
    }
}