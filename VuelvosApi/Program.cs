using Microsoft.EntityFrameworkCore;
using VuelvosApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<sistem21_aeropuertoximenaContext>(options =>
    options.UseMySql("server=sistemas19.com;user=sistem21_ximena18;password=k75~7Ic9x;database=sistem21_aeropuertoximena", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.29-mysql"))
);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();