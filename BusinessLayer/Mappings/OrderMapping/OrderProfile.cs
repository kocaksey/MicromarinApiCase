using AutoMapper;
using DTOsLayer.Concrete.OrderDtos;
using EntityLayer.Models.Concrete;

namespace BusinessLayer.Mappings.OrderMapping
{
    public class OrderProfile : Profile
    {
        public OrderProfile()
        {
            CreateMap<Order, OrderCreateDto>().ReverseMap();
            CreateMap<Order, OrderUpdateDto>().ReverseMap();
            CreateMap<Order, OrderListDto>().ReverseMap();
            CreateMap<OrderListDto, OrderUpdateDto>().ReverseMap();



        }
    }
}
