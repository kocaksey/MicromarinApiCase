using DTOsLayer.Concrete.OrderDtos;
using DTOsLayer.Concrete.ProductDtos;
using FluentValidation;

namespace BusinessLayer.ValidaitonRules.ProductValidaiton
{
    public class OrderCreateDtoValidator : AbstractValidator<OrderCreateDto>
    {
        public OrderCreateDtoValidator()
        {
            RuleFor(x => x.CustomerId).NotEmpty().WithMessage("Müşteri Id zorunludur.");
    
        }
    }
}
