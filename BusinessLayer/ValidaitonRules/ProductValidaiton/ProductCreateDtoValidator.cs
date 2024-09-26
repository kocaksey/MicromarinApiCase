using DTOsLayer.Concrete.ProductDtos;
using FluentValidation;

namespace BusinessLayer.ValidaitonRules.ProductValidaiton
{
    public class ProductCreateDtoValidator : AbstractValidator<ProductCreateDto>
    {
        public ProductCreateDtoValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün ismi zorunludur.");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori Id zorunludur.");
            RuleFor(x => x.UnitPrice).NotEmpty().WithMessage("Ürün birim fiyatı zorunludur.");
    
        }
    }
}
