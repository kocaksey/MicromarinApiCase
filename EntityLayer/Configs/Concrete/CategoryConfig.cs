using EntityLayer.Configs.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityLayer.Configs.Concrete
{
    public class CategoryConfig : BaseConfig<Category>
    {
        public override void Configure(EntityTypeBuilder<Category> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.CategoryName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.Description).HasMaxLength(150);

        }
    }
}
