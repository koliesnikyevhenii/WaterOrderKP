namespace WaterOrderKP.Models
{
    public class EditOrderItemModel
    {
        public string Name { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime OrderDate { get; set; } 

        public string Address { get; set; }

        public int CountBottle { get; set; }

        public string Comment { get; set; }
    }
}
