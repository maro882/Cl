using Clinic.Models;
using Clinic.Models.Entites;
using Clinic.Repos.Immplemntion;
using Clinic.Repos.Irepos;
using Microsoft.EntityFrameworkCore;

namespace Clinic
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<AppDbContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("connstr")));
            builder.Services.AddScoped<Idoctor, DoctorPage>();
            builder.Services.AddScoped<Ipatient, PatientPage>();
            builder.Services.AddScoped<Iappoiment, AppoimentPage>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}
