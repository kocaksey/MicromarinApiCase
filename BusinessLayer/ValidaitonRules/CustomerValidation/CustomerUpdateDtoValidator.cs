using DTOsLayer.Concrete.CustomerDtos;
using DTOsLayer.Concrete.ProductDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidaitonRules.ProductValidaiton
{
    public class CustomerUpdateDtoValidator : AbstractValidator<CustomerUpdateDto>
    {
        public CustomerUpdateDtoValidator()
        {
            RuleFor(x => x.CompanyName).NotEmpty().WithMessage("Firma ismi zorunludur.");
        }
    }
}
