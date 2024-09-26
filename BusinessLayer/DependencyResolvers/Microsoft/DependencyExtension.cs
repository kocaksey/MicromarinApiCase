using AutoMapper;
using BusinessLayer.Abstract;
using BusinessLayer.Concrete;
using BusinessLayer.Mappings.ProductMapping;
using BusinessLayer.ValidaitonRules.ProductValidaiton;
using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.UnitOfWork;
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
            });

            var mapper = configuration.CreateMapper();

            services.AddSingleton(mapper);

            services.AddScoped<IUow, Uow>();

            //servis bağımlılıkları buraya
            services.AddScoped<IProductService, ProductService>();
            services.AddScoped<IProductRepository, ProductRepository>();

            services.AddTransient<IValidator<ProductCreateDto>, ProductCreateDtoValidator>();
            services.AddTransient<IValidator<ProductUpdateDto>, ProductUpdateDtoValidator>();

        }
    }
}
