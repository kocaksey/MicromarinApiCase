using BusinessLayer.Abstract;
using DTOsLayer.Concrete.EmployeeDtos;
using DTOsLayer.Concrete.ProductDtos;
using Microsoft.AspNetCore.Mvc;

namespace MicromarinApiCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet("GetAllEmployee")]
        public async Task<IActionResult> GetAllEmployeeList()
        {
            var response = await _employeeService.GetAll();
            return Ok(response.Data);
        }
        [HttpGet("GetEmployeeById{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var response = await _employeeService.GetById<EmployeeListDto>(id);
            return Ok(response.Data);
        }

        [HttpPost("Addemployee")]
        public async Task<IActionResult> Createemployee(EmployeeCreateDto dto)
        {
            await _employeeService.Create(dto);
            return Ok("Başarılı bir şekilde eklendi.");
        }
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> Updateemployee(EmployeeUpdateDto dto)
        {
            await _employeeService.Update(dto);
            return Ok("ÇBaşarılı bir şekilde güncellendi.");
        }

        [HttpDelete("Deleteemployee{id}")]
        public async Task<IActionResult> RemoveEmployee(int id)
        {
            await _employeeService.Remove(id);

            return Ok("Başarılı bir şekilde silindi");
        }
    }
}
