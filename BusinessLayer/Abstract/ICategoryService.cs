using DTOsLayer.Concrete.CategoryDtos;
using EntityLayer.Models.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService : IGenericService<CategoryCreateDto, CategoryUpdateDto, CategoryListDto, Category>
    {
    }
}
