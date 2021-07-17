using Business.Abstract;
using Business.Concrete;
using Core.DependencyResolvers;
using Core.Extensions;
using Core.Utilities.IoC;
using Core.Utilities.Security.Encryption;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI
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
            services.AddControllers();

            services.AddCors();//aþaðýda sana bi adres verdim oradan gelecek istekleri onaylayacaksýn, çalýþ.

            var tokenOptions = Configuration.GetSection("TokenOptions").Get<TokenOptions>();   //tokene dair bilgileri appsettings.json ' dan al, token options nesnemize koy.

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidIssuer = tokenOptions.Issuer,
                    ValidAudience = tokenOptions.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = SecurityKeyHelper.CreateSecurityKey(tokenOptions.SecurityKey)

                };
            });

            services.AddDependencyResolvers(new ICoreModule[]{
                    new CoreModule()
                });
                
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.ConfigureCustomExceptionMiddleware();

            app.UseStaticFiles();   //RESÝMLERÝN GÖSTERÝMÝ ÝÇÝN! 
            //BU KODU YAZMAZSAN EÐER "https://localhost:44354/images/498b8ba0-50d6-4070-9011-a5470aba317a.jpg" ADRESÝ VE DÝÐER ADRESLER SANA RESÝM GÖSTERMÝYOR.

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200").AllowAnyHeader());//bu adresten gelebilecek tüm istekleri onayla. güvenilir.

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication(); //giriþ yap

            app.UseAuthorization(); //yetkin varsa iþ yap

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
