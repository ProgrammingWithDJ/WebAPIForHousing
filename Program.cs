using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAPIForHousing.Data;
using WebAPIForHousing.Data.Repo;
using WebAPIForHousing.Interfaces;
using AutoMapper;
using WebAPIForHousing.Helpers;
using System.Net;
using Microsoft.AspNetCore.Diagnostics;
using Azure;
using WebAPIForHousing.Extensions;
using WebAPIForHousing.Middlewares;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnectionString")));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllers();
builder.Services.AddAutoMapper(typeof(AutomapperProfiles).Assembly);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.ConfigureExceptionHandler(app.Environment);

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
