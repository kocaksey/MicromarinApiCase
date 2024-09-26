using BusinessLayer.Abstract;
using DTOsLayer.Concrete.OrderDetailDtos;
using Microsoft.AspNetCore.Mvc;

namespace MicromarinApiCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        [HttpGet("GetAllOrderDetail")]
        public async Task<IActionResult> GetAllOrderDetailList()
        {
            var response = await _orderDetailService.GetAll();
            return Ok(response.Data);
        }
        [HttpGet("GetOrderDetailById{id}")]
        public async Task<IActionResult> GetOrderDetailById(int id)
        {
            var response = await _orderDetailService.GetById<OrderDetailListDto>(id);
            return Ok(response.Data);
        }

        [HttpPost("AddOrderDetail")]
        public async Task<IActionResult> CreateOrderDetail(OrderDetailCreateDto dto)
        {
            await _orderDetailService.Create(dto);
            return Ok("Başarılı bir şekilde eklendi.");
        }
        [HttpPut("UpdateProduct")]
        public async Task<IActionResult> UpdateOrderDetail(OrderDetailUpdateDto dto)
        {
            await _orderDetailService.Update(dto);
            return Ok("Başarılı bir şekilde güncellendi.");
        }

        [HttpDelete("DeleteOrderDetail{id}")]
        public async Task<IActionResult> RemoveOrderDetail(int id)
        {
            await _orderDetailService.Remove(id);

            return Ok("Başarılı bir şekilde silindi");
        }
    }
}
