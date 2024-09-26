using DTOsLayer.Concrete.CustomerDtos;
using DTOsLayer.Concrete.ProductDtos;
using FluentValidation;

namespace BusinessLayer.ValidaitonRules.ProductValidaiton
{
    public class CustomerCreateDtoValidator : AbstractValidator<CustomerCreateDto>
    {
        public CustomerCreateDtoValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Firma ismi zorunludur.");
    
        }
    }
}
