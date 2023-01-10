namespace WaterOrderKP.Models
{
    public class OrderIndexModel
    {
        public OrderIndexModel()
        {
            CurrentPage = 1;
        }

        public bool IsBottleCountDesc { get; set; }
        public List<OrderItem> Orders { get; set; }

        public int CurrentPage { get; set; }
        public int AmountOfPage { get; set; }
    }
}
