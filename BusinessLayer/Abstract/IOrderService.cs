using DTOsLayer.Concrete.OrderDtos;
using EntityLayer.Models.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IOrderService : IGenericService<OrderCreateDto, OrderUpdateDto, OrderListDto, Order>
    {
    }
}
