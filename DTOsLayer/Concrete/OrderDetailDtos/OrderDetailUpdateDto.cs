using DTOsLayer.Abstract;
using EntityLayer.Models.Concrete;

namespace DTOsLayer.Concrete.OrderDetailDtos
{
    public class OrderDetailUpdateDto : IDto
    {
        public int Id { get; set; }
        public int ProductId { get; set; }

        public short Quantity { get; set; }


        public Order Order { get; set; } = null!;

        public Product Product { get; set; } = null!;
    }
}
