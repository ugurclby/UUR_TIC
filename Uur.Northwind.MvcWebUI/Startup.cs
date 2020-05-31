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
            //Servis baðýmlýlýklarý buraya eklenir. dependency injection burada yapýlýr.
            services.AddMvc(options => options.EnableEndpointRouting = false);
            services.AddScoped<IProductService, ProductManager>();// Birisi senden IProductService isterse ona new'leyerek ProductManager ver Product class index içinde kullanýldý.
            services.AddScoped<IProductDal, EfProductDal>();
            services.AddScoped<ICategoryService, CategoryManager>();
            services.AddScoped<ICategoryDal, EfCategoryDal>();
            
            
            
            //services.AddSingleton<IProductService, ProductManager>(); // Bir kullanýcý IProductService isteiðinde bulunduðunda ProductManager oluþturulur. Farklý bir kullanýcý da istekte bulunursa diðer kullanýcý için oluþturulan ProductManager üstünden devam edilir. Bir instance oluþur herkes aynýsýný kullanýr. Bu yapýda ortak kullanýma aykýrý olmayan nesneler olmasý gerekir.

            // services.AddScoped & services.AddTransient = > Her kullanýcý ve her request için yeni bir nesne oluþturulur. Farklarý AddScoped da bir kullanýcý ayný request içinde 2 tane IProductService isterse tek nesne oluþur ve cevap tek nesneye yazýlýr. Nesene içinde deðer deðiþirse ikisinde de deðiþmiþ olur. AddTransient de iki tane ayrý oluþur.

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //Orta katman yapýlandýrmasý burada yapýlýr. ** middleware
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
