using System;
using System.Web.Mvc;

namespace valami.valami.Controllers
{
    public class WeatherController : Controller
    {
        [HttpGet]
        public JsonResult GetWeatherIcon(DateTime date)
        {
            string iconFile;
            switch (date.DayOfWeek)
            {
                case DayOfWeek.Monday:
                case DayOfWeek.Sunday:
                    iconFile = "nap2.png"; break;
                case DayOfWeek.Tuesday:
                case DayOfWeek.Thursday:
                    iconFile = "felho2.png"; break;
                case DayOfWeek.Wednesday:
                    iconFile = "eso2.png"; break;
                case DayOfWeek.Friday:
                case DayOfWeek.Saturday:
                    iconFile = "ho2.png"; break;
                default:
                    iconFile = "nap2.png"; break;
            }

            return Json(new { success = true, iconUrl = $"/images/{iconFile}" }, JsonRequestBehavior.AllowGet);
        }
    }
}
