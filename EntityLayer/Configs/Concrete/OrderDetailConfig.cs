using EntityLayer.Configs.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityLayer.Configs.Concrete
{
    public class OrderDetailConfig : BaseConfig<OrderDetail>
    {
        public override void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.ProductId).IsRequired();
        }
    }
}
