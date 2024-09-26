using DTOsLayer.Concrete.OrderDetailDtos;
using DTOsLayer.Concrete.ProductDtos;
using FluentValidation;

namespace BusinessLayer.ValidaitonRules.ProductValidaiton
{
    public class OrderDetailCreateDtoValidator : AbstractValidator<OrderDetailCreateDto>
    {
        public OrderDetailCreateDtoValidator()
        {
            RuleFor(x => x.ProductId).NotEmpty().WithMessage("Ürün Id zorunludur.");
            RuleFor(x => x.Quantity).NotEmpty().WithMessage("Sipariş adeti zorunludur.");
    
        }
    }
}
