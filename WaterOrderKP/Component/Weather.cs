using Microsoft.AspNetCore.Mvc;
using WaterOrderKP.Models;

namespace WaterOrderKP.Component
{   
    public class WeatherViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            WeatherModel model = new WeatherModel();
            model.TemperatureC = 30;
            model.Summary = "ball";
            model.Date = DateTime.Now;
            // model api request 

            return View("WeatherBlock", model);
        }
    }
}
