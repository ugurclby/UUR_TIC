using Microsoft.AspNetCore.Builder;
using Microsoft.CodeAnalysis.Options;
using Microsoft.Extensions.FileProviders;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace Uur.Northwind.MvcWebUI.Middlewares
{
    public static class ApplicationBuilderExtension
    {
        // Asp .net core da static dosyalar (css,jquery,js) wwwroot altında hizmet vermesi beklenir. Diğer türlü kullanılamaz. O yüzden node_modules klasörünü wwwroot altına taşınması gerekmektedir.Fiziksel olarak taşındığında yolu değişcek ve paket yönetimi sekteye uğrayacak. O yüzde wwwroot altındaymış gibi alias vererek düzenleme yapılması gerekir. Bu tip dosyalar startup da configure altında app.UserStaticFiles adında bir middleware ile yönetilir. O yüzden IApplicationBuilder extend edilerek UseNodeModules adında bir extension metod yazıldı. 
        public static IApplicationBuilder UseNodeModules(this IApplicationBuilder app, string root) 
        {
            var path = Path.Combine(root, "node_modules");
            var provider = new PhysicalFileProvider(path);

            var options = new StaticFileOptions();
            options.RequestPath = "/node_modules";
            options.FileProvider = provider;

            app.UseStaticFiles(options);

            return app;
        }
    }
}
