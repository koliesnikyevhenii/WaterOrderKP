using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileSystemGlobbing;
using Newtonsoft.Json;
using RestSharp;
using WaterOrderKP.Models;

namespace WaterOrderKP.Component
{   
    public class WeatherViewComponent : ViewComponent
    {
        RestClient _client;
        string baseUrl = "https://localhost:7096/";
        string source = "/WeatherForecast/Wather";
        public async Task<IViewComponentResult> InvokeAsync()
        {
            
            _client = new RestClient(baseUrl);
            RestRequest request = new RestRequest(source, Method.Get);

            return View("WeatherBlock", new WeatherModel());
            var response = _client.Get<List<WeatherModel>>(request);
            var responseItem = response.FirstOrDefault();
            
            WeatherModel model = new WeatherModel();
            model.TemperatureC = responseItem.TemperatureC;
            model.Summary = responseItem.Summary;
            model.Date = responseItem.Date;
            // model api request 

            return View("WeatherBlock", model);
        }
    }
}
