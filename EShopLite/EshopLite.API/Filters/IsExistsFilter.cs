using EShopLite.Application;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace EshopLite.API.Filters
{
    public class IsExistsFilter(IProductService productService) : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ActionArguments.ContainsKey("id"))
            {
                context.Result = new BadRequestObjectResult(new { message = $"bu action'un id parametresi yok!" });
            }          

            if (context.ActionArguments.TryGetValue("id", out var id)) {
                if (id is int value)
                {
                    if (await productService.IsExists(value))
                    {
                        await next();


                    }
                    else {
                        context.Result = new NotFoundObjectResult(new { message = $"{value} id'li ürün bulunamadı!" });
                    }
                    
                }
            }
            else
            {
                context.Result = new BadRequestObjectResult(new { message = $"bu action'un id parametresi yanlış tipte!" });
            }
           

           
        }
    }
}
