using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using EntityLayer.Contexts;
using EntityLayer.Models.Abstract;

namespace DataAccessLayer.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly ApiDbContext _context;

        public Uow(ApiDbContext context)
        {
            _context = context;
        }      
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
    }
}
