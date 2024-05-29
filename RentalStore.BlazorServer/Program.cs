using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using RentalStore.Application.Mappings;
using RentalStore.Application.Services;
using RentalStore.BlazorServer.Data;
using RentalStore.Infrastructure;

namespace RentalStore.BlazorServer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
            builder.Services.AddServerSideBlazor();
            builder.Services.AddSingleton<WeatherForecastService>();

            // Rejestracja AutoMapper
            builder.Services.AddAutoMapper(typeof(RentalStoreMappingProfile));
            // rejestracja automatycznej walidacji (FluentValidation waliduje i przekazuje wynik przez ModelState):
            builder.Services.AddFluentValidationAutoValidation();
            // rejestracja kontekstu bazy w kontenerze IoC:
            var sqliteConnectionString = "Data Source=RentalStore.db";
            builder.Services.AddDbContext<RentalStoreDbContext>(options =>
            options.UseSqlite(sqliteConnectionString));
            // rejestracja walidatora:

            // dodanie innych serwisow i zale¿noœci
            builder.Services.AddScoped<DataSeeder>();




            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseStaticFiles();

            app.UseRouting();

            app.MapBlazorHub();
            app.MapFallbackToPage("/_Host");

            // Seeding data
            using (var scope = app.Services.CreateScope())
            {
                var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
                dataSeeder.Seed();
            }
            app.Run();
        }
    }
}