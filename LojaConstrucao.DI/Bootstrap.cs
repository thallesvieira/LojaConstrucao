using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using LojaConstrucao.Data;
using System;
using LojaConstrucao.Domain.Products;
using LojaConstrucao.Domain.Sales;
using LojaConstrucao.Data.Repositories;
using LojaConstrucao.Data.Contexts;
using LojaConstrucao.Domain;
using LojaConstrucao.Data.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using LojaConstrucao.Domain.Account;

namespace LojaConstrucao.DI
{
    public class Bootstrap
    {
        public static void Configure(IServiceCollection services, string conexion)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
            options.UseSqlServer(conexion));

            services.AddIdentity<ApplicationUser, IdentityRole>(config => {

                config.Password.RequireDigit = false;
                config.Password.RequiredLength = 3;
                config.Password.RequireLowercase = false;
                config.Password.RequireNonAlphanumeric = false;
                config.Password.RequireUppercase = false;
                config.Cookies.ApplicationCookie.LoginPath = "/Account/Login";
            })
                .AddEntityFrameworkStores<ApplicationDbContext>()
                .AddDefaultTokenProviders();

            services.AddSingleton(typeof(IRepository<Product>), typeof(ProductRepository));
            services.AddSingleton(typeof(IRepository<>), typeof(Repository<>));
            services.AddSingleton(typeof(IAuthentication), typeof(Authentication));
            services.AddSingleton(typeof(IManager), typeof(Manager));
            services.AddSingleton(typeof(CategorytStore));
            services.AddSingleton(typeof(ProductStore));
            services.AddSingleton(typeof(SaleFactory));
            services.AddSingleton(typeof(IUnitOfWork), typeof(UnitOfWork));
        }
    }
}
