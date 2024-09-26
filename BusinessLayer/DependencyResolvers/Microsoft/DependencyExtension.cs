using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Mappings.CategoryMapping;
using BusinessLayer.Mappings.CustomerMapping;
using BusinessLayer.Mappings.EmployeeMapping;
using BusinessLayer.Mappings.OrderDetailMapping;
using BusinessLayer.Mappings.OrderMapping;
using BusinessLayer.Mappings.ProductMapping;
using BusinessLayer.ValidaitonRules.ProductValidaiton;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.UnitOfWork;
using DTOsLayer.Concrete.CategoryDtos;
using DTOsLayer.Concrete.CustomerDtos;
using DTOsLayer.Concrete.EmployeeDtos;
using DTOsLayer.Concrete.OrderDetailDtos;
using DTOsLayer.Concrete.OrderDtos;
using DTOsLayer.Concrete.ProductDtos;
using EntityLayer.Contexts;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace BusinessLayer.DependencyResolvers.Microsoft
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services)
        {
            services.AddDbContext<ApiDbContext>(opt =>
            {
                opt.UseSqlServer("server=(localdb)\\mssqllocaldb; database=MicromarinApiDB; integrated security=true;trusted_connection=true;TrustServerCertificate=true");
                opt.LogTo(Console.WriteLine, LogLevel.Information);
            });

            var configuration = new MapperConfiguration(opt =>
            {
                opt.AddProfile(new ProductProfile());
                opt.AddProfile(new CategoryProfile());
                opt.AddProfile(new EmployeeProfile());
                opt.AddProfile(new OrderDetailProfile());
                opt.AddProfile(new OrderProfile());
                opt.AddProfile(new CustomerProfile());



            });

            var mapper = configuration.CreateMapper();

            services.AddSingleton(mapper);

            services.AddScoped<IUow, Uow>();

            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();

            services.AddScoped<ICustomerService, CustomerService>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();

            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            services.AddScoped<IOrderDetailService, OrderDetailService>();
            services.AddScoped<IOrderDetailRepository, OrderDetailRepository>();

            services.AddScoped<IOrderService, OrderService>();
            services.AddScoped<IOrderRespository, OrderRepository>();


            services.AddTransient<IValidator<ProductCreateDto>, ProductCreateDtoValidator>();
            services.AddTransient<IValidator<ProductUpdateDto>, ProductUpdateDtoValidator>();


            services.AddTransient<IValidator<OrderCreateDto>, OrderCreateDtoValidator>();
            services.AddTransient<IValidator<OrderUpdateDto>, OrderUpdateDtoValidator>();

            services.AddTransient<IValidator<OrderDetailCreateDto>, OrderDetailCreateDtoValidator>();
            services.AddTransient<IValidator<OrderDetailUpdateDto>, OrderDetailUpdateDtoValidator>();

            services.AddTransient<IValidator<EmployeeCreateDto>, EmployeeCreateDtoValidator>();
            services.AddTransient<IValidator<EmployeeUpdateDto>, EmployeeUpdateDtoValidator>();

            services.AddTransient<IValidator<CustomerCreateDto>, CustomerCreateDtoValidator>();
            services.AddTransient<IValidator<CustomerUpdateDto>, CustomerUpdateDtoValidator>();

            services.AddTransient<IValidator<CategoryCreateDto>, CategoryCreateDtoValidator>();
            services.AddTransient<IValidator<CategoryUpdateDto>, CategoryUpdateDtoValidator>();




        }
    }
}
