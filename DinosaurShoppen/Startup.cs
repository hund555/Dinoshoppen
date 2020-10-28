using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataLayer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ServiceLayer.CustomerService.Services;
using ServiceLayer.CustomerService.Services.Interfaces;
using ServiceLayer.DinoService.Services;
using ServiceLayer.DinoService.Services.ServiceInterfaces;
using ServiceLayer.Rabat_PromotionService.Services;
using ServiceLayer.Rabat_PromotionService.Services.Interfaces;

namespace DinosaurShoppen
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
            services.AddDistributedMemoryCache();

            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromHours(1);
                options.Cookie.IsEssential = true;
            });

            services.AddDbContext<DinoDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<ICustomerServiceUsers, CustomerServiceUsers>();
            services.AddScoped<ICustomerServiceAdmin, CustomerServiceAdmin>();
            services.AddScoped<IDinoService, DinoService>();
            services.AddScoped<IDinoAdminService, DinoAdminService>();
            services.AddScoped<IRabatService, RabatService>();
            services.AddScoped<IPromotionService, PromotionService>();

            services.AddMiniProfiler(options => {
                options.ColorScheme = StackExchange.Profiling.ColorScheme.Dark;
                options.SqlFormatter = new StackExchange.Profiling.SqlFormatters.InlineFormatter();
            }).AddEntityFramework();

            services.AddRazorPages()
                .AddRazorPagesOptions(options =>
                {
                    options.Conventions.AddPageRoute("/DinoList/Index", "");
                });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseMiniProfiler();

                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSession();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
