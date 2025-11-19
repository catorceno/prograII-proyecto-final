// 1. appsetting.development.json
// DefaultConnection: "Server=DESKTOP-6L6ASHP\\SQLEXPRESS;Database=TeatroTickets7;Integrated Security=True;TrustServerCertificate=True"

// 2. terminal
// dotnet add package Microsoft.EntityFrameworkCore.SqlServer
// dotnet add package Microsoft.EntityFrameworkCore.Design
// dotnet ef dbcontext scaffold "Server=DESKTOP-6L6ASHP\SQLEXPRESS;Database=TeatroTickets7;Integrated Security=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Models
// dotnet add package Swashbuckle.AspNetCore
// dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection

// 3. Program.cs
// builder.Services.AddEndpointsApiExplorer();
// builder.Services.AddSwaggerGen();
// builder.Services.AddControllers();
// builder.Services.AddAutoMapper(typeof(MappingProfile));
// builder.Services.AddDbContext<TeatroTickets7Context>(opciones => opciones.UseSqlServer("name=DefaultConnection"));
// var origenesPermitidos = builder.Configuration.GetValue<string>("OrigenesPermitidos")!.Split(",");
// builder.Services.AddCors(opciones =>
// {
//     opciones.AddDefaultPolicy(politica =>
//     {
//         politica.WithOrigins(origenesPermitidos).AllowAnyHeader().AllowAnyMethod();
//     });
// });
// if (...)
//      app.UseSwagger();
//      app.UseSwaggerUI();
// app.UseHttpsRedirection();
// app.UseCors();
// app.MapControllers();

// 4. AutoMapper.cs
// public class AutoMapper : Profile
// {
//     public AutoMapper()
//     {
//         // CreateMap<Entity, Dto>();
//         // CreateMap<Dto, Entity>();
//     }
// }

// ... dto, services, controller ...

// 5. Program.cs
// builder.Services.AddScoped<IService, Service>();



using backend.Entities;
using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers()
    .AddJsonOptions(opts =>
        opts.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter()));

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(MappingProfile)); // Program
builder.Services.AddDbContext<TeatroTickets7Context>(opciones =>
    opciones.UseSqlServer("Name=DefaultConnection"));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ISeatingPlanRepository, SeatingPlanRepository>();

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ISeatingPlanService, SeatingPlanService>();

var origenesPermitidos = builder.Configuration.GetValue<string>("OrigenesPermitidos")!.Split(",");
builder.Services.AddCors(opciones =>
{
    opciones.AddDefaultPolicy(politica =>
    {
        politica.WithOrigins(origenesPermitidos).AllowAnyHeader().AllowAnyMethod();
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.MapControllers();
app.Run();
