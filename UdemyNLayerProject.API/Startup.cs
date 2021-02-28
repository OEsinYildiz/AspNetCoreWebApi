using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using UdemyNLayerProject.API.DTOs;
using UdemyNLayerProject.API.Extentions;
using UdemyNLayerProject.API.Filters;
using UdemyNLayerProject.Core.Repository;
using UdemyNLayerProject.Core.Services;
using UdemyNLayerProject.Core.UnitOfWork;
using UdemyNLayerProject.Data;
using UdemyNLayerProject.Data.Repository;
using UdemyNLayerProject.Data.UnitOfWork;
using UdemyNLayerProject.Service.Services;

namespace UdemyNLayerProject.API
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddScoped<NotFoundFilter>(); // Ctorunda DI oldugu icin buraya yazdim.
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<IProductService, ProductService>();
            services
                .AddScoped<IUnitOfWork, UnitOfWork
                >(); //Bununla IUnitOfWork gordugu zaman UnitOfWork nesnesi olusturur. Bir defa olustustur her gordugunde onu cagirir.
            services.AddControllers();
            services.AddDbContext<AppDbContext>(
                options => options.UseSqlServer("name=ConnectionStrings:SqlConStr"));

            services.AddControllers(option =>
            {
                option.Filters.Add(
                    new ValidationFilter()); // Global seviyede tum metotlara validasyon filtresi eklenmis olacaktir.
                //Senin burda DTO`lara mesajlari yazman gerekmektedir.
            });

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true; //Filtreleri kendimiz yazacagimizi belirttik.
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment()) app.UseDeveloperExceptionPage();

           app.UseCustomException();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}