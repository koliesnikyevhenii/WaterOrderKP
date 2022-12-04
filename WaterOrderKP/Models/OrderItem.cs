using System.ComponentModel.DataAnnotations;

namespace WaterOrderKP.Models
{
  
    public class OrderItem
    {      
        public int Id { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }
        public string Name { get; set; }

        [Display(Name= "Phone Number")]
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Comment { get; set; }

        [Display(Name = "Count Bottle")]
        public int CountBottle { get; set; }
    }
}
