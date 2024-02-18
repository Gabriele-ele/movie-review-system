using Npgsql;
using System.Data;
using GabrielesProject.MovieReviewSystem.Infrastracture;
using GabrielesProject.MovieReviewSystem.Application;
using Serilog;
using GabrielesProject.MovieReviewSystem.Application.Services;
using GabrielesProject.MovieReviewSystem.Application.Interfaces;

var builder = WebApplication.CreateBuilder(args);
string? dbConnectionString = builder.Configuration.GetConnectionString("PostgreConnection");

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//builder.Services.AddTransient<IDbConnection>((sp) => new NpgsqlConnection(dbConnectionString));
builder.Services.AddApplication();
builder.Services.AddInfrastructure(dbConnectionString);
builder.Services.AddHttpClient();

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
