using Fyk.BLL.Managers.Concrete;
using Fyk.DAL.Data;
using Fyk.DAL.Repositories.Concrete;
using Fyk.DAL.Service.Concrete;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace FurkanYasinKerem
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);


            builder.Services.AddDbContext<FykDbContext>(x=>
            {
                x.UseSqlServer(builder.Configuration.GetConnectionString("FBKConStr"));
            }, ServiceLifetime.Singleton);

            // Add services to the container.
            builder.Services.AddControllersWithViews();

            builder.Services.AddAutoMapper(typeof(Assembly));

            builder.Services.AddSingleton<MarkaRepo>();
            builder.Services.AddSingleton<MarkaService>();
            builder.Services.AddSingleton<MarkaManager>();

            // Model Implimentation
            builder.Services.AddSingleton<ModelRepo>();
            builder.Services.AddSingleton<ModelService>();
            builder.Services.AddSingleton<ModelManager>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
