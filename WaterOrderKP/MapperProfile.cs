using AutoMapper;
using WaterKpBisnessLayer.ModelsBL;
using WaterOrderKP.Models;

namespace WaterOrderKP
{
	public class MapperProfile : Profile
	{
		public MapperProfile()
		{
			// Add as many of these lines as you need to map your objects
			CreateMap<OrderItemModel, OrderItemBL>();
			CreateMap<OrderItemBL, OrderItemModel>()
				.ForMember(dest => dest.PhoneNumber, source => source.MapFrom(x => x.Telephone))
				.ForMember(dest => dest.Name, source => source.MapFrom(x => x.CustomerName));

		}
	}
}
