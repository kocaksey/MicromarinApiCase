using EntityLayer.Configs.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityLayer.Configs.Concrete
{
    public class CustomerConfig : BaseConfig<Customer>
    {
        public override void Configure(EntityTypeBuilder<Customer> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.CompanyName).IsRequired().HasMaxLength(50);
            builder.Property(p => p.ContactName).HasMaxLength(50);
            builder.Property(p => p.Address).HasMaxLength(250);
            builder.Property(p => p.Phone).HasMaxLength(30);
        }
    }
}
