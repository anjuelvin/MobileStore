﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using MobileStore.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace MobileStore
{
    public class Startup
    {
        IConfigurationRoot Configuration;
        public Startup(IHostingEnvironment env)
        {
            Configuration = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json").Build();
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration["Data:MobileStoreProducts:ConnectionString"]));
            services.AddDbContext<AppIdentityDbContext>(options =>
               options.UseSqlServer(
                   Configuration["Data:MobileStoreIdentity:ConnectionString"]));
            services.AddIdentity<IdentityUser, IdentityRole>()
              .AddEntityFrameworkStores<AppIdentityDbContext>();
            services.AddTransient<IProductRepository, EFProductRepository>();
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddTransient<IOrderRepository, EFOrderRepository>();
            services.AddMvc();
            services.AddMemoryCache();
            services.AddSession();
        }
        public void Configure(IApplicationBuilder app,
              IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseIdentity();
            app.UseSession();
            app.UseMvc(routes => {
                routes.MapRoute(
              name: null,
              template: "{category}/Page{page:int}",
              defaults: new { controller = "Product", action = "List" }
          );
         
                routes.MapRoute(
                  name: null,
                  template: "Page{page:int}",
                  defaults: new { controller = "Product", action = "List", page = 1 }
              );
                routes.MapRoute(
                  name: null,
                  template: "{category}",
                  defaults: new { controller = "Product", action = "List", page = 1 }
              );
               
                routes.MapRoute(
                  name: null,
                  template: "",
                  defaults: new { controller = "Product", action = "List", page = 1 });
                routes.MapRoute(name: null, template: "{controller}/{action}/{id?}");
            });
            app.UseMvc(routes => {
                routes.MapRoute(
    name: null,
    template: "Contactus/{Index}",
    defaults: new { controller = "Contactus", action = "Index" });
});


            SeedData.EnsurePopulated(app);
            IdentitySeedData.EnsurePopulated(app);
        }
    }
}