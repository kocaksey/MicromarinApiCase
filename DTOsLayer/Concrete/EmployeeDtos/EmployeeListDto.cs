using DTOsLayer.Abstract;
using EntityLayer.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer.Concrete.EmployeeDtos
{
    public class EmployeeListDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? Title { get; set; }

        public string? Address { get; set; }

        public ICollection<Order> Orders { get; set; } = new List<Order>();

    }
}
