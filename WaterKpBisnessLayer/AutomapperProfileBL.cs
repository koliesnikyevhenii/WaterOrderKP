using AutoMapper;
using Dal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WaterKpBisnessLayer.ModelsBL;

namespace WaterKpBisnessLayer
{
	public class AutomapperProfileBL : Profile
	{
		public AutomapperProfileBL()
		{
			CreateMap<OrderItemBL, OrderItem>();
			CreateMap<OrderItem, OrderItemBL>();
		}
	}
}
