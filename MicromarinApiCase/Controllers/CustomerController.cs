using BusinessLayer.Abstract;
using DTOsLayer.Concrete.CustomerDtos;
using Microsoft.AspNetCore.Mvc;

namespace MicromarinApiCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet("GetAllCustomers")]
        public async Task<IActionResult> GetAllCustomerList()
        {
            var response = await _customerService.GetAll();
            return Ok(response.Data);
        }
        [HttpGet("GetCustomerById{id}")]
        public async Task<IActionResult> GetCustomerById(int id)
        {
            var response = await _customerService.GetById<CustomerListDto>(id);
            return Ok(response.Data);
        }

        [HttpPost("AddCustomer")]
        public async Task<IActionResult> CreateCustomer(CustomerCreateDto dto)
        {
            await _customerService.Create(dto);
            return Ok("Başarılı bir şekilde eklendi.");
        }
        [HttpPut("UpdateCustomer")]
        public async Task<IActionResult> UpdateCustomer(CustomerUpdateDto dto)
        {
            await _customerService.Update(dto);
            return Ok("Başarılı bir şekilde güncellendi.");
        }

        [HttpDelete("DeleteCustomer{id}")]
        public async Task<IActionResult> RemoveCustomer(int id)
        {
            await _customerService.Remove(id);

            return Ok("Ürün başarılı bir şekilde silindi");
        }
    }
}
