using DTOsLayer.Abstract;
using EntityLayer.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTOsLayer.Concrete.CategoryDtos
{
    public class CategoryCreateDto :IDto
    {
        public string CategoryName { get; set; } = null!;

        public string? Description { get; set; }

        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
