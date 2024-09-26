using EntityLayer.Configs.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityLayer.Configs.Concrete
{
    public class ProductConfig : BaseConfig<Product>
    {
        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.ProductName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.CategoryId).IsRequired();
            builder.Property(p => p.UnitPrice).IsRequired();
        }
    }
}
