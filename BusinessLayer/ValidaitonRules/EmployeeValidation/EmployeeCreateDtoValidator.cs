using DTOsLayer.Concrete.EmployeeDtos;
using DTOsLayer.Concrete.ProductDtos;
using FluentValidation;

namespace BusinessLayer.ValidaitonRules.ProductValidaiton
{
    public class EmployeeCreateDtoValidator : AbstractValidator<EmployeeCreateDto>
    {
        public EmployeeCreateDtoValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Çalışan ismi zorunludur.");
    
        }
    }
}
