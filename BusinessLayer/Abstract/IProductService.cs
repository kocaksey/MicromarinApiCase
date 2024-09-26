using CommonLayer.ResponseObjects;
using DTOsLayer.Concrete.ProductDtos;
using EntityLayer.Models.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IProductService : IGenericService<ProductCreateDto, ProductUpdateDto, ProductListDto, Product>
    {
        Task<IResponse<List<ProductListDto>>> GetProductsByCategory(int categoryId);
    }
}
