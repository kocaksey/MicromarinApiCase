using BusinessLayer.Abstract;
using DTOsLayer.Concrete.ProductDtos;
using Microsoft.AspNetCore.Mvc;

namespace MicromarinApiCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllProductList()
        {
            var response = await _productService.GetAll();
            return Ok(response.Data);
        }
        [HttpGet("GetProductById{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var response = await _productService.GetById<ProductListDto>(id);
            return Ok(response.Data);
        }
        [HttpGet("GetProductsByCategory{categoryId}")]
        public async Task<IActionResult> GetProductsByCategory(int categoryId)
        {
            var response = await _productService.GetProductsByCategory(categoryId);
            return Ok(response.Data);
        }

        [HttpPost("AddProduct")]
        public async Task<IActionResult> CreateProduct(ProductCreateDto dto)
        {
            await _productService.Create(dto);
            return Ok("Ürün başarılı bir şekilde eklendi.");
        }
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateProduct(ProductUpdateDto dto)
        {
            await _productService.Update(dto);
            return Ok("ürün başarılı bir şekilde güncellendi.");
        }

        [HttpDelete("DeleteProduct{id}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            await _productService.Remove(id);

            return Ok("Ürün başarılı bir şekilde silindi");
        }
    }
}
