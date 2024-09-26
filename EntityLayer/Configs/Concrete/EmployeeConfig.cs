using EntityLayer.Configs.Abstract;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EntityLayer.Configs.Concrete
{
    public class EmployeeConfig : BaseConfig<Employee>
    {
        public override void Configure(EntityTypeBuilder<Employee> builder)
        {
            base.Configure(builder);
            builder.Property(p => p.Name).IsRequired().HasMaxLength(40);
            builder.Property(p => p.Title).HasMaxLength(40);
            builder.Property(p => p.Address).HasMaxLength(200);
        }
    }
}
