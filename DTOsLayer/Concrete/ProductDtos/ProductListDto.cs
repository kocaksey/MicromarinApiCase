using DTOsLayer.Abstract;
using EntityLayer.Models.Concrete;

namespace DTOsLayer.Concrete.ProductDtos
{
    public class ProductListDto : IDto
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = null!;

        public int CategoryId { get; set; }

        public double UnitPrice { get; set; }

        public short? UnitsInStock { get; set; }

        public Category Category { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
