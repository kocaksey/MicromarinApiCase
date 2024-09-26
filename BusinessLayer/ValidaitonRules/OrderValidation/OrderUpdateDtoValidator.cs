using DTOsLayer.Concrete.OrderDtos;
using DTOsLayer.Concrete.ProductDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidaitonRules.ProductValidaiton
{
    public class OrderUpdateDtoValidator : AbstractValidator<OrderUpdateDto>
    {
        public OrderUpdateDtoValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Müşteri Id zorunludur.");
        }
    }
}
