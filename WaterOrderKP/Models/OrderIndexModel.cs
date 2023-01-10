namespace WaterOrderKP.Models
{
    public class OrderIndexModel
    {
        public bool IsBottleCountDesc { get; set; }
        public List<OrderItem> Orders { get; set; }
    }
}
