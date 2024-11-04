using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;
using Repositories;
using ServiceContracts;
using Services;

namespace ECommerce
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            // Add session management
            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromSeconds(120);
                options.Cookie.HttpOnly = true;
                options.Cookie.IsEssential = true;
            }); 

            // Register DbContext
            builder.Services.AddDbContext<Hshop2023Context>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            // Categories
            builder.Services.AddScoped<ICategoriesRepository, CategoriesRepository>();
			builder.Services.AddScoped<ICategoriesService, CategoriesService>();

            // Products
            builder.Services.AddScoped<IProductsRepository, ProductsRepository>();
            builder.Services.AddScoped<IProductsService, ProductsService>();    

            // Cart
            builder.Services.AddScoped<ICartService, CartService>();

			var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            }

			app.UseHsts();
			app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthentication();
			app.UseAuthorization();
            app.UseSession();
			app.MapControllers();

            app.Run();
        }
    }
}
