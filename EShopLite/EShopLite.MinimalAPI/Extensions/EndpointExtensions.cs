using EShopLite.Application;
using EShopLite.Application.DataTransferObjects;
using EShopLite.MinimalAPI.Validators;
using FluentValidation;

namespace EShopLite.MinimalAPI.Extensions
{
    public static class EndpointExtensions
    {
        public static void AddEndPoints(this WebApplication app)
        {
            var productsGroup = app.MapGroup("/products");
            productsGroup.MapGet("/", async (IProductService productService) =>
            {
                var products = await productService.GetProducts();
                return Results.Ok(products);
            })
              .WithDescription("Tüm ürünleri getir")
              .WithName("Tüm_Ürünler")
              .WithTags("product", "all");


            //localhost:7258/products/category/1
            productsGroup.MapGet("/category/{categoryId}", async (IProductService productService, int categoryId) =>
             {
                 return Results.Ok(await productService.GetProductsByCategory(categoryId));
             }).WithDescription("Kategori id'ye göre ürünleri getir")
               .WithDisplayName("KategoriyeGoreUrunGetir");

            productsGroup.MapPost("/", async (IProductService productService, IValidator<CreateNewProductRequest> validator, CreateNewProductRequest request) =>
            {

                var validationResult = await validator.ValidateAsync(request);
                if (!validationResult.IsValid)
                {
                    return Results.BadRequest(new
                    {
                        message = validationResult.Errors.Select(e => new { e.PropertyName, e.ErrorMessage }).ToList()
                    });
                }

                var result = await productService.CreateNewProduct(request);
                return Results.Created($"https://localhost:7258/products/{result}", null);
            });//.RequireAuthorization();

            //not: eğer JWT Token ile auth işlemleri yapılmak istenirse yukarıdaki son method çağrılmalı.



        }
    }
}
