using Application.Services.Implementations;
using Application.Services.Interfaces;
using Application.Validation.Product;
using Domain.Interfaces;
using Infrastructure.DbContext;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;
var configuration = builder.Configuration;

services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

services.AddScoped<IProductRepository, ProductRepository>();
services.AddScoped<IProductCategoryRepository, ProductCategoryRepository>();

services.AddScoped<IProductService, ProductService>();
services.AddScoped<IProductCategoryService, ProductCategoryService>();

services.AddSwaggerGen();

services.AddControllers();

services.AddFluentValidation().AddValidatorsFromAssembly(typeof(GetProductDtoValidator).Assembly);

var app = builder.Build();

app.UseRouting();
app.MapControllers();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "RobolineTestAssignment API v1");
        options.RoutePrefix = string.Empty;
    });
}

app.Run();
    
    