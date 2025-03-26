using Jahez.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using InfraStractur.Data;
using Models.Model;
using InfraStractur.Repository.RepositoryModels;
using Microsoft.AspNetCore.Authorization;
using Auth.SettingsPolicy;

namespace Jahez
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // 🔹 إضافة خدمات قاعدة البيانات
            //var connectionString = builder.Configuration.GetConnectionString("DefaultConnection")
            //    ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");

            builder.Services.AddDbContext<ConnectDataBase>();


            builder.Services.AddScoped<DepartmintRepository>();
            builder.Services.AddScoped<CategorieRepository>();

            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            // 🔹 إعداد الهوية (Identity)
            builder.Services.AddIdentity<User, IdentityRole>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ConnectDataBase>()
                .AddDefaultUI()
                .AddApiEndpoints()
                .AddDefaultTokenProviders();

            // 🔹 دعم الـ MVC والـ API
            builder.Services.AddControllersWithViews();
            builder.Services.AddControllers();
            builder.Services.AddRazorPages();




            builder.Services.AddAuthorization(options =>
            {
                options.AddPolicy("SuperMarketOwnerOrAdmin", policy =>
                    policy.Requirements.Add(new CategorieOwnerRequirement()));
            });
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<IAuthorizationHandler, CategorieOwnerHandler>();

            var app = builder.Build();

            // 🔹 تهيئة الـ Middleware
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.Use(async (context, next) =>
            {
                if (context.Request.Path == "/")
                {
                    context.Response.Redirect("/Home/Index");
                    return;
                }
                await next();
            });

            // 🔹 إعداد الـ Endpoints لدعم API و MVC
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}"
                );
                endpoints.MapControllers(); // دعم API
                endpoints.MapRazorPages();
            });
            app.Run();
        }
    }
}
