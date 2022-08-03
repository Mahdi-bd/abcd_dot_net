using Entities;
using Entities.Utilities;
using Repository;
using Repository.Contracts;
using Services;
using Services.Abstractions;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Injections
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

builder.Services.AddScoped<IGenericRepository, GenericRepository>();
builder.Services.AddScoped<ISummerizedResultService, SummerizedResultService>();
builder.Services.AddScoped<ISummerizedResultRepository,SummerizedResultRepository>();

Constants.DefaultConnectionString = "Data Source=localhost;Initial Catalog=rps_db; Integrated Security=false; user id=sa; password=sa1234;Pooling=false";

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
