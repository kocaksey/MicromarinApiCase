using EntityLayer.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models.Concrete
{
    public class Customer : BaseEntity
    {
        public string CompanyName { get; set; } = null!;

        public string? ContactName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public  ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
