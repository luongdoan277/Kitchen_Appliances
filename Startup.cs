using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Kitchen_Appliances.Models;
using Kitchen_Appliances.Services;
using Microsoft.AspNetCore.Authentication.Cookies;


namespace Kitchen_Appliances
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; set; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddDbContext<StoreDbContext>(
              opts =>
              {
                  opts.UseSqlServer
                  (Configuration["ConnectionStrings:KitchenAppliances"]);
              }
              );
            services.AddAuthentication(options =>
            {
                options.DefaultScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            })
                .AddCookie(options =>
                {
                    options.LoginPath = "/account/google-login"; // Must be lowercase
                })
                .AddGoogle(options =>
                {
                    options.ClientId = "154224909507-j5c2r6vc8mgo71ocovbie5ajnt6krb9m.apps.googleusercontent.com";
                    options.ClientSecret = "KeNJ3OSFnPL0FwdnIQLKniW-";
                });
            services.AddScoped<IStoreRepository, EFStoreRepository>();
            services.AddRazorPages();
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.Configure<MailSettings>(Configuration.GetSection("MailSettings"));
            services.AddTransient<ISendMailService, SendMailService>();
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
            app.UseSession();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("catpage",
                     "{category}/Page{productPage:int}",
                     new { Controller = "Home", action = "Index" });

                endpoints.MapControllerRoute("page",
                    "/",
                    new { Controller = "Home", action = "Index", productPage = 1 });

                endpoints.MapControllerRoute("pagination",
                    "Drinks/page{productPage:int}",
                    new { Controller = "Home", action = "Index", productPage = 1 });

                //Details
                endpoints.MapControllerRoute("ProductDetail",
                    "ProductDetail/Id={ProductID}",
                    new { Controller = "Product", action = "ProductDetail"});

                endpoints.MapControllerRoute("ProductDetail",
                    "{category}/ProductDetail/Id={ProductID}",
                    new { Controller = "Product", action = "ProductDetail"});

                //Checkout
                endpoints.MapControllerRoute("Checkout",
                    "Checkout",
                    new { Controller = "Checkout", action = "Index" });

                //Admin
                endpoints.MapControllerRoute("Admin",
                    "Admin",
                    new { Controller = "Admin", action = "Index" });

                endpoints.MapControllerRoute("AdminProduct",
                    "Admin/Product",
                    new { Controller = "Admin", action = "AdminProduct" });


                endpoints.MapDefaultControllerRoute();
                endpoints.MapRazorPages();
            });
            SeedData.EnsurePopulated(app);
        }
    }
}
