using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace e_sun_weather.Controllers
{
    public class BaseController : Controller
    {
        public ActionResult ErrorProcess(string exceptionMsg)
        {
            return View(exceptionMsg);
        }

        public static List<SelectListItem> GetSelectList<T>(object selected)
        {
            Array values = Enum.GetValues(typeof(T));
            List<SelectListItem> items = new List<SelectListItem>(values.Length);

            foreach (var i in values)
            {
                var iString = i.ToString();
                var selectedString = selected.ToString();
                var isSelected = iString == selectedString;
                items.Add(new SelectListItem
                {
                    Text = Enum.GetName(typeof(T), i),
                    Value = i.ToString(),
                    Selected = isSelected
                });
            }

            return items;
        }
    }
}