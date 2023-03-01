namespace WaterOrderKP.Models.Api
{


    // Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);
    public class Address
    {
        public string Warehouses { get; set; }
        public string MainDescription { get; set; }
        public string Area { get; set; }
        public string Region { get; set; }
        public string SettlementTypeCode { get; set; }
        public string Ref { get; set; }
        public string DeliveryCity { get; set; }
    }

    public class Data
    {
        public int TotalCount { get; set; }
        public List<Address> Addresses { get; set; }
        public string Warehouses { get; set; }
        public string MainDescription { get; set; }
        public string Area { get; set; }
        public string Region { get; set; }
        public string SettlementTypeCode { get; set; }
        public string Ref { get; set; }
        public string DeliveryCity { get; set; }
    }

    public class NovaPoshatResponse
    {
        public bool success { get; set; }
        public List<Data> data { get; set; }
        public List<object> errors { get; set; }
        public List<object> warnings { get; set; }
        public List<object> info { get; set; }
        public List<object> messageCodes { get; set; }
        public List<object> errorCodes { get; set; }
        public List<object> warningCodes { get; set; }
        public List<object> infoCodes { get; set; }
    }


}
