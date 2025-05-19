using CurvaHagz.Bussines.App;
using CurvaHagz.Data.App;
using CurvaHagz.Models.App;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using CurvaHAgz.Web.App.Helper; //  StripeSettings
using Stripe;
using CurvaHAgz.Web.App.Services;

namespace CurvaHAgz.Web.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Stripe settings injection from appsettings.json
            builder.Services.Configure<StripeSettings>(
                builder.Configuration.GetSection("Stripe")
            );

            // Add services to the container.
            builder.Services.AddDistributedMemoryCache();

            builder.Services.AddSession(option => {
                option.IdleTimeout = TimeSpan.FromMinutes(20);
                option.Cookie.HttpOnly = true;
                option.Cookie.IsEssential = true;
            });

            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<CurvaHagzContext>();

            builder.Services.AddIdentity<User, IdentityRole<int>>(option =>
            {
                option.Password.RequiredLength = 3;
                option.Password.RequireNonAlphanumeric = true;
                option.Password.RequireDigit = true;
                option.Password.RequireLowercase = true;
                option.Password.RequireUppercase = true;
            }).AddEntityFrameworkStores<CurvaHagzContext>()
              .AddDefaultTokenProviders();

            builder.Services.AddScoped<TeamsManager>();
            builder.Services.AddScoped<PlaygroundManager>();
            builder.Services.AddScoped<BookingManager>();
            builder.Services.AddScoped<IEmailService, EmailService>();

            var app = builder.Build();

            // Set Stripe API key for backend operations
            StripeConfiguration.ApiKey = builder.Configuration["Stripe:SecretKey"];

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();
            app.UseSession();
            app.UseAuthentication(); 
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Account}/{action=PlayerProfile}/{id?}"
            );

            app.Run();
        }
    }
}
