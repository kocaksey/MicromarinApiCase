using EntityLayer.Configs.Concrete;
using EntityLayer.Models.Concrete;
using Microsoft.EntityFrameworkCore;

namespace EntityLayer.Contexts
{
    public class ApiDbContext :DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CategoryConfig ());
            modelBuilder.ApplyConfiguration(new CustomerConfig());
            modelBuilder.ApplyConfiguration(new EmployeeConfig());
            modelBuilder.ApplyConfiguration(new OrderConfig());
            modelBuilder.ApplyConfiguration(new OrderDetailConfig());
            modelBuilder.ApplyConfiguration(new ProductConfig());
        }
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<Employee> Employees { get; set; } 
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; } 
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

       
    }
}
