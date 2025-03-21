using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Diagnostics;

namespace EshopLite.API.Filters
{
    public class PerformanceAttribute : ActionFilterAttribute
    {
        private Stopwatch _stopwatch;
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            
            var logger = context.HttpContext.RequestServices.GetService<ILogger<PerformanceAttribute>>();
            _stopwatch = new Stopwatch();
            _stopwatch.Start();
           
            logger.LogInformation($"{context.ActionDescriptor.DisplayName} çalışmaya başladı");


        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            var logger = context.HttpContext.RequestServices.GetService<ILogger<PerformanceAttribute>>();
            _stopwatch.Stop();
            logger.LogInformation($"{context.ActionDescriptor.DisplayName} isimli action'un tamamlanma süresi: {_stopwatch.ElapsedMilliseconds} ms");

            var result = context.Result as OkObjectResult;
            if (result != null) {
                result.Value = new { totalTime = _stopwatch.ElapsedMilliseconds, Result = result.Value };
            }
        }

        /*
         *   Filtre Türleri
         * 1. Exception Filters: Action içinde bir hata meydana gelirse tetiklenir.
         * 2. Action Filters: Action çalışmadan önce, çalışırken veya çalıştıktan sonra gibi AOP ihtiyaçları karşılar.
         * 3. Result Filters: Bir action'un sonucu (response) oluşturulmadan önce ya da sonra...
         * 4. Resource Filter: Pipeline'in başında veya sonunda çalışır.
         */
    }
}
