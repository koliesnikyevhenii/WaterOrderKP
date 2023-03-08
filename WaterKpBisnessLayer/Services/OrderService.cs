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

        public List<OrderItemBL> GetAllOrders()
        {

			var ordersDal =  orderRepository.GetAllOrders();
			foreach (var or in ordersDal)
			{
				OrderItemBL order = new OrderItemBL();
				order.Address = or.Address;
				order.Telephone = or.Telephone;
				order.Comment = or.Comment;
				// todo: finish with it

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