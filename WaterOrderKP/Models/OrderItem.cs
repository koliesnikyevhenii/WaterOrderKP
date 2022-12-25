using System.ComponentModel.DataAnnotations;

namespace WaterOrderKP.Models
{
  
    public class OrderItem
    {      
        public int Id { get; set; }

        [Display(Name = "Order Date")]
        public string OrderDate { get; set; }

        [StringLength(70, ErrorMessage = "Name length can't be more than 70.")]
        public string Name { get; set; }

        [Phone]
        [StringLength(15, ErrorMessage = "PhoneNumber length can't be more than 15.")]
        [Display(Name= "Phone Number")]
        public string PhoneNumber { get; set; }

        [StringLength(200, ErrorMessage = "Address length can't be more than 200.")]
        public string Address { get; set; }

        [DataType(DataType.MultilineText)]
        [StringLength(300, ErrorMessage = "Comment length can't be more than 300.")]
        public string Comment { get; set; }

        [Range(0, 50)]
        [Display(Name = "Count Bottle")]
        public int CountBottle { get; set; }
    }
}
