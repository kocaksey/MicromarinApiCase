using DTOsLayer.Abstract;
using EntityLayer.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer.Concrete.OrderDtos
{
    public class OrderCreateDto : IDto
    {
        public string CustomerId { get; set; }

        public int? EmployeeId { get; set; }
        public Customer Customer { get; set; }

        public Employee Employee { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
