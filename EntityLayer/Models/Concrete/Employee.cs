using EntityLayer.Models.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Models.Concrete
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string? Title { get; set; }

        public string? Address { get; set; }

        public  ICollection<Order> Orders { get; set; } = new List<Order>();


    }
}
