using DTOsLayer.Concrete.ProductDtos;
using FluentValidation;

namespace BusinessLayer.ValidaitonRules.ProductValidaiton
{
    public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateDtoValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün ismi zorunludur.");
    
        }
    }
}
