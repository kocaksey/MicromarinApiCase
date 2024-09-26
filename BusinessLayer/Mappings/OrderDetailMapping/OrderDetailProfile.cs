using AutoMapper;
using DTOsLayer.Concrete.OrderDetailDtos;
using EntityLayer.Models.Concrete;

namespace BusinessLayer.Mappings.OrderDetailMapping
{
    public class OrderDetailProfile : Profile
    {
        public OrderDetailProfile()
        {
            CreateMap<OrderDetail, OrderDetailCreateDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailUpdateDto>().ReverseMap();
            CreateMap<OrderDetail, OrderDetailListDto>().ReverseMap();
            CreateMap<OrderDetailListDto, OrderDetailUpdateDto>().ReverseMap();
        }
    }
}
