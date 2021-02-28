using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using UdemyNLayerProject.Core.Repository;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Core.UnitOfWork;
using UdemyNLayerProject.Data;
using UdemyNLayerProject.Data.Repository;
using UdemyNLayerProject.Data.UnitOfWork;
using UdemyNLayerProject.Service.Services;
using UdemyNLayerProject.UI.Filters;

namespace UdemyNLayerProject.UI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<NotFoundFilter>();
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services
                .AddScoped<IUnitOfWork, UnitOfWork
                >(); //Bununla IUnitOfWork gordugu zaman UnitOfWork nesnesi olusturur. Bir defa olustustur her gordugunde onu cagirir.
            services.AddControllersWithViews();
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer("name=ConnectionStrings:SqlConStr"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();
            app.UseStaticFiles();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapDefaultControllerRoute();
                endpoints.MapControllerRoute(
                    name: "Default",
                    pattern: "{controller=Category}/{action=Index}/{id?}");
            });
        }
    }
}