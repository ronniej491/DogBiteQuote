using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DBQWebsite.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


namespace DBQWebsite
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContextPool<DBQContext>(options => options.UseSqlServer(_config.GetConnectionString("DBQConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<DBQContext>().AddDefaultTokenProviders();
            services.ConfigureApplicationCookie(config =>
            {

                config.Cookie.Name = "DBQ";
                config.LoginPath = "/Home/Login";
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
