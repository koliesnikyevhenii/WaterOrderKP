using Microsoft.AspNetCore.Mvc;
using RestSharp;
using System.Reflection.Metadata;
using Twilio.Rest.Api.V2010.Account.Usage.Record;
using WaterOrderKP.Models.Api;

namespace WaterOrderKP.Controllers
{
    public class NovaPoshtaController : Controller
    {

        // TODO: move to config file
        private readonly string _novaPoshtaEndPoint = "https://api.novaposhta.ua/v2.0/json/";
        private readonly string _apiKey = "84795cbd304d2466f6f1674d4974a376";
        private readonly string _calledMethod = "searchSettlements";


        public IActionResult SearchSettlements()
        {
            RestClient restClient = new RestClient(_novaPoshtaEndPoint);

            var request = new NovaPoshtaRequest
            {
                apiKey = _apiKey,
                CalledMethod = _calledMethod,
                modelName = "Address",
                MethodProperties = new MethodProperties
                {
                    CityName = "Красно",
                    Limit = "50",
                    Page = "1"
                }
            };

            var restRequest = new RestRequest("", method: Method.Get);
            restRequest.AddBody(request);

            var response = restClient.Get<NovaPoshatResponse>(restRequest);


            return View();
        }
    }
}
