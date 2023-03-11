using AutoMapper;
using DAL;
using WaterKpBisnessLayer.ModelsBL;

namespace WaterKpBisnessLayer.Services
{

    public interface IOrderService
    {
        public void CreateOrder();
        public List<OrderItemBL> GetAllOrders();

	}
    public class OrderService : IOrderService
	{
		public static List<OrderItemBL> orders = new List<OrderItemBL>();
        private OrderRepository orderRepository = new OrderRepository();
		private readonly IMapper _mapper;

		public OrderService() 
		{
			var mapperConfig = new MapperConfiguration(mc =>
			{
				mc.AddProfile(new AutomapperProfileBL());

			});

			_mapper = mapperConfig.CreateMapper();
		}

        public List<OrderItemBL> GetAllOrders()
        {

			var ordersDal =  orderRepository.GetAllOrders();

			foreach (var or in ordersDal)
			{
				var order = _mapper.Map<OrderItemBL>(or);
				orders.Add(order);
			}

			return orders;

		}

		public void CreateOrder() {

			//CalculateDiscount()
            //save to db
		}

		private void CalculateDiscount()
        { 

        }
    }
}