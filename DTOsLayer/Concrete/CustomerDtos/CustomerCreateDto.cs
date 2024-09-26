using DTOsLayer.Abstract;
using EntityLayer.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer.Concrete.CustomerDtos
{
    internal class CustomerCreateDto :IDto
    {
        public string CompanyName { get; set; } = null!;

        public string? ContactName { get; set; }
        public string? Address { get; set; }
        public string? Phone { get; set; }
        public ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}
