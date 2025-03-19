using EShopLite.Application;
using EShopLite.Domain.Contracts;
using EShopLite.Infrastructure.DataContext;
using EShopLite.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

//IoC Container - Inversion of Control: Dependency'leri bir koleksiyon içerisinde tutar ve gerektiğinde bu koleksiyondan ilgili nesneyi alır.
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
builder.Services.AddScoped<ICategoryService, CategoryService>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<EshopLiteDbContext>(options => options.UseSqlServer(connectionString));

builder.Services.AddSession(option =>
{
    option.IdleTimeout = TimeSpan.FromMinutes(20);
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();


app.UseAuthorization();
app.UseSession();

app.MapStaticAssets();


app.MapControllerRoute(name: "category",
    pattern: "{categoryId?}/Sayfa{page}",
    defaults: new { controller = "Home", action = "Index", page=1 });

app.MapControllerRoute(name: "paging",
    pattern: "Sayfa{page}",
    defaults: new { controller = "Home", action = "Index", page=1 });


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
  


app.Run();
