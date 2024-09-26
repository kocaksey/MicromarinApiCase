using AutoMapper;
using DTOsLayer.Concrete.CategoryDtos;
using EntityLayer.Models.Concrete;

namespace BusinessLayer.Mappings.CategoryMapping
{
    public class CategoryProfile : Profile
    {
        public CategoryProfile()
        {
            CreateMap<Category, CategoryCreateDto>().ReverseMap();
            CreateMap<Category, CategoryUpdateDto>().ReverseMap();
            CreateMap<Category, CategoryListDto>().ReverseMap();
            CreateMap<CategoryListDto, CategoryUpdateDto>().ReverseMap();
        }

    }
}
