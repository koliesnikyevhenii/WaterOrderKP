using Newtonsoft.Json;


namespace WaterOrderKP.Models.Api
{
    public class MethodProperties
    {
        public string CityName { get; set; }
        public string Limit { get; set; }
        public string Page { get; set; }
    }

    public class NovaPoshtaRequest
    {
        public string apiKey { get; set; }
        public string modelName { get; set; }

        [JsonProperty("calledMethod")]
        public string CalledMethod { get; set; }

        [JsonProperty("methodProperties")]
        public MethodProperties MethodProperties { get; set; }
    }
}
