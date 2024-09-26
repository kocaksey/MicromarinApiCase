using DTOsLayer.Concrete.OrderDetailDtos;
using EntityLayer.Models.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IOrderDetailService : IGenericService<OrderDetailCreateDto, OrderDetailUpdateDto, OrderDetailListDto, OrderDetail>
    {
    }
}
