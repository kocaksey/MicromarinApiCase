using DTOsLayer.Concrete.EmployeeDtos;
using EntityLayer.Models.Concrete;

namespace BusinessLayer.Abstract
{
    public interface IEmployeeService : IGenericService<EmployeeCreateDto, EmployeeUpdateDto, EmployeeListDto, Employee>
    {
    }
}
