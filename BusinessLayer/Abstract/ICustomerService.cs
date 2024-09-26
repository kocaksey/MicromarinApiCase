using DTOsLayer.Concrete.CustomerDtos;
using EntityLayer.Models.Concrete;

namespace BusinessLayer.Abstract
{
    public interface ICustomerService : IGenericService<CustomerCreateDto, CustomerUpdateDto, CustomerListDto, Customer>
    {
    }
}
