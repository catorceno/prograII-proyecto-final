// dotnet ef dbcontext scaffold "Server=DESKTOP-6L6ASHP\SQLEXPRESS;Database=TeatroTickets2;Integrated Security=True;TrustServerCertificate=True" Microsoft.EntityFrameworkCore.SqlServer -o Models

using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddDbContext<AppDbContext>(opciones =>
//    opciones.UseSqlServer("name=DefaultConnection"));
var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.Run();

