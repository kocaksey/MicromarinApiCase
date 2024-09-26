using DTOsLayer.Concrete.OrderDetailDtos;
using DTOsLayer.Concrete.ProductDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidaitonRules.ProductValidaiton
{
    public class OrderDetailUpdateDtoValidator : AbstractValidator<OrderDetailUpdateDto>
    {
        public OrderDetailUpdateDtoValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Ürün Id zorunludur.");
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Sipariş adeti zorunludur.");
        }
    }
}
