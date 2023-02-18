namespace WaterOrderKP.Models
{
    public class HomeworkModel
    {
        public HomeworkModel()
        {
            countryDetails = new CountryDetails();
        }
        public string country { get; set; }
        public string city { get; set; }
        
        public CountryDetails countryDetails { get; set; }
        
    }
    public class CountryDetails
    {
        public string Population => "1000 people";
        public int Teritory => 2000;
        
    }
   
}
