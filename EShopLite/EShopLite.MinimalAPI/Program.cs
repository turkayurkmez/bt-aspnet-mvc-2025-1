using EShopLite.Application;
using EShopLite.Application.DataTransferObjects;
using EShopLite.Infrastructure;
using EShopLite.MinimalAPI.Extensions;
using EShopLite.MinimalAPI.Validators;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddInfrastructure(connectionString);
builder.Services.AddApplication();
builder.Services.AddScoped<IValidator<CreateNewProductRequest>, CreateNewProductValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.AddEndPoints();




app.Run();

