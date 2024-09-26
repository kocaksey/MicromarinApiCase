using EntityLayer.Models.Abstract;

namespace EntityLayer.Models.Concrete
{
    public class Order : BaseEntity
    {
        public int CustomerId { get; set; }

        public int? EmployeeId { get; set; }
        public Customer Customer { get; set; }

        public Employee Employee { get; set; }

        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
    }
}
