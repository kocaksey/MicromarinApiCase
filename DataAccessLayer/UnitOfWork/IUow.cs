using DataAccessLayer.Abstract;
using EntityLayer.Models.Abstract;

namespace DataAccessLayer.UnitOfWork
{
    public interface IUow 
    {
        Task SaveChanges();
    }
}
