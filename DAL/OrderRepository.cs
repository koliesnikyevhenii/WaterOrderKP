using Dal;

namespace DAL
{
	public interface IOrderRepository
	{
	   List<OrderItem> GetAllOrders();
	}
	public class OrderRepository
	{
		private List<OrderItem> orders = new List<OrderItem>();
		public List<OrderItem> GetAllOrders()
		{
			
			// fill orders

			if (!orders.Any())
			{
				for (int i = 0; i < 150; i++)
				{
					var orderItem = new OrderItem
					{
						Address = Faker.Address.StreetAddress(true),
						Comment = Faker.Lorem.Sentence(),
						CountBottle = Faker.RandomNumber.Next(1, 20),
						CustomerName = Faker.Name.FullName(),
						OrderDate = new DateTime(2022, 12, Faker.RandomNumber.Next(1, 30)).ToShortDateString(),

						Id = i + 1
					};

					orderItem.Telephone = Faker.Phone.Number();
					//if (i % 2 == 0)
					//{
					//    orderItem.PhoneNumber = "+380981731016";
					//}
					//else
					//{
					//    orderItem.PhoneNumber = "+380508092413";
					//}

					orders.Add(orderItem);
				}
			}

			return orders;

		}
	}
}