using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using proj1forchap7.Models;
namespace proj1forchap7
{
    public class Startup
    {
        #region Database related configuration
        private IConfiguration Configuration { get; set; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        #endregion

        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();

            #region Database related configuration
            //note the StoreDbContext class use here
            services.AddDbContext<StoreDbContext>(opts =>
            {
                //Note the use of private property Configuration here!
                opts.UseSqlServer(Configuration["ConnectionStrings:DbConnection"]);
            });
            #endregion

            /* it is to create a service for the IStoreRepository
            interface that uses EFStoreRepository as the implementation class. */
            services.AddScoped<IStoreRepository, EFStoreRepository>();
            services.AddRazorPages();
            services.AddDistributedMemoryCache();

            #region Session related services registration
            services.AddSession();
            /* sp == IServiceProvider and it is obtained for the System namespace: System.IServiceProvider; */
            services.AddScoped<Cart>(sp => SessionCart.GetCart(sp));
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            #endregion
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
#if false
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
#endif
            app.UseDeveloperExceptionPage();
            app.UseStatusCodePages();
            app.UseStaticFiles();
            app.UseSession();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                /* Changing the route configurations */
                endpoints.MapControllerRoute("catpage", "{category}/Page{productPage:int}", new { Controller = "Home", action = "ProductsWithPagination" });
                endpoints.MapControllerRoute("page", "Page{productPage:int}", new { Controller = "Home", action = "ProductsWithPagination", productPage = 1 });
                endpoints.MapControllerRoute("category", "{category}", new { Controller = "Home", action = "ProductsWithPagination", productPage = 1 });
                endpoints.MapControllerRoute("pagination", "Products/Page{productPage}", new { Controller = "Home", action = "ProductsWithPagination" });
                /* To register the MVC Framework as a source of endpoints
                calls the MapDefaultControllerRoute method */
                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
                // endpoints.MapGet("/", async context =>
                // {
                //     await context.Response.WriteAsync("Hello World!");
                // });
            });
            //seed the data from SeedData.cs 
            SeedData.EnsurePopulated(app);
        }
    }
}
