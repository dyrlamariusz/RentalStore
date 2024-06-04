using Microsoft.EntityFrameworkCore;
using RentalStore.Application.Services;
using RentalStore.Domain.Interfaces;
using RentalStore.Infrastructure.Repositories;
using RentalStore.Infrastructure;
using RentalStore.SharedKernel.Dto;
using RentalStore.WebAPI.Middleware;
using RentalStore.Application.Mappings;
using FluentValidation.AspNetCore;
using FluentValidation;
using RentalStore.Application.Validators;
using NLog.Web;
using NLog;
using System.Text.Json.Serialization;

// Early init of NLog to allow startup and exception logging, before host is built
var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("init main");

try
{
    var builder = WebApplication.CreateBuilder(args);
    // Add services to the container.
    builder.Services.AddControllers().AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    });

    // NLog: Setup NLog for Dependency injection
    builder.Logging.ClearProviders();
    builder.Host.UseNLog();

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    // rejestracja automappera w kontenerze IoC
    builder.Services.AddAutoMapper(typeof(RentalStoreMappingProfile));

    // rejestracja automatycznej walidacji (FluentValidation waliduje i przekazuje wynik przez ModelState)
    builder.Services.AddFluentValidationAutoValidation();

    // rejestracja kontekstu bazy w kontenerze IoC
    var sqliteConnectionString = "Data Source=RentalStore.WebAPI.Logger.db";
    builder.Services.AddDbContext<RentalStoreDbContext>(options =>
        options.UseSqlite(sqliteConnectionString));

    // rejestracja walidatora
    //builder.Services.AddScoped<IValidator<CreateProductDto>, RegisterCreateProductDtoValidator>();

    // Rejestracja generycznego repozytorium (Karina 31.05 22:15)
    //builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

    // Rejestracja generycznego serwisu (Karina 31.05 22:15)
    builder.Services.AddScoped(typeof(GenericService<>));

    builder.Services.AddScoped<IRentalStoreUnitOfWork, RentalStoreUnitOfWork>();
    builder.Services.AddScoped<IProductRepository, ProductRepository>();
    builder.Services.AddScoped<IEquipmentRepository, EquipmentRepository>();
    builder.Services.AddScoped<IRentalRepository, RentalRepository>();
    builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

    builder.Services.AddScoped<DataSeeder>();
    builder.Services.AddScoped<IProductService, ProductService>();
    builder.Services.AddScoped<IEquipmentService, EquipmentService>();
    builder.Services.AddScoped<IRentalService, RentalService>();
    builder.Services.AddScoped<ICategoryService, CategoryService>();
    builder.Services.AddScoped<ExceptionMiddleware>();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    app.UseStaticFiles();
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseMiddleware<ExceptionMiddleware>();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    // seeding data
    using (var scope = app.Services.CreateScope())
    {
        var dataSeeder = scope.ServiceProvider.GetRequiredService<DataSeeder>();
        dataSeeder.Seed();
    }

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






