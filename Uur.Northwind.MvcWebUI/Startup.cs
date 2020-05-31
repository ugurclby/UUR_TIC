using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Uur.Northwind.Business.Abstract;
using Uur.Northwind.Business.Concrete;
using Uur.Northwind.DataAccess.Abstract;
using Uur.Northwind.DataAccess.Concrete.EntityFramework;
using Uur.Northwind.MvcWebUI.Middlewares;

namespace Uur.Northwind.MvcWebUI
{
    public class Startup
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Servis ba��ml�l�klar� buraya eklenir. dependency injection burada yap�l�r.
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddScoped<IProductService, ProductManager>();// Birisi senden IProductService isterse ona new'leyerek ProductManager ver Product class index i�inde kullan�ld�.
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            
            
            
            //services.AddSingleton<IProductService, ProductManager>(); // Bir kullan�c� IProductService istei�inde bulundu�unda ProductManager olu�turulur. Farkl� bir kullan�c� da istekte bulunursa di�er kullan�c� i�in olu�turulan ProductManager �st�nden devam edilir. Bir instance olu�ur herkes ayn�s�n� kullan�r. Bu yap�da ortak kullan�ma ayk�r� olmayan nesneler olmas� gerekir.

            // services.AddScoped & services.AddTransient = > Her kullan�c� ve her request i�in yeni bir nesne olu�turulur. Farklar� AddScoped da bir kullan�c� ayn� request i�inde 2 tane IProductService isterse tek nesne olu�ur ve cevap tek nesneye yaz�l�r. Nesene i�inde de�er de�i�irse ikisinde de de�i�mi� olur. AddTransient de iki tane ayr� olu�ur.

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Orta katman yap�land�rmas� burada yap�l�r. ** middleware
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseStaticFiles();

            app.UseMvcWithDefaultRoute();

            app.UseNodeModules(env.ContentRootPath);

            //app.UseRouting();

            //app.UseEndpoints(endpoints =>
            //{
            //    endpoints.MapGet("/", async context =>
            //    {
            //        await context.Response.WriteAsync("Hello World!");
            //    });
            //});
        }
    }
}
