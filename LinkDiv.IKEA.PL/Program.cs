using LinkDiv.IKEA.DAL.persistance.Data;
using Microsoft.EntityFrameworkCore;
using System;

namespace LinkDiv.IKEA.PL
{
    public class Program
    {
        public static void Main()
        {
            var builder = WebApplication.CreateBuilder();

            #region Configure Service
            // Add services to the container.
            builder.Services.AddControllersWithViews();
            builder.Services.AddDbContext<ApplicationDbContext>((optionBuilder) =>
            {
                optionBuilder.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnetcion"));
            }
                       );
            #endregion

            var app = builder.Build();

            #region Configure Kestryl Middlewares

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

            #region Lw 3ndy Security Module

            //app.UseAuthentication();
            //app.UseAuthorization(); 
            #endregion

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            #endregion
            
            app.Run(); 
        }
    }
}
