using DTOsLayer.Abstract;
using EntityLayer.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer.Concrete.ProductDtos
{
    public class ProductUpdateDto : IDto
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
