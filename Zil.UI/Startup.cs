using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Zil.UI
{
    public class Startup
    {

        public static bool[] MongoWatch = { false, false, false, false, false, false, false, false, false };//Alarm,Main,Sub1,Sub2,Sub3,Sub4 Categories,Client,Login,SessionTimeout
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            services.AddMemoryCache();
            services.AddControllersWithViews().AddRazorRuntimeCompilation(); 
            services.AddDistributedMemoryCache();
            services.AddSession(options =>
            {
                options.IdleTimeout = TimeSpan.FromMinutes(20);
            });

            services.AddDistributedMemoryCache();
            services.AddMvc(option => option.EnableEndpointRouting = false);
            services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => false;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });

            services.AddSignalR(options =>
            {
                options.EnableDetailedErrors = true;
            });






        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        [Obsolete]
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

            app.UseMvc(routes =>
            {
                routes.MapRoute("default", "", new { controller = "StartPage", action = "Index" });

                routes.MapRoute("anasayfa", "anasayfa", new { controller = "Home", action = "Index" });

                routes.MapRoute("detay", "{_id}/{CreatedUserId}", new { controller = "Home", action = "Detail" });









                routes.MapRoute("SignUp", "kayit-ol", new { controller = "SignUp", action = "Index" });

                routes.MapRoute("SigningUp", "kayit", new { controller = "SignUp", action = "Signing" });

                routes.MapRoute("Loging", "giris-yap", new { controller = "Signin", action = "Index" });

                routes.MapRoute("Logger", "giris", new { controller = "Signin", action = "Logger" });

                routes.MapRoute("CreateCourse", "kurs-olustur", new { controller = "CreateCourse", action = "Index" });

                routes.MapRoute("Course", "kurs", new { controller = "CreateCourse", action = "Course" });


                routes.MapRoute("signOutLogs", "ajax-signout-log", new { controller = "LogOut", action = "SignOut" });

                routes.MapRoute("userSetting", "ayarlar", new { controller = "UserSetting", action = "UserSetting" });
                routes.MapRoute("updateSetting", "update-setting", new { controller = "UserSetting", action = "UserUpdate" });
                routes.MapRoute("Instructor", "instructors", new { controller = "Instructors", action = "Index" }); 
            });

        }
    }
} 
