using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApp
{
  
    public class Startup
    {
        IConfiguration configuration;
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        
        public Startup(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            //DI
            //Tự đóng kết nối
            //Dispose

            services.AddAuthentication("Cookies").AddCookie(p => {
                p.LoginPath = "/auth/login";
                p.ExpireTimeSpan = TimeSpan.FromDays(30);
                p.Cookie.Name = "cse.net.vn";
            
            });
            services.AddScoped<SiteProvider>(p => new SiteProvider(configuration));

            services.AddDbContext<CSContext>(p => p.UseSqlServer(configuration.GetConnectionString("CS")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            // Sử dụng js, css, images
            app.UseStaticFiles();

            app.UseRouting();
            app.UseAuthentication();
            //Nho Autho
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapGet("/", async context =>
                //{
                //    await context.Response.WriteAsync("Hello World!");
                //});
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
