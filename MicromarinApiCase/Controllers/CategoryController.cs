using BusinessLayer.Abstract;
using DTOsLayer.Concrete.CategoryDtos;
using Microsoft.AspNetCore.Mvc;

namespace MicromarinApiCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        [HttpGet("GetAllCategory")]
        public async Task<IActionResult> GetAllCategoryList()
        {
            var response = await _categoryService.GetAll();
            return Ok(response.Data);
        }
        [HttpGet("GetCategoryById{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            var response = await _categoryService.GetById<CategoryListDto>(id);
            return Ok(response.Data);
        }

        [HttpPost("AddCategory")]
        public async Task<IActionResult> CreateCategory(CategoryCreateDto dto)
        {
            await _categoryService.Create(dto);
            return Ok("Kategori başarılı bir şekilde eklendi.");
        }
        [HttpPut("UpdateCategory")]
        public async Task<IActionResult> UpdateCategory(CategoryUpdateDto dto)
        {
            await _categoryService.Update(dto);
            return Ok("Kategori başarılı bir şekilde güncellendi.");
        }

        [HttpDelete("DeleteCategory{id}")]
        public async Task<IActionResult> RemoveProduct(int id)
        {
            await _categoryService.Remove(id);

            return Ok("Kategori başarılı bir şekilde silindi");
        }
    }
}
