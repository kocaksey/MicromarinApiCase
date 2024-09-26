using EntityLayer.Configs.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityLayer.Configs.Concrete
{
    public class OrderConfig : BaseConfig<Order>
    {
        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.CustomerId).IsRequired();
        }
    }
}
