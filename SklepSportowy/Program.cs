using Microsoft.EntityFrameworkCore;
using SklepSportowy.Persistance;



var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

// aby dodaæ obs³ugê Swagegra w terminalu wpisz
// dotnet add package Swashbuckle.AspNetCore
builder.Services.AddSwaggerGen();

// connection string 
var sqliteConnectionString = "Data Source=sklepsportowy.db";
builder.Services.AddDbContext<SklepDbContext>(options =>
    options.UseSqlite(sqliteConnectionString));

builder.Services.AddScoped<DataSeeder>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

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
