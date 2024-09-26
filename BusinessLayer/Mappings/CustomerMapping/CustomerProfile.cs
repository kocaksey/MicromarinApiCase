using AutoMapper;
using DTOsLayer.Concrete.CustomerDtos;
using EntityLayer.Models.Concrete;

namespace BusinessLayer.Mappings.CustomerMapping
{
    public class CustomerProfile : Profile
    {
        public CustomerProfile()
        {
            CreateMap<Customer, CustomerCreateDto>().ReverseMap();
            CreateMap<Customer, CustomerUpdateDto>().ReverseMap();
            CreateMap<Customer, CustomerListDto>().ReverseMap();
            CreateMap<CustomerListDto, CustomerUpdateDto>().ReverseMap();
        }

    }
}
