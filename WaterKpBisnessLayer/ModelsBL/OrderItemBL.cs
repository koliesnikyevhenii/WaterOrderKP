using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace WaterKpBisnessLayer.ModelsBL
{
	public class OrderItemBL
	{
		public int Id { get; set; }

		public string OrderDate { get; set; }	
	
		public string Telephone { get; set; }
		
		public string Address { get; set; }
	
		public string Comment { get; set; }

		public string CustomerName { get; set; }

		public int CountBottle { get; set; }

		public bool IsDelivered { get; set; }

		public decimal DiscountPrice { get; set; }
		public decimal OrderPrice { get; set; }


	}
}
