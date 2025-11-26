using Microsoft.EntityFrameworkCore;
using backend.Entities;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddDbContext<TeatroTickets2Context>(opciones => 
    opciones.UseSqlServer("name=DefaultConnection"));

builder.Services.AddScoped<IPerformanceService, PerformanceService>();
builder.Services.AddScoped<IPerformerService, PerformerService>();
builder.Services.AddScoped<IPlayService, PlayService>();
builder.Services.AddScoped<IPriceZoneService, PriceZoneService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<ITheaterService, TheaterService>();

var app = builder.Build();
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors();
app.MapControllers();
app.Run();
