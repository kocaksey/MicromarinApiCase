using DTOsLayer.Concrete.ProductDtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidaitonRules.ProductValidaiton
{
    public class ProductUpdateDtoValidator : AbstractValidator<ProductUpdateDto>
    {
        public ProductUpdateDtoValidator()
        {
            RuleFor(x => x.ProductName).NotEmpty().WithMessage("Ürün ismi zorunludur.");
            RuleFor(x => x.CategoryId).NotEmpty().WithMessage("Kategori Id zorunludur.");
            RuleFor(x => x.UnitPrice).NotEmpty().WithMessage("Ürün birim fiyatı zorunludur.");
        }
    }
}
