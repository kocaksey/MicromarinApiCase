using EntityLayer.Models.Abstract;

namespace EntityLayer.Models.Concrete
{
    public class OrderDetail : BaseEntity
    {
        public int ProductId { get; set; }

        public short Quantity { get; set; }


        public Order Order { get; set; } = null!;

        public Product Product { get; set; } = null!;
    }
}
