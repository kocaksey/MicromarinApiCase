using DataAccessLayer.Abstract;
using EntityLayer.Contexts;
using EntityLayer.Models.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{
    public class CategoryRepository : GenericRepository<Category>, ICategoryRepository
    {
        public CategoryRepository(ApiDbContext context) : base(context)
        {
           
        }
    }
}
