using Blazored.Toast;
using Blazored.Toast.Services;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.EntityFrameworkCore;
using NLog;
using NLog.Web;
using RentalStore.Application.Mappings;
using RentalStore.Application.Services;
using RentalStore.Application.Validators;
using RentalStore.BlazorServer.Services;
using RentalStore.Domain.Interfaces;
using RentalStore.Infrastructure;
using RentalStore.Infrastructure.Repositories;
using RentalStore.SharedKernel.Dto;

// Early init of NLog to allow startup and exception logging, before host is built
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);

    // Add services to the container.
    builder.Services.AddRazorPages();
    builder.Services.AddServerSideBlazor();
    builder.Services.AddBlazoredToast();

    // rejestracja automappera w kontenerze IoC
    builder.Services.AddAutoMapper(typeof(RentalStoreMappingProfile));

    builder.Services.AddScoped<IValidator<EquipmentDto>, EquipmentDtoValidator>();
    builder.Services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<EquipmentDtoValidator>());

    // rejestracja kontekstu bazy w kontenerze IoC
    // var sqliteConnectionString = "Data Source=Kiosk.WebAPI.Logger.db";
    var sqliteConnectionString = "Data Source=" + Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData) + "\\RentalStore.db";
    builder.Services.AddDbContext<RentalStoreDbContext>(options =>
        options.UseSqlite(sqliteConnectionString));

    builder.Services.AddScoped(typeof(GenericService<>));

    builder.Services.AddScoped<IRentalStoreUnitOfWork, RentalStoreUnitOfWork>();
    builder.Services.AddScoped<IProductRepository, ProductRepository>();
    builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
    builder.Services.AddScoped<IRentalRepository, RentalRepository>();
    builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

    builder.Services.AddScoped<IProductService, ProductService>();
    builder.Services.AddScoped<IEquipmentService, EquipmentService>();
    builder.Services.AddScoped<IRentalService, RentalService>();
    builder.Services.AddScoped<ICategoryService, CategoryService>();
    builder.Services.AddScoped<IFileService, FileService>();
    builder.Services.AddScoped<IToastService, ToastService>();

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

    app.Run();
}
catch (Exception exception)
{
    // NLog: catch setup errors
    logger.Error(exception, "Stopped program because of exception");
    throw;
}
finally
{
    // Ensure to flush and stop internal timers/threads before application-exit (Avoid segmentation fault on Linux)
    NLog.LogManager.Shutdown();
}
