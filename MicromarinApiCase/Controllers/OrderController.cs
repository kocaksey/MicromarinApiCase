using BusinessLayer.Abstract;
using DTOsLayer.Concrete.OrderDtos;
using Microsoft.AspNetCore.Mvc;

namespace MicromarinApiCase.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpGet("GetAllOrders")]
        public async Task<IActionResult> GetAllOrderList()
        {
            var response = await _orderService.GetAll();
            return Ok(response.Data);
        }
        [HttpGet("GetOrderById{id}")]
        public async Task<IActionResult> GetOrderById(int id)
        {
            var response = await _orderService.GetById<OrderListDto>(id);
            return Ok(response.Data);
        }
        [HttpPost("AddOrder")]
        public async Task<IActionResult> CreateOrder(OrderCreateDto dto)
        {
            await _orderService.Create(dto);
            return Ok("Başarılı bir şekilde eklendi.");
        }
        [HttpPut("UpdateOrder")]
        public async Task<IActionResult> UpdateOrder(OrderUpdateDto dto)
        {
            await _orderService.Update(dto);
            return Ok("Başarılı bir şekilde güncellendi.");
        }

        [HttpDelete("DeleteOrder{id}")]
        public async Task<IActionResult> RemoveOrder(int id)
        {
            await _orderService.Remove(id);

            return Ok("Başarılı bir şekilde silindi");
        }
    }
}
