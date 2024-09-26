using AutoMapper;
using DTOsLayer.Concrete.EmployeeDtos;
using EntityLayer.Models.Concrete;

namespace BusinessLayer.Mappings.EmployeeMapping
{
    public class EmployeeProfile : Profile
    {
        public EmployeeProfile()
        {
            CreateMap<Employee, EmployeeCreateDto>().ReverseMap();
            CreateMap<Employee, EmployeeUpdateDto>().ReverseMap();
            CreateMap<Employee, EmployeeListDto>().ReverseMap();
            CreateMap<EmployeeListDto, EmployeeUpdateDto>().ReverseMap();
        }
    }
}
